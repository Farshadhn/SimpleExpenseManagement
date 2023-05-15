using Lookif.Layers.WebFramework.Api;
using Lookif.Library.Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SimpleExpenseManagement.API.Models.RequestedModels;
using System.Net.Http.Headers;
using SimpleExpenseManagement.Constants.Enums;

namespace SimpleExpenseManagement.API.Controllers.v1;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class RequestedModelController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    private readonly IConfiguration _configuration;

    public RequestedModelController(IMemoryCache memoryCache,IConfiguration configuration)
    {
        _memoryCache = memoryCache;
        _configuration = configuration;
    }

    [HttpDelete]
    public void ClearCache()
    {
        ((MemoryCache)_memoryCache).Compact(1.0);

    }

 
    private string CreateCacheKey(string key, string address)
     => SecurityHelper.GetSha256Hash(key + address);

    private List<DropDownHolder> CacheExistance(string key, string address)
    {
        if (_memoryCache.TryGetValue(CreateCacheKey(key, address), out List<DropDownHolder> response))
            return response;
        return null;

    }
    private void SetCache(string key, string address, List<DropDownHolder> value)
    {
        _memoryCache.Set(CreateCacheKey(key, address), value);

    }
    [Authorize]
    [HttpPost]
    public async Task<Dictionary<string, List<DropDownHolder>>> RequestedModel(List<RequestedModel> requestedModels, CancellationToken cancellationToken)
    {
        var auth = HttpContext.Request.Headers.Authorization;
        HttpClient httpClient = new();
        httpClient.BaseAddress = new System.Uri(_configuration["ApiUrl"]); 
        httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", auth.ToString().Replace("Bearer", "").Replace("bearer", ""));
       
        Dictionary<string, List<DropDownHolder>> rtn = new();

        foreach (var item in requestedModels)
        {

            var found = CacheExistance(item.ModelName, item.FunctionToCall);
            if (found is not null)
            {
                rtn.Add(item.ModelName, found);
                continue;
            }
            var response =await TryToCall(httpClient, item.FunctionToCall, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                string rs = await response.Content.ReadAsStringAsync(cancellationToken);
                for (int i = 0; i < 5; i++)
                {
                    if (string.IsNullOrEmpty(rs))
                    {
                        response = await TryToCall(httpClient, item.FunctionToCall, cancellationToken);
                        rs = await response.Content.ReadAsStringAsync(cancellationToken);
                        await Task.Delay(300);
                    }
                    else
                    {
                        break;
                    }

                }

                var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<Dictionary<string, string>>>(rs);
                if (deserialized.IsSuccess)
                {
                    List<DropDownHolder> lst = deserialized.Data.Select(x => new DropDownHolder() { Id = x.Key, Value = x.Value }).ToList();
                    SetCache(item.ModelName, item.FunctionToCall, lst);
                    rtn.Add(item.ModelName, lst);
                }

            }


        }
        return rtn;
    }
    private async Task<HttpResponseMessage> TryToCall(HttpClient httpClient, string address, CancellationToken cancellationToken)
    {
     

        return await httpClient.GetAsync(address, cancellationToken); 
    }
}

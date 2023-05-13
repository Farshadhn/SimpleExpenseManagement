using Blazored.LocalStorage;
using Lookif.UI.Common.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using SimpleExpenseManagement.UI.Models.Authentication;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SimpleExpenseManagement.UI.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticatedUserModel> LoginTask(AuthenticationUserModel userForAuthentication);
    Task PassRecoveryTask(PassRecoveryUserModel userForAuthentication);

    Task Logout();
}

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly SiteSettings _siteSetting;

    public AuthenticationService(HttpClient httpClient,
        AuthenticationStateProvider authenticationStateProvider,
        ILocalStorageService localStorage, IOptionsSnapshot<SiteSettings> settings)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
        _siteSetting = settings.Value;
    }

    public async Task Logout()
    {

        try
        {
            await _localStorage.RemoveItemAsync("authToken");

            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
        catch
        {
            //
        }

    }
    public async Task<AuthenticatedUserModel> LoginTask(AuthenticationUserModel userForAuthentication)
    {

        var data = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type","password"),
            new KeyValuePair<string, string>("username",userForAuthentication.UserName),
            new KeyValuePair<string, string>("password",userForAuthentication.Password)
            }
            );

        var authResult = await _httpClient.PostAsync($"{_siteSetting.Api}user/token", data);
        var authContent = await authResult.Content.ReadAsStringAsync();
        var msg = JsonConvert.DeserializeObject<ApiResult>(authContent);
        if (!authResult.IsSuccessStatusCode || !msg.IsSuccess)
        {
            var res = JsonConvert.DeserializeObject<Dictionary<string, string>>(msg.Message);
            return new AuthenticatedUserModel() { IsSuccess = msg.IsSuccess, Error = res["Exception"] };
        }

        var result = JsonSerializer.Deserialize<ApiResult<AuthenticatedUserModel>>(
            authContent,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        await _localStorage.SetItemAsync("authToken", result.Data.access_token);

        ((AuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(result.Data.access_token);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.access_token);
        result.Data.IsSuccess = true;
        return result.Data;
    }

    public async Task PassRecoveryTask(PassRecoveryUserModel userForAuthentication)
    {
        Thread.Sleep(1000);
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type","email"),
            new KeyValuePair<string, string>("username",userForAuthentication.UserName),
            new KeyValuePair<string, string>("email",userForAuthentication.Email)
        }
        );

        var authResult = await _httpClient.PutAsync($"{_siteSetting.Api}users/ResetPassword", data);

        var authContent = await authResult.Content.ReadAsStringAsync();
        var msg = JsonConvert.DeserializeObject<ApiResult>(authContent);
        if (!authResult.IsSuccessStatusCode || !msg.IsSuccess)
        {
            //  Console.WriteLine(" با خطا"); 
            //Console.WriteLine(msg.Message);
            return;
            //var res = JsonConvert.DeserializeObject<Dictionary<string, string>>(msg.Message);
            //  return new AuthenticatedUserModel() { IsSuccess = msg.IsSuccess, Error = res["Exception"] };
        }
        //var result = JsonSerializer.Deserialize<ApiResult<AuthenticatedUserModel>>(
        //    authContent,
        //    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //await _localStorage.SetItemAsync("authToken", result.Data.access_token);

        //((AuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(result.Data.access_token);
        //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.access_token);
        //result.Data.IsSuccess = true;
        //return result.Data;

        /// Console.WriteLine(" بدون خطا" );

    }
}

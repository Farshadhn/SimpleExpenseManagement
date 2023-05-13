namespace SimpleExpenseManagement.API.Models.JWT;

public class TokenRequest
{
    public TokenRequest(string grant_type, string username, string password, string refresh_token, string scope, string client_id, string client_secret)
    {
        this.grant_type = grant_type;
        this.username = username;
        this.password = password;
        this.refresh_token = refresh_token;
        this.scope = scope;
        this.client_id = client_id;
        this.client_secret = client_secret;
    }
    public TokenRequest()
    {

    }
    public string grant_type { get; set; }
    public string username { get; set; }
    // IP
    public string password { get; set; }
    public string refresh_token { get; set; } = "";
    public string scope { get; set; } = "";

    public string client_id { get; set; } = "";
    public string client_secret { get; set; } = "";
}

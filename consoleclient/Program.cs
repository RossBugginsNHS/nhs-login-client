// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using IdentityModel;
using IdentityModel.Client;


var handler = new HttpClientHandler();
handler.ServerCertificateCustomValidationCallback = 
(httpRequestMessage, cert, cetChain, policyErrors) =>
{
    return true;
};


var client = new HttpClient(handler);

Console.WriteLine("Enter user Id");
var userId = Console.ReadLine();
Console.WriteLine("enter pin");
var pin = Console.ReadLine();

var localId = Guid.NewGuid().ToString();
Console.WriteLine("This is from the client app with local Id  " + localId);
var cibaResponse = await client.RequestBackchannelAuthenticationAsync(new BackchannelAuthenticationRequest
{
    Address = "https://localhost:5001/connect/ciba",
    ClientId = "client",
    ClientSecret = "secret",
    Scope = "openid api1",
    LoginHint = userId, // "8214c04d-039f-4aae-808a-ede389bec358" //BobSmith@email.com",
    UserCode = pin,
    BindingMessage = ("This is from the client app with local Id " + localId)
});


var aaaaa = GetHashedKey(cibaResponse.AuthenticationRequestId);

var consentUrl = "https://localhost:5001/Ciba/Consent?id="+aaaaa;
Console.WriteLine($"Please visit {consentUrl} to approve");


var success = false;
TokenResponse tr = null; 
while (!success)

{
    var r1 = await client.RequestBackchannelAuthenticationTokenAsync(new BackchannelAuthenticationTokenRequest
    {
        Address = "https://localhost:5001/connect/token",
        ClientId = "client",
        ClientSecret = "secret",
        AuthenticationRequestId = cibaResponse.AuthenticationRequestId,
        
    });

    

    if (r1.IsError)
    {
        if (r1.Error == OidcConstants.TokenErrors.AuthorizationPending || r1.Error == OidcConstants.TokenErrors.SlowDown)
        {
            await Task.Delay(cibaResponse.Interval.Value * 1000);
        }
        else
        {
            Console.WriteLine(r1.Error);
           // throw new Exception(r1.Error);
        }
    }
    else
    {
        Console.WriteLine("Successfully logged in");
        Console.WriteLine(r1.ExpiresIn);
        success=true;
        tr = r1;
        // success! use response.IdentityToken, response.AccessToken, and response.RefreshToken (if requested)
    }
}


var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}



// call api
var apiClient = new HttpClient(handler);
apiClient.SetBearerToken(tr.AccessToken);

var response = await apiClient.GetAsync("https://localhost:5002/WeatherForecast");
if (!response.IsSuccessStatusCode)
{
    Console.WriteLine(response.StatusCode);
}
else
{
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine(JsonNode.Parse(content));
}


      static string Sha256( string input)
        {
           
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }



static string GetHashedKey(string value)
{
            var key = (value + ":" + "ciba");

        if (value.EndsWith("-1"))
        {
            // newer format >= v6; uses hex encoding to avoid collation issues
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(key);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        // old format <= v5
        return Sha256(key);
}
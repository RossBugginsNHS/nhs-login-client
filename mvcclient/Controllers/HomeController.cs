using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using mvcclient.Models;

namespace mvcclient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
IHttpContextAccessor accessor;
IHttpClientFactory factory;
    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor accessor, IHttpClientFactory factory)
    {
        this.accessor = accessor;
        this.factory = factory;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
     await accessor.HttpContext.GetUserAccessTokenAsync();
          

         var accessToken = await accessor.HttpContext.GetTokenAsync("access_token");

    var client = factory.CreateClient("NoSslChecks");

    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    var content = await client.GetStringAsync("/WeatherForecast");

    ViewBag.Json = JsonNode.Parse(content).ToString();
    return View();

        //return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

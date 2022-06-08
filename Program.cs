using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using NHS.Login.Dotnet.Core6.Sample;


var builder = WebApplication.CreateBuilder(args);

builder.AddNHSLogin();

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.UseEndpoints(endpoints =>
{
endpoints.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Get}/{id?}");
endpoints.MapControllers();
});

app.Run();

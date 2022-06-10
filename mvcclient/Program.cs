using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using IdentityModel.AspNetCore.AccessTokenManagement;

var builder = WebApplication.CreateBuilder(args);



JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
                 options.BackchannelHttpHandler = 
                new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };



        options.Authority = "https://localhost:5001";

        options.ClientId = "mvc2";
        options.ClientSecret = "secret";
        options.ResponseType = "code";

        options.SaveTokens = true;

        
        options.Scope.Add("api1");
        options.Scope.Add("offline_access");
    });

    builder.Services.AddHttpClient(AccessTokenManagementDefaults.BackChannelHttpClientName)
    .ConfigureHttpMessageHandlerBuilder(h=>
    {
        h.PrimaryHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; }};
    });
    builder.Services.AddAccessTokenManagement();



builder.Services.AddHttpContextAccessor();


builder.Services.AddHttpClient("NoSslChecks", c =>
{
    c.BaseAddress=new Uri("https://localhost:5002");
}
).ConfigureHttpMessageHandlerBuilder(h=>
{
    h.PrimaryHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; }};
})
//.ConfigurePrimaryHttpMessageHandler(()=>
 //new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } })
 .AddUserAccessTokenHandler();

    

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute()
        .RequireAuthorization();
});


app.Run();

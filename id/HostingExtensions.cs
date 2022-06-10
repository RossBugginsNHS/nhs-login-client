using System.IdentityModel.Tokens.Jwt;
using FileContextCore;
using FileContextCore.FileManager;
using FileContextCore.Serializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Duende.IdentityServer.EntityFramework.Storage;
using System.Reflection;
using Duende.IdentityServer.Validation;
using System.Security.Claims;
using IdentityModel;
using Duende.IdentityServer.Stores;
using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Models;
using System.Collections.Specialized;

namespace id;

public class BCServ : IBackchannelAuthenticationUserNotificationService
{
    IPersistedGrantStore s;
    IBackChannelAuthenticationRequestStore backchannelAuthenticationStore;
    public BCServ(IPersistedGrantStore s, IBackChannelAuthenticationRequestStore backchannelAuthenticationStore)
    {
        this.s=s;
        this.backchannelAuthenticationStore = backchannelAuthenticationStore;
    }
    public async Task SendLoginRequestAsync(BackchannelUserLoginRequest request)
    {
      
    }
}


public class BCImp : IBackchannelAuthenticationUserValidator
{
    UserManager<ApplicationUser> _userManager;
    public BCImp(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<BackchannelAuthenticationUserValidatonResult> ValidateRequestAsync(
        BackchannelAuthenticationUserValidatorContext userValidatorContext)
    {
        var u = await _userManager.FindByIdAsync(userValidatorContext.LoginHint);
        var r = new BackchannelAuthenticationUserValidatonResult();

        if (userValidatorContext.UserCode != "1234")
        {
            r.Error = "User Code incorrect";
            r.ErrorDescription = "Make sure user code is correct";
        }
       else
        {
            var ids = new List<ClaimsIdentity>();
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtClaimTypes.Subject, u.Id));
            var id = new ClaimsIdentity(claims);
            ids.Add(id);

            r.Subject = new System.Security.Claims.ClaimsPrincipal(ids);
        }

        return r;

        // return r;
    }
}


internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBackchannelAuthenticationUserValidator, BCImp>();
        builder.Services.AddTransient<IBackchannelAuthenticationUserNotificationService,BCServ>();
        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();
        builder.Services.AddHttpContextAccessor();

        var migrationsAssembly = typeof(HostingExtensions).GetTypeInfo().Assembly.GetName().Name;

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
              sql => sql.MigrationsAssembly(migrationsAssembly)));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


        builder.AddNHSLogin();


        builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;


            })

                .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlite(builder.Configuration.GetConnectionString("IdServer"),
            sql => sql.MigrationsAssembly(migrationsAssembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlite(builder.Configuration.GetConnectionString("IdServer"),
            sql => sql.MigrationsAssembly(migrationsAssembly));
    })

            // .AddTestUsers(TestUsers.Users)
            //   .AddInMemoryIdentityResources(Config.IdentityResources)
            //  .AddInMemoryApiScopes(Config.ApiScopes)
            //  .AddInMemoryClients(Config.Clients)
            .AddAspNetIdentity<ApplicationUser>()
            .AddServerSideSessions();


        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();


        app.UseDeveloperExceptionPage();


        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        //  JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); 

        app.UseIdentityServer(
            new IdentityServerMiddlewareOptions()
            {

            });

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.UseCookiePolicy();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}

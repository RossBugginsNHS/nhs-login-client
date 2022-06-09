using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace id;


 public class ApplicationUser : IdentityUser
    {
    }

     public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
    
internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();
        builder.Services.AddHttpContextAccessor();


         builder.Services.AddDbContext<ApplicationDbContext>(config =>  
            {  
                // for in memory database  
                config.UseInMemoryDatabase("MemoryBaseDataBase");  
            });  
  
           builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); 


  builder.AddNHSLogin();

        builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;

                
            })
            
           // .AddTestUsers(TestUsers.Users)
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryClients(Config.Clients)
            .AddAspNetIdentity<ApplicationUser>();

      
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

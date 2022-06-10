using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using id;
using Microsoft.EntityFrameworkCore;
using Serilog;




Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));


        var app = builder
        .ConfigureServices()
        .ConfigurePipeline();
    
InitializeDatabase(app);



        if (args.Contains("/seed"))
    {
        Log.Information("Seeding database...");
        SeedData.EnsureSeedData(app);
        Log.Information("Done seeding database. Exiting.");
        return;
    }

    app.Run();
}
catch (Exception ex)
{
   string type = ex.GetType().Name;
   if (type.Equals("StopTheHostException", StringComparison.Ordinal))
   {
      throw;
   }

   Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}


 void InitializeDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    {
        serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

        var grants =  serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
        foreach (var g in grants.PersistedGrants.ToList())
        {
            grants.PersistedGrants.Remove(g);
        }
        grants.SaveChanges();
        
        var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
        context.Database.Migrate();
        
          foreach (var client in  context.Clients.ToList())
            {
                context.Clients.Remove(client);
            }

               foreach (var client in  context.ApiScopes.ToList())
            {
                context.ApiScopes.Remove(client);
            }

            
               foreach (var client in  context.IdentityResources.ToList())
            {
                context.IdentityResources.Remove(client);
            }

               context.SaveChanges();

        if (!context.Clients.Any())
        {
            foreach (var client in Config.Clients)
            {
                context.Clients.Add(client.ToEntity());
            }
            context.SaveChanges();
        }

        if (!context.IdentityResources.Any())
        {
            foreach (var resource in Config.IdentityResources)
            {
                context.IdentityResources.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }

        if (!context.ApiScopes.Any())
        {
            foreach (var resource in Config.ApiScopes)
            {
                context.ApiScopes.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }
    }
}
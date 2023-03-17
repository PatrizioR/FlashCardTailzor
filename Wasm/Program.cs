using FlashCardTailzor.Data.Models.Configuration;
using FlashCardTailzor.Data.Models.Repositories;
using FlashCardTailzor.Data.Services;
using FlashCardTailzor.Wasm;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Serilog.Debugging;
using System.Reflection;

SelfLog.Enable(m => Console.Error.WriteLine(m));

Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.BrowserConsole()
               .CreateLogger();

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(provider =>
{
    var config = provider.GetService<IConfiguration>();
    var appConfigurationSection = config?.GetSection(nameof(AppConfiguration));
    var appConfiguration = appConfigurationSection?.Get<AppConfiguration>() ?? new AppConfiguration();
    return appConfiguration;
});
builder.Services.AddScoped(sp => new HttpClient { Timeout = new TimeSpan(2, 0, 0), BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}api/") });
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(StateFacade)));
#if DEBUG
    options.UseReduxDevTools();
#endif
});
builder.Services.AddScoped<StateFacade>();
builder.Services.AddSingleton<IClientRepository, MockClientRepository>();

await builder.Build().RunAsync();

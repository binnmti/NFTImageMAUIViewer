using Microsoft.Extensions.Configuration;
using System.Text;

namespace WebJobsEthLog;

class Program
{
    public static IConfigurationRoot Configuration { get; set; }
    static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";
        var builder = new ConfigurationBuilder().AddEnvironmentVariables();
        if (isDevelopment) builder.AddUserSecrets<Program>();
        Configuration = builder.Build();

        var connectionString = Configuration["ScrapingConnectionString"];
    }
}

//var builder = new HostBuilder();
//builder.ConfigureWebJobs(b =>
//{
//    b.AddAzureStorageCoreServices();
//});

//var host = builder.Build();
//using (host)
//{
//    await host.RunAsync();
//}



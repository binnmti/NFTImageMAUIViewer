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

        var infuraApiKey = Configuration["Settings:InfuraApiKey"];
        var connectionString = Configuration["ConnectionString"];

        await CoinAccessor.GetPrices(connectionString);

        //await WriteSqlBlockchain.WriteBlock(infuraApiKey, connectionString);

        //// geth --datadir ./ console 2>> ./e01.log &
        //var gethProcess = new GethProcess("");
        //gethProcess.OnOutputDataReceived += (data) =>
        //{

        //};


        //var log = gethProcess.Start($"--datadir .\\ console 2>> geth_err.log");
        //Console.WriteLine(log); 
        //gethProcess.Writer("");
        //eth.blockNumber
        //eth.getBlock(0)   

        //eth.getBlockTransactionCount(BlockNumber)


    }
}


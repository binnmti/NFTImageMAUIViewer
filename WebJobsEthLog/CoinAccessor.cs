using Dapper;
using Nethereum.Contracts.QueryHandlers.MultiCall;
using Nethereum.RPC.Eth.DTOs;
using NftUtility;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebJobsEthLog;


public class Coin
{
    public string id { get; set; }
    public string symbol { get; set; }
    public string name { get; set; }
}

public class Yen
{
    public string Id { get; set; }
    public float Price { get; set; }
}



public class SimplePrice
{
    public Ethereum ethereum { get; set; }

    [JsonPropertyName("matic-network")]
    public MaticNetwork maticnetwork { get; set; }

    public WethPlentyBridge wethplentybridge { get; set; }
}

public class Ethereum
{
    public int jpy { get; set; }
}

public class MaticNetwork
{
    public float jpy { get; set; }
}

public class WethPlentyBridge
{
    public int jpy { get; set; }
}



internal static class CoinAccessor
{
    //https://api.coingecko.com/api/v3/simple/price?ids=ethereum%2Cmatic-network%2Cweth-plenty-bridge&vs_currencies=jpy

    internal static async Task GetPrices(string connectionString)
    {
        using var client = new HttpClient();
        //GETリクエスト

        //using var resultSqlConnection = new SqlConnection(connectionString);
        //var selectCoin = resultSqlConnection.Query<Coin>("select * from Coin");
        //var ids = string.Join("%2", selectCoin.Select(x => x.id));

        var res = await client.GetAsync($"https://api.coingecko.com/api/v3/simple/price?ids=ethereum%2Cmatic-network%2Cweth-plenty-bridge&vs_currencies=jpy");

        //取得
        var content = await res.Content.ReadAsStringAsync() ?? "";
        var price = JsonSerializer.Deserialize<SimplePrice>(content);

        using var resultSqlConnection = new SqlConnection(connectionString);
        //foreach (var coin in coins)
        //{
        //    resultSqlConnection.Insert(coin);
        //}
    }


    internal static async Task GetCoinsAsync(string connectionString)
    {
        using var client = new HttpClient();
        //GETリクエスト
        var res = await client.GetAsync("https://api.coingecko.com/api/v3/coins/list?include_platform=false");

        var content = await res.Content.ReadAsStringAsync() ?? "";
        var coins = JsonSerializer.Deserialize<List<Coin>>(content);

        using var resultSqlConnection = new SqlConnection(connectionString);
        foreach (var coin in coins)
        {
            resultSqlConnection.Insert(coin);
        }
    }
}

public static class SqlConnectionExtention
{
    public static void Insert<T>(this SqlConnection sqlConnection, T data)
    {
        //var single = sqlConnection.Query<T>($"select * from [{typeof(T).Name}] Where {selectName} = '{selectValue}'").SingleOrDefault();
        //if (single != null) return;

        var (sql, param) = data.GetInsertExecute();
        sqlConnection.Execute(sql, param);
    }

    private static (string, DynamicParameters) GetInsertExecute<T>(this T data)
    {
        var properties = data.GetType().GetProperties();
        return (data.GetSql(properties), data.GetParam(properties));
    }

    private static DynamicParameters GetParam<T>(this T data, IEnumerable<PropertyInfo> propertyInfos)
        => new(propertyInfos.ToDictionary(p => $"@{p.Name}", p => p.GetValue(data)));

    private static string GetSql<T>(this T data, IEnumerable<PropertyInfo> infos)
        => $"insert into [{data?.GetType()?.Name}] ({string.Join(",", infos.Select(x => $"[{x.Name}]"))}) values ({string.Join(",", infos.Select(x => "@" + x.Name))});";
}
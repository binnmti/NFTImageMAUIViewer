using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System.Data.SqlClient;
using Dapper;
using System.Reflection;

namespace NftUtility;

public static class WriteSqlBlockchain
{
    public static async Task WriteBlock(string infuraApiKey, string connectionString)
    {
        var web3 = new Web3($"https://mainnet.infura.io/v3/{infuraApiKey}");
        var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
        for (int i = 50000; i < blockNumber.Value; i++)
        {
            using var sql = new SqlConnection(connectionString);
            sql.Open();
            
            var blockWithTransactions = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(i));
            sql.Insert(nameof(blockWithTransactions.BlockHash), blockWithTransactions.BlockHash, blockWithTransactions.ToBlock());
            foreach (var transaction in blockWithTransactions.Transactions)
            {
                sql.Insert(nameof(transaction.TransactionHash), transaction.TransactionHash, transaction.ToTransaction());
            }
            Console.WriteLine($"Block:{blockWithTransactions.Number}:Transactions:{blockWithTransactions.Transactions.Length}");
        }
    }

    private static BlazorApp1.Shared.Transaction ToTransaction(this Transaction transaction)
        => new ()
        {
            BlockHash = transaction.BlockHash,
            BlockNumber = transaction.BlockNumber?.ToString() ?? "",
            From = transaction.From,
            Gas = transaction.Gas?.ToString() ?? "",
            GasPrice = transaction.GasPrice?.ToString() ?? "",
            Input = transaction.Input,
            MaxFeePerGas = transaction.MaxFeePerGas?.ToString() ?? "",
            MaxPriorityFeePerGas = transaction.MaxPriorityFeePerGas?.ToString() ?? "",
            Nonce = transaction.Nonce?.ToString() ?? "",
            R = transaction.R,
            S = transaction.S,
            To = transaction.To,
            TransactionHash = transaction.TransactionHash,
            TransactionIndex = transaction.TransactionIndex?.ToString() ?? "",
            Type = transaction.Type?.ToString() ?? "",
            V = transaction.V?.ToString() ?? "",
            Value = transaction.Value?.ToString() ?? "",
        };


    private static BlazorApp1.Shared.Block ToBlock(this Block block)
        => new()
        {
            Author = block.Author ?? "",
            BaseFeePerGas = block.BaseFeePerGas?.ToString() ?? "",
            BlockHash = block.BlockHash?.ToString() ?? "",
            Difficulty = block.Difficulty?.ToString() ?? "",
            ExtraData = block.ExtraData?.ToString() ?? "",
            GasLimit = block.GasLimit?.ToString() ?? "",
            GasUsed = block.GasUsed?.ToString() ?? "",
            LogsBloom = block.LogsBloom?.ToString() ?? "",
            Miner = block.Miner?.ToString() ?? "",
            MixHash = block.MixHash?.ToString() ?? "",
            Nonce = block.Nonce?.ToString() ?? "",
            Number = block.Number?.ToString() ?? "",
            ParentHash = block.ParentHash?.ToString() ?? "",
            ReceiptsRoot = block.ReceiptsRoot?.ToString() ?? "",
            SealFields = block.SealFields?.ToString() ?? "",
            Sha3Uncles = block.Sha3Uncles?.ToString() ?? "",
            Size = block.Size?.ToString() ?? "",
            StateRoot = block.StateRoot?.ToString() ?? "",
            Timestamp = block.Timestamp?.ToString() ?? "",
            TotalDifficulty = block.TotalDifficulty?.ToString() ?? "",
            TransactionsRoot = block.TransactionsRoot?.ToString() ?? "",
            Uncles = string.Concat(block.Uncles) ?? "",
        };

}

public static class SqlConnectionExtention
{
    //selectQuery = $"select * from Block Where BlockHash = '{blockWithTransactions.BlockHash}'"
    public static void Insert<T>(this SqlConnection sqlConnection, string selectName, string selectValue, T data)
    {
        var single = sqlConnection.Query<T>($"select * from [{typeof(T).Name}] Where {selectName} = '{selectValue}'").SingleOrDefault();
        if (single != null) return;

        var (sql, param) = data.GetInsertExecute();
        sqlConnection.Execute(sql, param);
    }

    private static (string, DynamicParameters) GetInsertExecute<T>(this T data)
    {
        var properties = data.GetType().GetProperties().Skip(1);
        return (data.GetSql(properties), data.GetParam(properties));
    }

    private static DynamicParameters GetParam<T>(this T data, IEnumerable<PropertyInfo> propertyInfos)
        => new(propertyInfos.ToDictionary(p => $"@{p.Name}", p => p.GetValue(data)));

    private static string GetSql<T>(this T data, IEnumerable<PropertyInfo> infos)
        => $"insert into [{data?.GetType()?.Name}] ({string.Join(",", infos.Select(x => $"[{x.Name}]"))}) values ({string.Join(",", infos.Select(x => "@" + x.Name))});";
}
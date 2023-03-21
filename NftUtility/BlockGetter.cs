using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System.Data.SqlClient;
using Dapper;

namespace NftUtility;

public static class ContractaddressAccessor
{
    public static async Task ToImageUrlAsync(string infuraApiKey, string connectionString)
    {
        var web3 = new Web3($"https://mainnet.infura.io/v3/{infuraApiKey}");
        var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
        for (int i = 0; i < blockNumber.Value; i++)
        {
            using var sql = new SqlConnection(connectionString);
            sql.Open();
            var blockWithTransactions = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(i));
            sql.Insert($"select * from Block Where BlockHash = '{blockWithTransactions.BlockHash}'", blockWithTransactions.ToBlock());
            foreach (var transaction in blockWithTransactions.Transactions)
            {
                sql.Insert($"select * from Block Where Transaction = '{transaction.BlockHash}'", transaction.ToTransaction());
            }
        }
    }

    private static BlazorApp1.Shared.Transaction ToTransaction(this Transaction transaction)
        => new ()
        {
            BlockHash = transaction.BlockHash,
            BlockNumber = transaction.BlockNumber.ToString(),
            From = transaction.From,
            Gas = transaction.Gas.ToString(),
            GasPrice = transaction.GasPrice.ToString(),
            Input = transaction.Input,
            MaxFeePerGas = transaction.MaxFeePerGas.ToString(),
            MaxPriorityFeePerGas = transaction.MaxPriorityFeePerGas.ToString(),
            Nonce = transaction.Nonce.ToString(),
            R = transaction.R,
            S = transaction.S,
            To = transaction.To,
            TransactionHash = transaction.TransactionHash,
            TransactionIndex = transaction.TransactionIndex.ToString(),
            Type = transaction.Type.ToString(),
            V = transaction.V.ToString(),
            Value = transaction.Value.ToString(),
        };


    private static BlazorApp1.Shared.Block ToBlock(this Block block)
        => new()
        {
            Author = block.Author,
            BaseFeePerGas = block.BaseFeePerGas.ToString(),
            BlockHash = block.BlockHash.ToString(),
            Difficulty = block.Difficulty.ToString(),
            ExtraData = block.ExtraData.ToString(),
            GasLimit = block.GasLimit.ToString(),
            GasUsed = block.GasUsed.ToString(),
            LogsBloom = block.LogsBloom.ToString(),
            Miner = block.Miner.ToString(),
            MixHash = block.MixHash.ToString(),
            Nonce = block.Nonce.ToString(),
            Number = block.Number.ToString(),
            ParentHash = block.ParentHash.ToString(),
            ReceiptsRoot = block.ReceiptsRoot.ToString(),
            SealFields = block.SealFields.ToString(),
            Sha3Uncles = block.Sha3Uncles.ToString(),
            Size = block.Size.ToString(),
            StateRoot = block.StateRoot.ToString(),
            Timestamp = block.Timestamp.ToString(),
            TotalDifficulty = block.TotalDifficulty.ToString(),
            TransactionsRoot = block.TransactionsRoot.ToString(),
            Uncles = block.Uncles.ToString(),
        };

    private static void Insert<T>(this SqlConnection sqlConnection, string query, T data)
    {
        var single = sqlConnection.Query<T>(query).SingleOrDefault();
        if (single != null) return;
        sqlConnection.Execute(data.GetInsertSql());
    }

    private static string GetInsertSql<T>(this T data)
    {
        var properties = data.GetType().GetProperties();
        var names = string.Join(",", properties.Select(x => x.Name));
        var atNames = string.Join(",", properties.Select(x => "@" + x.Name));
        return $@"insert into {data?.GetType()?.Name} ({names}) values ({atNames});";
    }
}
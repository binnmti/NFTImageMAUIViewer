using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System.Numerics;
using System.Text.Json;
using Web3Utility;

namespace NftUtility;

public static class ContractaddressAccessor
{
    //public static async Task<Uri> ToImageUrlAsync(this string contractaddress, BigInteger tokenId, string infuraApiKey, HttpClient httpClient)
    //{
    //    var web3 = new Web3($"https://mainnet.infura.io/v3/{infuraApiKey}");
    //    var request = await web3.Eth.GetBalance.SendRequestAsync(contractaddress);
    //    var etherBalance = Web3.Convert.FromWei(request.Value);

    //    //var transactionItems = new List<TransactionItem>();
    //    var transactionCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(contractaddress);
    //    for (int i = 0; i < transactionCount.Value; i++)
    //    {
    //        var blockWithTransactions = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(i));
    //        Transaction a = blockWithTransactions.Author;
    //        //BlockWithTransactions
    //    }

    //    //for (int i = 0; i < count.Value; i++)
    //    //{
    //    //    var bn = web3.Eth.Blocks.GetBlockWithTransactionsByNumber;
    //    //    bn.SendRequestAsync(

    //    //    var hash = web3.Eth.Transactions.GetTransactionByHash;
    //    //    hash.SendRequestAsync()

    //    //    var receipt = web3.Eth.Transactions.GetTransactionByBlockNumberAndIndex;
    //    //    var transaction = await receipt.SendRequestAsync(ethGetTransactionCount.DefaultBlock.BlockNumber, new HexBigInteger(i));
    //    //    transactionItems.Add(new TransactionItem(
    //    //        transaction.BlockHash,
    //    //        transaction.BlockNumber,
    //    //        transaction.From,
    //    //        transaction.To,
    //    //        transaction.Value,
    //    //        transaction.Gas));

    //    //}

    //    //return new AddressItem(etherBalance, 0, transactionItems);
    //}
}
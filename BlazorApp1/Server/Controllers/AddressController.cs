using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.RPC.Eth.Blocks;
using Nethereum.Hex.HexTypes;

namespace BlazorApp1.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IConfiguration _config;
    public AddressController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    public async Task<AddressItem> Get(string address)
    {
        var infuraApiKey = _config["Settings:InfuraApiKey"];
        var web3 = new Web3($"https://mainnet.infura.io/v3/{infuraApiKey}");
        var request = await web3.Eth.GetBalance.SendRequestAsync(address);
        var etherBalance = Web3.Convert.FromWei(request.Value);

        // 最新から1000ブロック分のトランザクション履歴を検索
        var transactionItems = new List<TransactionItem>();

        var ethGetTransactionCount = web3.Eth.Transactions.GetTransactionCount;
        var count = await ethGetTransactionCount.SendRequestAsync(address);


        //for (int i = 0; i < count.Value; i++)
        //{
        //    var bn = web3.Eth.Blocks.GetBlockWithTransactionsByNumber;
        //    bn.SendRequestAsync(

        //    var hash = web3.Eth.Transactions.GetTransactionByHash;
        //    hash.SendRequestAsync()

        //    var receipt = web3.Eth.Transactions.GetTransactionByBlockNumberAndIndex;
        //    var transaction = await receipt.SendRequestAsync(ethGetTransactionCount.DefaultBlock.BlockNumber, new HexBigInteger(i));
        //    transactionItems.Add(new TransactionItem(
        //        transaction.BlockHash,
        //        transaction.BlockNumber,
        //        transaction.From,
        //        transaction.To,
        //        transaction.Value,
        //        transaction.Gas));

        //}

        var number = web3.Eth.Blocks.GetBlockWithTransactionsByNumber;
        var a = await number.SendRequestAsync(new HexBigInteger(9));
        return new AddressItem(etherBalance, 0, transactionItems);
    }


    //// 最新から1000ブロック分のトランザクション履歴を検索
    //var transactionItems = new List<TransactionItem>(); 
    //var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
    //for (int i = 0; i < 1000; i++)
    //{
    //    //Web3.Eth.GetTransactionCount.SendRequestAsync
    //    var transactionCount = web3.Eth.Transactions.GetTransactionCount;
    //    var a = await transactionCount.SendRequestAsync(address);

    //    //Web3.Eth.Transactions.GetTransactionByBlockNumberAndIndex.SendRequestAsyncメソッドで各トランザクションの詳細を取得します。

    //    //var blockParameter = new HexBigInteger(latestBlockNumber.Value - i);
    //    //var block = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(blockParameter);
    //    //foreach (var transaction in block.Transactions.Where(x => x.From == address || x.To == address))
    //    //{
    //    //    var transation = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transaction.TransactionHash);
    //    //    transactionItems.Add(new TransactionItem(
    //    //        transaction.BlockHash,
    //    //        transaction.BlockNumber,
    //    //        transaction.From,
    //    //        transaction.To,
    //    //        transaction.Value,
    //    //        transaction.Gas));
    //    }
    //}
    //    return new AddressItem(etherBalance, 0, transactionItems);
    //}

    //private async void A()
    //{
    //    var infuraApiKey = _config["Settings:InfuraApiKey"];
    //    var web3 = new Web3($"https://mainnet.infura.io/v3/{infuraApiKey}");
    //    // 最新のブロック番号を取得
    //    var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();

    //    // 最新から1000ブロック分のトランザクション履歴を検索
    //    for (var i = latestBlockNumber; i > latestBlockNumber - 1000; i--)
    //    {
    //        // ブロック情報とトランザクション情報を取得
    //        var blockWithTransactionsRequest = new EthGetBlockWithTransactionsByNumberUnityRequest(web3.Client);
    //        var blockWithTransactions = await blockWithTransactionsRequest.SendRequestAsync(new BlockParameter(i));

    //        // トランザクションが存在する場合
    //        if (blockWithTransactions.Transactions != null && blockWithTransactions.Transactions.Length > 0)
    //        {
    //            // 各トランザクションについて
    //            foreach (var transaction in blockWithTransactions.Transactions)
    //            {
    //                // 送信元または送信先が自分のイーサリアムアドレスと一致する場合
    //                if (transaction.From == myAddress || transaction.To == myAddress)
    //                {
    //                    // トランザクションIDと金額を表示
    //                    Console.WriteLine("TxHash: " + transaction.TransactionHash);
    //                    Console.WriteLine("Value: " + Web3.Convert.FromWei(transaction.Value.Value));

    //                    // トランザクションレシートとイベントログを取得
    //                    var transactionReceiptRequest = new EthGetTransactionReceiptUnityRequest(web3.Client);
    //                    var transactionReceipt = await transactionReceiptRequest.SendRequestAsync(transaction.TransactionHash);

    //                    // イベントログが存在する場合
    //                    if (transactionReceipt.Logs != null && transactionReceipt.Logs.Length > 0)
    //                    {
    //                        // 各イベントログについて
    //                        foreach (var log in transactionReceipt.Logs)
    //                        {
    //                            // イベント名とデータを表示
    //                            Console.WriteLine("Event: " + log.EventName);
    //                            Console.WriteLine("Data: " + log.Data);
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}
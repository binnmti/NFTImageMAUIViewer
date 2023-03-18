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

        // �ŐV����1000�u���b�N���̃g�����U�N�V��������������
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


    //// �ŐV����1000�u���b�N���̃g�����U�N�V��������������
    //var transactionItems = new List<TransactionItem>(); 
    //var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
    //for (int i = 0; i < 1000; i++)
    //{
    //    //Web3.Eth.GetTransactionCount.SendRequestAsync
    //    var transactionCount = web3.Eth.Transactions.GetTransactionCount;
    //    var a = await transactionCount.SendRequestAsync(address);

    //    //Web3.Eth.Transactions.GetTransactionByBlockNumberAndIndex.SendRequestAsync���\�b�h�Ŋe�g�����U�N�V�����̏ڍׂ��擾���܂��B

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
    //    // �ŐV�̃u���b�N�ԍ����擾
    //    var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();

    //    // �ŐV����1000�u���b�N���̃g�����U�N�V��������������
    //    for (var i = latestBlockNumber; i > latestBlockNumber - 1000; i--)
    //    {
    //        // �u���b�N���ƃg�����U�N�V���������擾
    //        var blockWithTransactionsRequest = new EthGetBlockWithTransactionsByNumberUnityRequest(web3.Client);
    //        var blockWithTransactions = await blockWithTransactionsRequest.SendRequestAsync(new BlockParameter(i));

    //        // �g�����U�N�V���������݂���ꍇ
    //        if (blockWithTransactions.Transactions != null && blockWithTransactions.Transactions.Length > 0)
    //        {
    //            // �e�g�����U�N�V�����ɂ���
    //            foreach (var transaction in blockWithTransactions.Transactions)
    //            {
    //                // ���M���܂��͑��M�悪�����̃C�[�T���A���A�h���X�ƈ�v����ꍇ
    //                if (transaction.From == myAddress || transaction.To == myAddress)
    //                {
    //                    // �g�����U�N�V����ID�Ƌ��z��\��
    //                    Console.WriteLine("TxHash: " + transaction.TransactionHash);
    //                    Console.WriteLine("Value: " + Web3.Convert.FromWei(transaction.Value.Value));

    //                    // �g�����U�N�V�������V�[�g�ƃC�x���g���O���擾
    //                    var transactionReceiptRequest = new EthGetTransactionReceiptUnityRequest(web3.Client);
    //                    var transactionReceipt = await transactionReceiptRequest.SendRequestAsync(transaction.TransactionHash);

    //                    // �C�x���g���O�����݂���ꍇ
    //                    if (transactionReceipt.Logs != null && transactionReceipt.Logs.Length > 0)
    //                    {
    //                        // �e�C�x���g���O�ɂ���
    //                        foreach (var log in transactionReceipt.Logs)
    //                        {
    //                            // �C�x���g���ƃf�[�^��\��
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
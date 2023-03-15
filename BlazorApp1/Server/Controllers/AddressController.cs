using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Web3;

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
    public async Task<AddressItems> Get(string address)
    {
        var infuraApiKey = _config["Settings:InfuraApiKey"];
        var web3 = new Web3($"https://mainnet.infura.io/v3/{infuraApiKey}");
        var request = await web3.Eth.GetBalance.SendRequestAsync(address);
        var etherBalance = Web3.Convert.FromWei(request.Value);
        return new AddressItems(etherBalance, 0);
    }
}
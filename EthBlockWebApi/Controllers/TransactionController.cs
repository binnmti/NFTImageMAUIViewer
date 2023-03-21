using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EthBlockWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressItemController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public AddressItemController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAddressItem")]
    public IEnumerable<AddressItem> Get()
    {
        return new List<AddressItem>();
    }
}
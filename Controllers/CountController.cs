using hellonet.Controllers.Model;
using Microsoft.AspNetCore.Mvc;

namespace hellonet.Controllers;

[ApiController]
[Route("count")]
public class CountController : ControllerBase
{
    private readonly RedisService _redisService;
    private readonly ILogger<CountController> _logger;

    // look at some di / ioc
    public CountController(ILogger<CountController> logger)
    {
        _logger = logger;
        _redisService = new RedisService();
        logger.Log(LogLevel.Debug, "Count controller init");
    }

    [HttpGet(Name = "get")]
    public async Task<CountResponse> Get()
    {
        string result = await _redisService.GetCount();
        return new CountResponse {
            Count = result
        };
    }

    [HttpPut(Name = "increment")]
    public async Task<CountResponse> Increment()
    {
        string result = await _redisService.Increment();
        return new CountResponse {
            Count = result
        };
    }
}
using System.Text;
using Microsoft.Extensions.ObjectPool;
using StackExchange.Redis;

public class RedisService
{
    private readonly ConnectionMultiplexer _connection;

    private static readonly string CountKey = "kCount";

    public RedisService()
    {
        this._connection = ConnectionMultiplexer.Connect("localhost");
    }

    public IDatabase GetDatabase()
    {
        return _connection.GetDatabase();
    }

    public async Task<string> Increment()
    {
        long result = await GetDatabase().StringIncrementAsync(CountKey, 1);
        return result.ToString();
    }

    public async Task<string> GetCount()
    {
        RedisValue result = await GetDatabase().StringGetAsync(CountKey);
        return result.ToString() ?? "0";
    }
}
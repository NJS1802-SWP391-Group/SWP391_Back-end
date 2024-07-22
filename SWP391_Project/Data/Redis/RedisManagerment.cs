using Data.DiavanModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

public class RedisManagerment
{
    private readonly StackExchange.Redis.IDatabase _cache;
    private readonly ConnectionMultiplexer _redis;

    public RedisManagerment()
    {
        _redis = ConnectionMultiplexer.Connect("diavan-valuation.asia:32768");
        _cache = _redis.GetDatabase();
    }

    public RedisManagerment(ConnectionMultiplexer redis)
    {
        _redis = redis;
        _cache = _redis.GetDatabase();
    }

    public void SetData(string key, string value)
    {
        _cache.StringSet(key, value, TimeSpan.FromDays(1));
    }


    public string GetData(string key)
    {
        return _cache.StringGet(key);
    }

    public void DeleteData(string key)
    {
        _cache.KeyDelete(key);
    }
    public void Dispose()
    {
        _redis?.Dispose();
    }
    public async Task AddProductToListAsync(string key, Service product)
    {
        var products = await GetProductsFromListAsync(key);
        products.Add(product);
        var productJson = JsonConvert.SerializeObject(products);
        await _cache.StringSetAsync(key, productJson);
    }

    public async Task<List<Service>> GetProductsFromListAsync(string key)
    {
        var productList = new List<Service>();
        var productJson = await _cache.StringGetAsync(key);

        if (!string.IsNullOrEmpty(productJson))
        {
            productList = JsonConvert.DeserializeObject<List<Service>>(productJson);
        }
        return productList;
    }

    public async Task PublishAsync(string channel, string message)
    {
        var sub = _redis.GetSubscriber();
        await sub.PublishAsync(channel, message);
    }
}

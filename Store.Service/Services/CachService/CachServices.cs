using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Store.Service.Services.CachService
{
    public class CachServices : ICachService
    {
        private readonly StackExchange.Redis.IDatabase _database;

        public CachServices(IConnectionMultiplexer redis)
        {

            _database = redis.GetDatabase();
        }

        public async Task<string> GetCacheResponseAsync(string key)
        {

            var cachedResponse = await _database.StringGetAsync(key);

            if (cachedResponse.IsNullOrEmpty)
                return null;
            return cachedResponse.ToString();
        }


        public async Task SetCacheResponseAsync(string key, object response, TimeSpan timeToLive)
        {

            if (response is null)
                return;

            var Options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var serializedResponse = JsonSerializer.Serialize(response, Options);

            await _database.StringSetAsync(key, serializedResponse, timeToLive);

        }
    }
}

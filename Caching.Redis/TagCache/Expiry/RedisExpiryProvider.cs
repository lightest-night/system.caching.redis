using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LightestNight.System.Utilities.Extensions;

namespace LightestNight.System.Caching.Redis.TagCache.Expiry
{
    public class RedisExpiryProvider
    {
        /// <summary>
        /// The key used to store the expiry keys in the cache
        /// </summary>
        public string SetKey { get; }

        public RedisExpiryProvider(CacheConfiguration configuration)
        {
            SetKey = $"{configuration.ThrowIfNull(nameof(configuration)).RootNamespace}:_cacheExpiryKeys";
        }

        /// <summary>
        /// Sets the given expiry date to the given key
        /// </summary>
        /// <param name="client">The <see cref="RedisClient" /> to use to connect to Redis</param>
        /// <param name="key">The key to set the expiry to</param>
        /// <param name="expiryDate">The expiry to set</param>
        public Task SetKeyExpiry(RedisClient client, string key, DateTime expiryDate)
            => client.ThrowIfNull(nameof(client)).SetTimeSet(SetKey, key, expiryDate);

        /// <summary>
        /// Removes the expiry from the given keys
        /// </summary>
        /// <param name="client">The <see cref="RedisClient" /> to use to connect to Redis</param>
        /// <param name="keys">The keys to remove the expiry from</param>
        public Task RemoveKeyExpiry(RedisClient client, params string[] keys)
            => client.ThrowIfNull(nameof(client)).RemoveTimeSet(SetKey, keys);

        /// <summary>
        /// Gets the keys that have expired
        /// </summary>
        /// <param name="client">The <see cref="RedisClient" /> to use to connect to Redis</param>
        /// <param name="maxDate">The maximum expiry date to get expired keys before</param>
        /// <returns>A collection of expired keys</returns>
        public Task<IEnumerable<string>> GetExpiredKeys(RedisClient client, DateTime maxDate)
            => client.ThrowIfNull(nameof(client)).GetFromTimeSet(SetKey, maxDate);
    }
}
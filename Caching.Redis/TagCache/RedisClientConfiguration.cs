namespace LightestNight.System.Caching.Redis.TagCache
{
    public class RedisClientConfiguration
    {
        private const int DefaultDbIndex = 0;
        private const int DefaultTimeoutMilliseconds = 1000;

        /// <summary>
        /// The redis database index to connect to
        /// </summary>
        public int DbIndex { get; set; } = DefaultDbIndex;

        /// <summary>
        /// How long to set the redis connection timeout
        /// </summary>
        public int TimeoutMs { get; set; } = DefaultTimeoutMilliseconds;
        
        /// <summary>
        /// The connection manager in charge of the connection
        /// </summary>
        public RedisConnectionManager RedisConnectionManager { get; }

        public RedisClientConfiguration(RedisConnectionManager redisConnectionManager)
        {
            RedisConnectionManager = redisConnectionManager;
        }
    }
}
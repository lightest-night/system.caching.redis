using System;

namespace LightestNight.System.Caching.Redis.Tests.TagCache.Helpers
{
    public static class ConnectionHelper
    {
        public static string IntegrationTestHost => Environment.GetEnvironmentVariable("INTEGRATION_TEST_HOST");
        public static string Password => Environment.GetEnvironmentVariable("INTEGRATION_TEST_PASSWORD");
        public static int Port => Convert.ToInt32(Environment.GetEnvironmentVariable("INTEGRATION_TEST_PORT"));
        public static bool UseSsl => Convert.ToBoolean(Environment.GetEnvironmentVariable("INTEGRATION_TEST_USE_SSL"));
    }
}
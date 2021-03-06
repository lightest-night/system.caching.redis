using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;
using StackExchange.Redis;

namespace LightestNight.System.Caching.Redis.TagCache.Serialization
{
    public class XmlSerializationProvider : ISerializationProvider
    {
        /// <inheritdoc cref="ISerializationProvider.Deserialize{T}" />
        [return: MaybeNull]
        public T Deserialize<T>(RedisValue value) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var textReader = new StringReader(value);
            return (T) xmlSerializer.Deserialize(textReader);
        }

        /// <inheritdoc cref="ISerializationProvider.Serialize{T}" />
        public RedisValue Serialize<T>(T value) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, value);
            return textWriter.ToString();
        }
    }
}
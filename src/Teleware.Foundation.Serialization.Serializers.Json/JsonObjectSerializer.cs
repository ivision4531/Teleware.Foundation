using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleware.Foundation.Serialization.Serializers.Json
{
    /// <summary>
    /// 基于JSON的序列化器
    /// </summary>
    public class JsonObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc/>
        public object DeserializeObject(Type type, Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject(sr.ReadToEnd(), type);
            }
        }

        /// <inheritdoc/>
        public object DeserializeObject(Type type, byte[] bytes)
        {
            return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bytes), type);
        }

        /// <inheritdoc/>
        public T DeserializeObject<T>(Stream stream)
        {
            return (T)DeserializeObject(typeof(T), stream);
        }

        /// <inheritdoc/>
        public T DeserializeObject<T>(byte[] bytes)
        {
            return (T)DeserializeObject(typeof(T), bytes);
        }

        /// <inheritdoc/>
        public byte[] SerializeObject(Type type, object obj)
        {
            var serizlizeResult = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(serizlizeResult);
        }

        /// <inheritdoc/>
        public byte[] SerializeObject<T>(T obj)
        {
            return SerializeObject(typeof(T), obj);
        }

        /// <inheritdoc/>
        public Stream SerializeObjectToStream(Type type, object obj)
        {
            return new MemoryStream(SerializeObject(type, obj));
        }

        /// <inheritdoc/>
        public Stream SerializeObjectToStream<T>(T obj)
        {
            return new MemoryStream(SerializeObject(typeof(T), obj));
        }
    }
}
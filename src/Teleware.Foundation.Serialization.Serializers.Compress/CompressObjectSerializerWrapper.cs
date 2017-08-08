using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleware.Foundation.Serialization.Serializers
{
    /// <summary>
    /// 对象序列化压缩功能包裹器
    /// </summary>
    public class CompressObjectSerializerWrapper : IObjectSerializer
    {
        private readonly IObjectSerializer _innerSerializer;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="innerSerializer"></param>
        public CompressObjectSerializerWrapper(IObjectSerializer innerSerializer)
        {
            _innerSerializer = innerSerializer;
        }

        /// <inheritdoc/>
        public T DeserializeObject<T>(byte[] bytes)
        {
            using (var compress = new DeflateStream(new MemoryStream(bytes), CompressionMode.Decompress))
            {
                return _innerSerializer.DeserializeObject<T>(compress);
            }
        }

        /// <inheritdoc/>

        public T DeserializeObject<T>(Stream stream)
        {
            using (var compress = new DeflateStream(stream, CompressionMode.Decompress))
            {
                return _innerSerializer.DeserializeObject<T>(compress);
            }
        }

        /// <inheritdoc/>

        public byte[] SerializeObject<T>(T obj)
        {
            var ms = new MemoryStream();
            using (var compress = new DeflateStream(ms, CompressionMode.Compress))
            {
                var innerStream = _innerSerializer.SerializeObjectToStream(obj);
                innerStream.CopyTo(compress);
            }
            return ms.ToArray();
        }

        /// <inheritdoc/>

        public Stream SerializeObjectToStream<T>(T obj)
        {
            var compress = new DeflateStream(_innerSerializer.SerializeObjectToStream(obj), CompressionMode.Compress);
            return compress;
        }

        /// <inheritdoc/>

        public object DeserializeObject(Type type, byte[] bytes)
        {
            using (var compress = new DeflateStream(new MemoryStream(bytes), CompressionMode.Decompress))
            {
                return _innerSerializer.DeserializeObject(type, compress);
            }
        }

        /// <inheritdoc/>

        public object DeserializeObject(Type type, Stream stream)
        {
            using (var compress = new DeflateStream(stream, CompressionMode.Decompress))
            {
                return _innerSerializer.DeserializeObject(type, compress);
            }
        }

        /// <inheritdoc/>

        public byte[] SerializeObject(Type type, object obj)
        {
            var ms = new MemoryStream();
            using (var compress = new DeflateStream(ms, CompressionMode.Compress))
            {
                var bytes = _innerSerializer.SerializeObject(type, obj);
                compress.Write(bytes, 0, bytes.Length);
            }
            return ms.ToArray();
        }

        /// <inheritdoc/>

        public Stream SerializeObjectToStream(Type type, object obj)
        {
            var compress = new DeflateStream(_innerSerializer.SerializeObjectToStream(type, obj), CompressionMode.Compress);
            return compress;
        }
    }
}
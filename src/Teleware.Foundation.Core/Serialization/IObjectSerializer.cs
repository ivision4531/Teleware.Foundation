using System;
using System.IO;

namespace Teleware.Foundation.Serialization
{
    /// <summary>
    /// 对象序列化器
    /// </summary>
    public interface IObjectSerializer
    {
        /// <summary>
        /// 反序列化对象
        /// </summary>
        T DeserializeObject<T>(byte[] bytes);

        /// <summary>
        /// 反序列化对象
        /// </summary>
        T DeserializeObject<T>(Stream stream);

        /// <summary>
        /// 序列化对象
        /// </summary>
        byte[] SerializeObject<T>(T obj);

        /// <summary>
        /// 序列化对象到流中
        /// </summary>
        Stream SerializeObjectToStream<T>(T obj);

        /// <summary>
        /// 反序列化对象
        /// </summary>
        object DeserializeObject(Type type, byte[] bytes);

        /// <summary>
        /// 反序列化对象
        /// </summary>
        object DeserializeObject(Type type, Stream stream);

        /// <summary>
        /// 序列化对象
        /// </summary>
        byte[] SerializeObject(Type type, object obj);

        /// <summary>
        /// 序列化对象到流中
        /// </summary>
        Stream SerializeObjectToStream(Type type, object obj);
    }
}
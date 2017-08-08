using System.Reflection;

namespace Teleware.Foundation.Util
{
    /// <summary>
    /// 对象相关帮助类
    /// </summary>
    public static class Objects
    {
        /// <summary>
        /// 检查对象是否为默认值(null for object, default(T) for struct)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDefault<T>(T obj)
        {
            bool isDefault;
            if (typeof(T).GetTypeInfo().IsValueType)
            {
                isDefault = obj.Equals(default(T));
            }
            else
            {
                isDefault = obj == null;
            }
            return isDefault;
        }

        ///// <summary>
        ///// 返回枚举项的描述信息
        ///// </summary>
        ///// <param name="value">要获取描述信息的枚举项</param>
        ///// <returns>枚举项的描述信息</returns>
        //public static string GetDescription(Enum value)
        //{
        //    Type enumType = value.GetType();
        //    // 获取枚举常数名称。
        //    string name = Enum.GetName(enumType, value);
        //    if (name != null)
        //    {
        //        // 获取枚举字段。
        //        FieldInfo fieldInfo = enumType.GetField(name);
        //        if (fieldInfo != null)
        //        {
        //            // 获取描述的属性。
        //            DescriptionAttribute attr = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
        //            if (attr != null)
        //            {
        //                return attr.Description;
        //            }
        //        }
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// 返回对象的描述信息
        ///// </summary>
        ///// <param name="value">要获取描述信息的对象</param>
        ///// <returns>对象的描述信息</returns>
        //public static string GetDisplayName(object value)
        //{
        //    var type = UnwrapProxy(value.GetType());
        //    var descriptionAttribute = type.GetTypeInfo().GetCustomAttribute<DisplayNameAttribute>();
        //    return descriptionAttribute?.DisplayName;
        //}

        ///// <summary>
        ///// 返回对象的描述信息
        ///// </summary>
        ///// <param name="type">要获取描述信息的类型</param>
        ///// <returns>对象的描述信息</returns>
        //public static string GetDisplayName(Type type)
        //{
        //    type = UnwrapProxy(type);
        //    var descriptionAttribute = type.GetTypeInfo().GetCustomAttribute<DisplayNameAttribute>();
        //    return descriptionAttribute?.DisplayName;
        //}

        ///// <summary>
        ///// 是否为代理类（当前只检查EF代理类）
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static bool IsProxy(Type type)
        //{
        //    return type.AssemblyQualifiedName.StartsWith("System.Data.Entity.DynamicProxies.");
        //}

        ///// <summary>
        ///// 获取代理类的实际类型（当前只检查EF代理类）
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns>实际类型，如果不是代理类则直接返回</returns>
        //public static Type UnwrapProxy(Type type)
        //{
        //    Type actualType;
        //    if (type.AssemblyQualifiedName.StartsWith("System.Data.Entity.DynamicProxies."))
        //    {
        //        actualType = type.GetTypeInfo().BaseType;
        //    }
        //    else
        //    {
        //        actualType = type;
        //    }
        //    return actualType;
        //}
    }
}
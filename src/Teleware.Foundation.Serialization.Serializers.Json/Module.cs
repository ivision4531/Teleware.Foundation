using Autofac;
using Teleware.Foundation.Serialization;

namespace Teleware.Foundation.Serialization.Serializers.Json
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JsonObjectSerializer>()
                .As<IObjectSerializer>()
                .Named<IObjectSerializer>(nameof(JsonObjectSerializer))
                .SingleInstance();
        }
    }
}
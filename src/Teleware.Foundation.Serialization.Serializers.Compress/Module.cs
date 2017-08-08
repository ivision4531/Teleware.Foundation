using Autofac;
using Teleware.Foundation.Serialization;

namespace Teleware.Foundation.Serialization.Serializers.Compress
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompressObjectSerializerWrapper>()
                .Named<IObjectSerializer>(nameof(CompressObjectSerializerWrapper));
        }
    }
}
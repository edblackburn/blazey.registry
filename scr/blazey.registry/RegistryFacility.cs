using Castle.MicroKernel.Facilities;

namespace blazey.registry
{
    public class RegistryFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Resolver.AddSubResolver(new RegistryResolver(Kernel));
        }
    }
}
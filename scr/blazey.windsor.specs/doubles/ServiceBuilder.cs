using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace blazey.windsor.specs.doubles
{
    public class ServiceBuilder
    {
        public static implicit operator Service(ServiceBuilder serviceBuilder)
        {
            return serviceBuilder.Build();
        }

        public Service Build()
        {
            var container = new WindsorContainer();
            //Add registrar sub resolver
            container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(container.Kernel));

            //register all dependencies and service
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IDependency>().WithServiceAllInterfaces(),
                Component.For<Service>());

            return container.Resolve<Service>();

        }
    }
}
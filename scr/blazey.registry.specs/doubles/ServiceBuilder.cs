using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace blazey.registry.specs.doubles
{
    public class ServiceBuilder
    {
        private readonly Func<Service> _service;

        private ServiceBuilder(Func<Service> service)
        {
            _service = service;
        }

        public static ServiceBuilder WithWindsor()
        {
            var container = new WindsorContainer();
            //Add registrar sub resolver
            container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(container.Kernel));

            //register all dependencies and service
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IDependency>().WithServiceAllInterfaces(),
                Component.For<Service>());

            return new ServiceBuilder(container.Resolve<Service>);
        }


        public Service Build()
        {
            return _service();
        }
    }
}
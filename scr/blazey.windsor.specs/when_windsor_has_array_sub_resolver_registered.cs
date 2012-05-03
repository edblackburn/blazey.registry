using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Machine.Specifications;

namespace blazey.windsor.specs
{
    public class when_windsor_has_array_sub_resolver_registered
    {
        private Establish context = () =>
            {
                _container = new WindsorContainer();
                _container.Kernel.Resolver.AddSubResolver(new ArrayResolver(_container.Kernel));
                _container.Register(
                    Classes.FromThisAssembly().BasedOn<IAmAnInterface>().WithService.FirstInterface(),
                    Component.For<ServiceComponent>());
            };

        private Because of = () => _exception = Catch.Exception(
            () => _serviceComponent = _container.Resolve<ServiceComponent>());

        private It should_resolve_array = () => _serviceComponent.Array.ShouldBeOfType<IAmAnInterface[]>();

        private It should_not_throw = () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static ServiceComponent _serviceComponent;
        private static IWindsorContainer _container;

        public class ServiceComponent
        {
            public IAmAnInterface[] Array { get; private set; }

            public ServiceComponent(IAmAnInterface[] things)
            {
                Array = things;
            }
        }

        public interface IAmAnInterface
        {
        }

        public class ImplementionOfInterface1 : IAmAnInterface
        {
        }

        public class ImplementionOfInterface2 : IAmAnInterface
        {
        }
    }

}
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace blazey.windsor.specs.doubles
{
    public class MockServiceBuilder<TComponent>
    {
        private readonly IWindsorContainer _container;

        public static MockServiceBuilder<TComponent> WithKey<TKey>(TKey key)
        {
            
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(container.Kernel));
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<TComponent>().WithService.AllInterfaces(),
                Component.For<MockService<TComponent>>());

            return new MockServiceBuilder<TComponent>(container);
            
        }

        private MockServiceBuilder(IWindsorContainer container)
        {
            _container = container;
        }

        public MockService<TComponent> ResolveService()
        {
            return _container.Resolve<MockService<TComponent>>();
        }
    }
}
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace blazey.registry.specs.doubles
{
    public class ContainerBuilder
    {
        private readonly List<IRegistration> _registrations = new List<IRegistration>();

        public ContainerBuilder WithAllInstancesBasedOn<T>()
        {
            _registrations.Add(AllTypes.FromThisAssembly().BasedOn<T>().WithServiceAllInterfaces());
            return this;
        }

        public ContainerBuilder WithAnInstanceOf<TInstance>() where TInstance : class
        {
            _registrations.Add(Component.For<TInstance>());
            return this;
        }

        public IWindsorContainer Build()
        {
            var container = new WindsorContainer();

            container.AddFacility<RegistryFacility>();

            container.Register(_registrations.ToArray());

            return container;
        }
    }
}
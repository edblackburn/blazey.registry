using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Machine.Specifications;
using blazey.windsor.specs.doubles;

namespace blazey.windsor.specs
{
    public class when_registrar_is_resolved_by_container
    {
        private Establish context = () =>
            {
                _container = new WindsorContainer();
                _container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(_container.Kernel));
                _container.Register(
                    Classes.FromThisAssembly().BasedOn<IAmAnInterface>().WithService.AllInterfaces(),
                    Component.For<ComponentWithRegistrarDependency>());
            };

        private Because of = () => _exception = Catch.Exception(
            () => _componentWithRegistrarDependency = _container.Resolve<Stub.ComponentWithRegistrarDependency>());

        private It should_resolve_registrar =
            () => _componentWithRegistrarDependency.Dependency.ShouldBeOfType<Registrar<Stub.IAmAnInterface>>();

        private It should_not_throw = () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static IWindsorContainer _container;
        private static Stub.ComponentWithRegistrarDependency _componentWithRegistrarDependency;
    }



}
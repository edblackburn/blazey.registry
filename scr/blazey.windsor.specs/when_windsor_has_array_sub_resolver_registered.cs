using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Machine.Specifications;
using blazey.windsor.specs.doubles;
using It = Machine.Specifications.It;

namespace blazey.windsor.specs
{
    public class when_windsor_has_array_sub_resolver_registered
    {
        private Establish context = () =>
            {
                _container = new WindsorContainer();
                _container.Kernel.Resolver.AddSubResolver(new ArrayResolver(_container.Kernel));
                _container.Register(
                    Classes.FromThisAssembly().BasedOn<Stub.IAmAnInterface>().WithService.FirstInterface(),
                    Component.For<Stub.ComponentWithArrayDependency>()
                    );
            };

        private Because of = () => _exception = Catch.Exception(
            () => _componentWithArrayDependency = _container.Resolve<Stub.ComponentWithArrayDependency>());

        private It should_resolve_array = () => _componentWithArrayDependency.Dependency.ShouldBeOfType<Stub.IAmAnInterface[]>();

        private It should_not_throw = () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static Stub.ComponentWithArrayDependency _componentWithArrayDependency;
        private static IWindsorContainer _container;
    }
}
using System;
using System.Linq.Expressions;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Machine.Fakes;
using Machine.Specifications;

namespace blazey.windsor.specs
{
    public class when_windsor_has_spy_sub_resolvers_they_must_be_called : WithFakes
    {
        private Establish context = () =>
            {
                _spySubResolver1 = An<ISubDependencyResolver>();
                _spySubResolver2 = An<ISubDependencyResolver>();

                _spySubResolver1.WhenToldTo(x => x.CanResolve(Param<CreationContext>.IsAnything,
                                                              Param<ISubDependencyResolver>.IsAnything,
                                                              Param<ComponentModel>.IsAnything,
                                                              Param<DependencyModel>.IsAnything)).Return(true);

                _spySubResolver2.WhenToldTo(x => x.CanResolve(Param<CreationContext>.IsAnything,
                                                              Param<ISubDependencyResolver>.IsAnything,
                                                              Param<ComponentModel>.IsAnything,
                                                              Param<DependencyModel>.IsAnything)).Return(false);

                _container = new WindsorContainer();
                _container.Kernel.Resolver.AddSubResolver(_spySubResolver1);
                _container.Kernel.Resolver.AddSubResolver(_spySubResolver2);
                _container.Register(Component.For<object>());
            };

        private Because of = () => _exception = Catch.Exception(() => _container.Resolve<object>());

        private It should_be_able_to_verify_that = () => _spySubResolver1.WasToldTo(Func);

        private static Expression<Action<ISubDependencyResolver>> Func
        {
            get
            {
                return x => x.CanResolve(
                    Param<CreationContext>.IsAnything,
                    Param<ISubDependencyResolver>.IsAnything,
                    Param<ComponentModel>.IsAnything,
                    Param<DependencyModel>.IsAnything);
            }
        }


        private It should_not_throw = () => _exception.ShouldBeNull();

        private static IWindsorContainer _container;
        private static ISubDependencyResolver _spySubResolver1;
        private static ISubDependencyResolver _spySubResolver2;
        private static Exception _exception;
    }

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
using System;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace blazey.windsor.specs
{
    [Ignore("Need to look into Windsor, why is this failing? Shouldn't ")]
    public class when_windsor_has_spy_sub_resolvers_they_must_be_called
    {
        private Establish context = () =>
            {
                _spySubResolver1Mockery = new Mock<ISubDependencyResolver>();
                _spySubResolver2Mockery = new Mock<ISubDependencyResolver>();

                _spySubResolver1Mockery.Setup(x => x.CanResolve(
                    Moq.It.IsAny<CreationContext>(),
                    Moq.It.IsAny<ISubDependencyResolver>(),
                    Moq.It.IsAny<ComponentModel>(),
                    Moq.It.IsAny<DependencyModel>())).Verifiable("Spy sub resolver 1 not called");

                _spySubResolver2Mockery.Setup(x => x.CanResolve(
                    Moq.It.IsAny<CreationContext>(),
                    Moq.It.IsAny<ISubDependencyResolver>(),
                    Moq.It.IsAny<ComponentModel>(),
                    Moq.It.IsAny<DependencyModel>())).Verifiable("Spy sub resolver 2 not called");


                _container = new WindsorContainer();
                _container.Kernel.Resolver.AddSubResolver(_spySubResolver1Mockery.Object);
                _container.Kernel.Resolver.AddSubResolver(_spySubResolver2Mockery.Object);
                _container.Register(Component.For<object>());
            };

        private Because of = () => _exception = Catch.Exception(() => _container.Resolve<object>());

        private It should_verify_that_sub_resolver_1_was_called = () => _spySubResolver1Mockery.VerifyAll();

        private It should_verify_that_sub_resolver_2_was_called = () => _spySubResolver2Mockery.VerifyAll();

        private It should_not_throw = () => _exception.ShouldBeNull();

        private static IWindsorContainer _container;
        private static Mock<ISubDependencyResolver> _spySubResolver1Mockery;
        private static Mock<ISubDependencyResolver> _spySubResolver2Mockery;
        private static Exception _exception;
    }
}
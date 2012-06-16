using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Machine.Specifications;
using blazey.windsor.specs.doubles;
using blazey.windsor.specs.doubles.predicates;

namespace blazey.windsor.specs
{
    public class when_item_is_requested_from_registrar
    {
        private Establish context = () =>
            {
                var container = new WindsorContainer();
                container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(container.Kernel));
                container.Register(
                    AllTypes.FromThisAssembly().BasedOn<IItemWithBehaviour>().WithService.AllInterfaces(),
                    Component.For<MockService<IItemWithBehaviour>>());

                _mockService = container.Resolve<MockService<IItemWithBehaviour>>();

            };

        private Because of = () => _exception = Catch.Exception(
            () => _itemWithBehaviour = _mockService.SelectItem("key"));

        private It should_be_is_satisfied_true =
            () => _itemWithBehaviour.ShouldBeOfType<IsSatisfiedByTrue>();

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static IItemWithBehaviour _itemWithBehaviour;
        private static Exception _exception;
        private static MockService<IItemWithBehaviour> _mockService;
    }
}
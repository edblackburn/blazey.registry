using System;
using Machine.Specifications;
using blazey.registry.specs.doubles;

namespace blazey.registry.specs.windsor
{
    public class when_service_is_composed_by_windsor_container
    {
        private Establish context = () =>
                                        {
                                            var container = new ContainerBuilder()
                                                .WithAllInstancesBasedOn<IDependency>()
                                                .WithAnInstanceOf<Service>()
                                                .Build();

                                            _service = container.Resolve<Service>();
                                        };

        private Because of = () => _exception = Catch.Exception(
            () => _registry = _service.Registry);

        private It should_be_registrar_of_idependency =
            () => _registry.ShouldBeOfType<Registry<IDependency>>();

        private It should_not_be_null =
            () => _registry.ShouldNotBeNull();

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static Registry<IDependency> _registry;
        private static Service _service;
    }
}
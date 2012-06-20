using System;
using Machine.Specifications;
using blazey.windsor.specs.doubles;
using blazey.windsor.specs.doubles.predicates;

namespace blazey.windsor.specs
{
    public class when_registrar_invokes_specification_to_resolve_an_instance_with_a_default
    {
        private Establish context = () => _service = new ServiceBuilder();

        private Because of = () => _exception = Catch.Exception(
            () => _instance = _service.GetOrDefaultItem("fake_param"));

        private It should_be_of_type_default_dependency =
            () => _instance.ShouldBeOfType<DefaultDependency>();

        private It should_not_be_of_type_dependency_y =
            () => _instance.ShouldNotBeOfType(typeof (DependencyY));

        private It should_not_be_of_type_dependency_x =
            () => _instance.ShouldNotBeOfType(typeof (DependencyX));

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static IDependency _instance;
        private static Service _service;
    }
}
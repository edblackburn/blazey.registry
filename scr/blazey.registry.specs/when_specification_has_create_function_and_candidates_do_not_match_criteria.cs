using System;
using Machine.Specifications;
using blazey.registry.specs.doubles;
using blazey.registry.specs.doubles.predicates;

namespace blazey.registry.specs
{
    public class when_specification_has_create_function_and_candidates_do_not_match_criteria
    {
        private Establish context = () =>
        {
            var stubs = new IDependency[] { new DependencyX(), new DependencyY() };
            _service = new Service(new Registrar<IDependency>(stubs));
        };

        private Because of = () => _exception = Catch.Exception(
            () => _instance = _service.GetOrCreate("fake_param"));

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
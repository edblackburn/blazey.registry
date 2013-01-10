using System;
using Machine.Specifications;
using blazey.registry.specs.doubles;
using blazey.registry.specs.doubles.predicates;

namespace blazey.registry.specs
{
    public class when_specification_matches_dependency_x_criteria
    {
        private Establish context = () =>
                                        {
                                            var stubs = new IDependency[] {new DependencyX(), new DependencyY()};
                                            _service = new Service(new Registrar<IDependency>(stubs));
                                        };

        private Because of = () => _exception = Catch.Exception(
            () => _instance = _service.Get("x"));

        private It should_return_type_dependency_x =
            () => _instance.ShouldBeOfType<DependencyX>();

        private It should_not_return_type_dependency_y =
            () => _instance.ShouldNotBeOfType(typeof (DependencyY));

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static IDependency _instance;
        private static Service _service;
    }
}
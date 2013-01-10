using System;
using Machine.Specifications;
using blazey.registry.specs.doubles;

namespace blazey.registry.specs
{
    public class when_specification_does_not_match_any_criteria
    {
        private Establish context = () =>
            {
                var stubs = new IStubInterface[] {new StubInterfaceImpl1(), new StubInterfaceImpl2()};
                _registrar = new Registrar<IStubInterface>(stubs);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _instance = _registrar.Get(string.Empty));

        private It should_return_null =
            () => _instance.ShouldBeNull();

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static IStubInterface _instance;
        private static Registrar<IStubInterface> _registrar;
    }
}
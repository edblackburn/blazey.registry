using System;
using System.Collections.Generic;
using Machine.Specifications;
using blazey.windsor.specs.doubles;

namespace blazey.windsor.specs
{
    public class when_registrar_item_has_a_base_class
    {
        private Establish context = () =>
            {
                _builder = MockServiceBuilder<Stub.IIsSatisfiedByIsMatchAndMatch>.WithKey("key");
            };

        private Because of = () => _exception = Catch.Exception(
            () => _instance = _builder.ResolveService().SelectedItem);

        private It should_be_is_satisfied_is_true =
            () => _instance.ShouldBeOfType<Stub.IsSatisfiedParamIsKey>();

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static Stub.IIsSatisfiedByIsMatchAndMatch _instance;
        private static MockServiceBuilder<Stub.IIsSatisfiedByIsMatchAndMatch> _builder;
    }
}
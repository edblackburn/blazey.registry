using System;
using System.Collections.Generic;
using Machine.Specifications;
using blazey.windsor.specs.doubles;

namespace blazey.windsor.specs
{
    public class when_registrar_item_has_no_specification_method
    {
        private Establish context = () =>
            {
                _specification = new Specification<Stub.IAmAnInterface>();
                _instances = new Stub.IAmAnInterface[]
                    {
                        new Stub.ImplementionOfInterface1(), new Stub.ImplementionOfInterface2()
                    };
            };

        private Because of = () => _exception = Catch.Exception(
            () => _instance = _specification.Instance(_instances, "key"));

        private It should_have_null_specification =
            () => _instance.ShouldBeNull();
        
        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static Stub.IAmAnInterface _instance;
        private static Specification<Stub.IAmAnInterface> _specification;
        private static Exception _exception;
        private static IEnumerable<Stub.IAmAnInterface> _instances;
    }
}
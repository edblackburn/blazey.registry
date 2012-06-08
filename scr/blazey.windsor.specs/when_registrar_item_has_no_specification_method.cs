using System;
using System.Reflection;
using Machine.Specifications;

namespace blazey.windsor.specs
{
    public class when_registrar_item_has_no_specification_method
    {
        private Establish context = () =>
            {
                _specificationMember = new Specification<>();
                _registrarType = typeof(Stub.IAmAnInterface);
                _specificationParameterType = typeof(string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _specificationMember.Instance(_registrarType, _specificationParameterType));

        private It should_have_null_specification_method =
            () => _specificationMethod.ShouldBeNull();


        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Specification<> _specification;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }
}
using System;
using System.Linq;
using System.Reflection;
using Machine.Specifications;

namespace blazey.windsor.specs
{
    public class when_registrar_item_has_can_satisfy_member
    {
        private Establish context = () =>
            {
                _candidate = new Candidate();
                _registrarType = typeof (Stub.ICanSatisfy);
                _specificationParameterType = typeof (string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_method_should_not_be_null =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_be_can_satisfy_member_name =
            () => _specificationMethod.Name.ShouldEqual("CanSatisfy");

        private It should_have_a_first_parameter_named_param =
            () => _specificationMethod.GetParameters()[0].Name.ShouldEqual("param");

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }

    public class when_registrar_item_has_is_satisfied_by_member
    {
        private Establish context = () =>
            {
                _candidate = new Candidate();
                _registrarType = typeof (Stub.IIsSatisfiedBy);
                _specificationParameterType = typeof (string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_method_should_not_be_null =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_be_is_satisfied_by_member_name =
            () => _specificationMethod.Name.ShouldEqual("IsSatisfiedBy");

        private It should_have_a_first_parameter_named_param =
            () => _specificationMethod.GetParameters()[0].Name.ShouldEqual("param");

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }

    public class when_registrar_item_has_satisfied_member
    {
        private Establish context = () =>
            {
                _candidate = new Candidate();
                _registrarType = typeof (Stub.ISatisfied);
                _specificationParameterType = typeof (string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_method_should_not_be_null =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_be_satisfiedmember_name =
            () => _specificationMethod.Name.ShouldEqual("Satisfied");

        private It should_have_a_first_parameter_named_param =
            () => _specificationMethod.GetParameters()[0].Name.ShouldEqual("param");

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }

    public class when_registrar_item_has_satisfy_member
    {
        private Establish context = () =>
            {
                _candidate = new Candidate();
                _registrarType = typeof (Stub.ISatisfy);
                _specificationParameterType = typeof (string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_method_should_not_be_null =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_be_is_satisfy_member_name =
            () => _specificationMethod.Name.ShouldEqual("Satisfy");

        private It should_have_a_first_parameter_named_param =
            () => _specificationMethod.GetParameters()[0].Name.ShouldEqual("param");

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }

    public class when_registrar_item_has_is_match_member
    {
        private Establish context = () =>
            {
                _candidate = new Candidate();
                _registrarType = typeof (Stub.IIsMatch);
                _specificationParameterType = typeof (string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_method_should_not_be_null =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_be_is_match_member_name =
            () => _specificationMethod.Name.ShouldEqual("IsMatch");

        private It should_have_a_first_parameter_named_param =
            () => _specificationMethod.GetParameters()[0].Name.ShouldEqual("param");

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }

    public class when_registrar_item_has_match_member
    {
        private Establish context = () =>
            {
                _candidate = new Candidate();
                _registrarType = typeof (Stub.IMatch);
                _specificationParameterType = typeof (string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_method_should_not_be_null =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_be_match_member_name =
            () => _specificationMethod.Name.ShouldEqual("Match");

        private It should_have_a_first_parameter_named_param =
            () => _specificationMethod.GetParameters()[0].Name.ShouldEqual("param");

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }

    public class when_registrar_item_has_is_satisfied_by_member_and_match_member
    {
        private Establish context = () =>
            {
                _candidate = new Candidate();
                _registrarType = typeof (Stub.IIsSatisfiedByAndMatch);
                _specificationParameterType = typeof (string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_method_should_not_be_null =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_be_is_satisfied_by_member_name =
            () => _specificationMethod.Name.ShouldEqual("IsSatisfiedBy");

        private It should_have_a_first_parameter_named_param =
            () => _specificationMethod.GetParameters()[0].Name.ShouldEqual("param");

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }

    public class when_registrar_item_has_a_base_class
    {
        private Establish context = () =>
        {
            _candidate = new Candidate();
            _registrarType = typeof(Stub.IsSatisfiedByWithIsMatchAndMatch);
            _specificationParameterType = typeof(string);
        };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_method_should_not_be_null =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_be_is_satisfied_by_member_name =
            () => _specificationMethod.Name.ShouldEqual("IsSatisfiedBy");

        private It should_have_a_first_parameter_named_param =
            () => _specificationMethod.GetParameters()[0].Name.ShouldEqual("param");

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;
    }


    public class Candidate
    {
        public MethodInfo SpecificationMethod(Type registrarType, Type specificationParameterType)
        {
            var whitelistMemberName = new[] {"issatisfiedby", "satisfied", "cansatisfy", "satisfy", "ismatch", "match"};

            var publicMethods = registrarType.GetInterfaces()
                .SelectMany(contract => contract.GetMethods())
                .Union(registrarType.GetMethods());

            return publicMethods
                .Where(member => member.ReturnType == typeof (bool))
                .Where(member => member.GetParameters().Length == 1)
                .Where(member => member.GetParameters()[0].ParameterType == specificationParameterType)
                .FirstOrDefault(member => whitelistMemberName.Any(
                    whiteItem =>
                    whiteItem == new string(member.Name.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant()));
        }
    }
}
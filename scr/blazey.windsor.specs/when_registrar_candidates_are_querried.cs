using System;
using System.Linq;
using System.Reflection;
using Machine.Specifications;

namespace blazey.windsor.specs
{
    public class when_registrar_type_is_valid_candidate_with_bool_is_satisfied_member
    {
        private Establish context = () =>
            {
                _candidate = new Candidate();
                _registrarType = typeof (Aclass);
                _specificationParameterType = typeof (string);
            };

        private Because of = () => _exception = Catch.Exception(
            () => _specificationMethod = _candidate.SpecificationMethod(_registrarType, _specificationParameterType));

        private It should_identify_as_candidate =
            () => _specificationMethod.ShouldNotBeNull();

        private It should_not_throw = () => _exception.ShouldBeNull();

        private static MethodInfo _specificationMethod;
        private static Candidate _candidate;
        private static Type _registrarType;
        private static Type _specificationParameterType;
        private static Exception _exception;

        private class Aclass
        {
            public void Method()
            {
            }

            public int Property { get; private set; }

            public bool Parameters(int param1, string param2)
            {
                return false;
            }

            public bool Parameter(string param)
            {
                return false;
            }

            public bool CanSatisfy(string param)
            {
                return false;
            }
        }
    }

    public class Candidate
    {
        public MethodInfo SpecificationMethod(Type registrarType, Type specificationParameterType)
        {
            var candidates = registrarType.GetMembers()
                .Where(member => member.MemberType == MemberTypes.Method)
                .Cast<MethodInfo>()
                .Where(member => member.ReturnType == typeof (bool))
                .Where(member => member.GetParameters().Length == 1)
                .Where(member => member.GetParameters()[0].ParameterType == specificationParameterType);

            var specWhiteList = new[] {"issatisfiedby", "satisfied", "cansatisfy", "satisfy", "ismatch", "match"};

            return candidates.FirstOrDefault(member =>
                                             specWhiteList.Any(
                                                 whiteItem =>
                                                 member.Name.IndexOf(whiteItem,
                                                                     StringComparison.CurrentCultureIgnoreCase) >= 0));
        }
    }

    public class when_registrar_type_is_valid_candidate_with_bool_satisfied_member
    {
        private It should_identify_as_candidate;
    }


    public class when_registrar_type_is_valid_candidate_with_bool_is_candidate_member
    {
        private It should_identify_as_candidate;
    }

    public class when_registrar_type_is_valid_candidate_with_bool_matches_member
    {
        private It should_identify_as_candidate;
    }
}
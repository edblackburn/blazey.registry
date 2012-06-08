using System;
using System.Linq;
using System.Reflection;

namespace blazey.windsor
{
    public class Candidate
    {
        private static readonly Func<MethodInfo, string> _homogenise =
            method => new string(method.Name.Where(char.IsLetterOrDigit).Select(char.ToLowerInvariant).ToArray());

        public MethodInfo SpecificationMethod(Type registrarType, Type specificationParameterType)
        {
            var whitelist = new[] {"issatisfiedby", "satisfied", "cansatisfy", "satisfy", "ismatch", "match"};

            var methods = registrarType.GetInterfaces()
                .SelectMany(contract => contract.GetMethods())
                .Union(registrarType.GetMethods())
                .Where(member => member.ReturnType == typeof (bool))
                .Where(member => member.GetParameters().Length == 1)
                .Where(member => member.GetParameters()[0].ParameterType == specificationParameterType);

            var orderedMethods = whitelist.GroupJoin(methods, item => item, _homogenise, (item, orderGroup) => orderGroup).
                SelectMany(m => m);


            return orderedMethods.FirstOrDefault();
        }
    }
}
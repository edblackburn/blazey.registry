using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace blazey.registry
{
    internal class CandidateMap<TInstance> where TInstance : class 
    {

        public TInstance Instance<TParameterKey>(IEnumerable<TInstance> candidates, TParameterKey parameterKey)
        {
            Func<MethodInfo, string> homogenise =
                instance =>
                new string(instance.Name.Where(char.IsLetterOrDigit).Select(char.ToLowerInvariant).ToArray());

            var instanceType = typeof (TInstance);

            var whitelist = new[] {"issatisfiedby", "satisfied", "cansatisfy", "satisfy", "ismatch", "match"};

            var methods = instanceType.GetInterfaces()
                .SelectMany(contract => contract.GetMethods())
                .Concat(instanceType.GetMethods())
                .Where(member => member.ReturnType == typeof (bool))
                .Where(member => member.GetParameters().Length == 1)
                .Where(member => member.GetParameters()[0].ParameterType == typeof(TParameterKey));

            var method = whitelist
                .GroupJoin(methods, item => item, homogenise, (item, orderGroup) => orderGroup)
                .SelectMany(m => m)
                .FirstOrDefault();

            if (null == method) return default(TInstance);

            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod;

            var parameter = new object[] {parameterKey};

            return candidates.FirstOrDefault(candidate =>
                {
                    var type = candidate.GetType();

                    return (bool) type.InvokeMember(method.Name, bindingFlags, Type.DefaultBinder, candidate, parameter);
                });
        }
    }
}
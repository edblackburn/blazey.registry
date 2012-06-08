using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace blazey.windsor
{
    public class Registrar<TService>

    {
        private readonly IEnumerable<TService> _candidates;

        public Registrar(IEnumerable<TService> candidates)
        {
            _candidates = candidates;
        }

        public TService Get<TSpecification>(TSpecification specification)
        {
            
            var method = new Candidate().SpecificationMethod(typeof (TService), typeof (TSpecification));

            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod;

            var item = _candidates.FirstOrDefault(candidate =>
                {
                    var type = candidate.GetType();
                    
                    return (bool)type.InvokeMember(method.Name, bindingFlags, Type.DefaultBinder, candidate, new object[] {specification});
                });

            return item;
        }
    }
}
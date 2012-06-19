using System;
using System.Collections.Generic;

namespace blazey.windsor
{
    public class Registrar<TInstance> where TInstance : class
    {
        private readonly IEnumerable<TInstance> _candidates;

        public Registrar(IEnumerable<TInstance> candidates)
        {
            _candidates = candidates;
        }

        public TInstance Get<TParameterKey>(TParameterKey parameterKey)
        {
            return new Specification<TInstance>().Instance(_candidates, parameterKey);
        }

        public TInstance GetOrDefault<TParameterKey>(TParameterKey parameterKey, Func<TInstance> defaultFactory)
        {
            if (null == defaultFactory) throw new ArgumentNullException("defaultFactory");

            return new Specification<TInstance>().Instance(_candidates, parameterKey) ?? defaultFactory();
        }
    }
}
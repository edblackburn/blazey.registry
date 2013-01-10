using System;
using System.Collections.Generic;

namespace blazey.registry
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
            return new CandidateMap<TInstance>().Instance(_candidates, parameterKey);
        }

        public TInstance Get<TParameterKey>(TParameterKey parameterKey, Func<TInstance> createIfNotFound)
        {
            if (null == createIfNotFound) throw new ArgumentNullException("createIfNotFound");

            return Get(parameterKey) ?? createIfNotFound();
        }

    }
}
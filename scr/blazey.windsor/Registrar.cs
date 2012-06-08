using System.Collections.Generic;

namespace blazey.windsor
{
    public class Registrar<TInstance>
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
    }
}
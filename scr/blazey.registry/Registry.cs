using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace blazey.registry
{   
    [DebuggerDisplay("{_instances}")]
    public class Registry<TInstance> where TInstance : class
    {
        private readonly ISet<TInstance> _candidates;
        // ReSharper disable NotAccessedField.Local field is accessed by DebbugerDisplayAttribute
        private readonly StringBuilder _instances = new StringBuilder();
        // ReSharper restore NotAccessedField.Local

        public static Registry<TInstance> Candidates(params TInstance[] candidates)
        {
            return new Registry<TInstance>(candidates);
        }

        public Registry(IEnumerable<TInstance> candidates)
        {
            _candidates = new HashSet<TInstance>(candidates);
            _instances = Instances();
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

        private StringBuilder Instances()
        {
            var builder = new StringBuilder();
            builder.AppendFormat("Instances Type: {0}", typeof (TInstance).FullName);
            foreach (var candidate in _candidates)
            {
                builder.AppendLine(candidate.GetType().FullName);
            }

            return builder;
        }

    }
}
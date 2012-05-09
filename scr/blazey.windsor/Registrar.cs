using System.Collections.Generic;

namespace blazey.windsor
{
    public class Registrar<TService>

    {
        private readonly IEnumerable<TService> _candidates;

        public Registrar(IEnumerable<TService> candidates)
        {
            _candidates = candidates;
        }
    }
}
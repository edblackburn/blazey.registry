using System;

namespace blazey.windsor.specs.doubles.predicates
{
    public class IsSatisfiedByTrue : IItemWithBehaviour
    {
        public bool IsSatisfiedBy(string param)
        {
            return true;
        }

        public void Behaviour()
        {
            throw new NotImplementedException();
        }
    }
}
using System;

namespace blazey.windsor.specs.doubles.predicates
{
    public class IsSatisfiedByFalse : IItemWithBehaviour
    {
        public bool IsSatisfiedBy(string param)
        {
            return false;
        }

        public void Behaviour()
        {
            throw new NotImplementedException();
        }
    }
}
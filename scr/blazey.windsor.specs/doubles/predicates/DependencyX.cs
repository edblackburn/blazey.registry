using System;

namespace blazey.windsor.specs.doubles.predicates
{
    public class DependencyX : IsSatisfiedByBase, IDependency
    {

        public override bool IsSatisfiedBy(string param)
        {
            return string.Equals("x", param, StringComparison.CurrentCultureIgnoreCase);
        }

        public bool Match(string param)
        {
            throw new InvalidOperationException("Match should not be invoked because accompanying member IsSatisfied is before in sequence");
        }

        public void Behaviour()
        {

        }

    }
}
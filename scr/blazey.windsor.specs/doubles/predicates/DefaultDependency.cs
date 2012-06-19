namespace blazey.windsor.specs.doubles.predicates
{
    public class DefaultDependency : IDependency
    {
        public bool IsSatisfiedBy(string param)
        {
            return false;
        }

        public bool Match(string param)
        {
            return false;
        }

        public void Behaviour()
        {
        }
    }
}
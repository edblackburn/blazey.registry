namespace blazey.windsor.specs.doubles.predicates
{
    public abstract class MockCandidateSpecification : IsSatisfiedByBase, IMockCandidateSpecification
    {
        private readonly string _param;

        protected MockCandidateSpecification(string param)
        {
            _param = param;
        }

        public override bool IsSatisfiedBy(string param)
        {
            return param == _param;
        }

        public bool IsMatch(string param)
        {
            return param == _param;
        }

        public bool Match(string param)
        {
            return param == _param;
        }

        public bool Satisfied(string param)
        {
            return param == _param;
        }

        public bool CanSatisfy(string param)
        {
            return param == _param;
        }

        public bool Satisfy(string param)
        {
            return param == _param;
        }
    }
}
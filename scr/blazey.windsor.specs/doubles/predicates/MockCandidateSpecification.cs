namespace blazey.windsor.specs.doubles.predicates
{
    public abstract class MockCandidateSpecification : IsSatisfiedByBase, IMockCandidateSpecification
    {
        public string ExpectedParam { get; private set; }

        protected MockCandidateSpecification(string param)
        {
            ExpectedParam = param;
        }

        public override bool IsSatisfiedBy(string param)
        {
            return param == ExpectedParam;
        }

        public bool IsMatch(string param)
        {
            return param == ExpectedParam;
        }

        public bool Match(string param)
        {
            return param == ExpectedParam;
        }

        public bool Satisfied(string param)
        {
            return param == ExpectedParam;
        }

        public bool CanSatisfy(string param)
        {
            return param == ExpectedParam;
        }

        public bool Satisfy(string param)
        {
            return param == ExpectedParam;
        }
    }

    public class MockCandidateSpecificationWhereParamIsEmpty : MockCandidateSpecification
    {
        public MockCandidateSpecificationWhereParamIsEmpty() : base(string.Empty)
        {
        }
    }

    public class MockCandidateSpecificationWhereParamIsKey : MockCandidateSpecification
    {
        public MockCandidateSpecificationWhereParamIsKey() : base("key")
        {
        }
    }
}
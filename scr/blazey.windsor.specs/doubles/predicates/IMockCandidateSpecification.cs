namespace blazey.windsor.specs.doubles.predicates
{
    public interface IMockCandidateSpecification : IIsSatisfiedBy, ISatisfied, ICanSatisfy, ISatisfy, IIsMatch, IMatch
    {
        string ExpectedParam { get; }
    }
}
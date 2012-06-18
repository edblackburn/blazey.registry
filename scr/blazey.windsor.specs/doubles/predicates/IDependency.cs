namespace blazey.windsor.specs.doubles.predicates
{
    public interface IDependency : IIsSatisfiedBy, ISatisfied, ICanSatisfy, ISatisfy, IIsMatch, IMatch
    {
        void DoSomething();
    }
}
using blazey.windsor.specs.doubles.predicates;

namespace blazey.windsor.specs.doubles
{
    public interface IDependency : IIsSatisfiedBy, IMatch
    {
        void Behaviour();
    }
}
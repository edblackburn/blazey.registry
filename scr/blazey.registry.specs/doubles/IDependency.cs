using blazey.registry.specs.doubles.predicates;

namespace blazey.registry.specs.doubles
{
    public interface IDependency : IIsSatisfiedBy, IMatch
    {
        void Behaviour();
    }
}
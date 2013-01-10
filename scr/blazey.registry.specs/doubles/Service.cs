using blazey.registry.specs.doubles.predicates;

namespace blazey.registry.specs.doubles
{
    public class Service
    {
        public Registry<IDependency> Registry { get; private set; }

        public Service(Registry<IDependency> registry)
        {
            Registry = registry;
        }

        public IDependency Get(string param)
        {
            return Registry.Get(param);
        }

        public IDependency GetOrCreate(string param)
        {
            return Registry.Get(param, () => new DefaultDependency());
        }
    }
}
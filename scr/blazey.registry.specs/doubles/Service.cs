using blazey.registry.specs.doubles.predicates;

namespace blazey.registry.specs.doubles
{
    public class Service
    {
        public Registrar<IDependency> Registrar { get; private set; }

        public Service(Registrar<IDependency> registrar)
        {
            Registrar = registrar;
        }

        public IDependency Get(string param)
        {
            return Registrar.Get(param);
        }

        public IDependency GetOrDefaultItem(string param)
        {
            return Registrar.Get(param, () => new DefaultDependency());
        }
    }
}
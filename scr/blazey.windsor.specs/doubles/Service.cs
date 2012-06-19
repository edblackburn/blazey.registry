using blazey.windsor.specs.doubles.predicates;

namespace blazey.windsor.specs.doubles
{
    public class Service
    {
        public Registrar<IDependency> Registrar { get; private set; }

        public Service(Registrar<IDependency> registrar)
        {
            Registrar = registrar;
        }

        public IDependency SelectItem(string param)
        {
            return Registrar.Get(param);
        }

        public IDependency SelectOrDefaultItem(string param)
        {
            return Registrar.GetOrDefault(param, () => new DefaultDependency());
        }
    }
}
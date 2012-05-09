namespace blazey.windsor.specs
{
    public class Stub
    {
        public interface IAmAnInterface
        {
        }

        public class ImplementionOfInterface1 : IAmAnInterface
        {
        }

        public class ImplementionOfInterface2 : IAmAnInterface
        {
        }

        public class ComponentWithRegistrarDependency
        {
            public ComponentWithRegistrarDependency(Registrar<IAmAnInterface> registrar)
            {
                Dependency = registrar;
            }

            public Registrar<IAmAnInterface> Dependency { get; private set; }
        }

        public class ComponentWithArrayDependency
        {
            public IAmAnInterface[] Dependency { get; private set; }

            public ComponentWithArrayDependency(IAmAnInterface[] things)
            {
                Dependency = things;
            }
        }
    }
}
using System;

namespace blazey.windsor.specs
{
    public class Stub
    {
        public interface IIsSatisfiedByAndMatch : IIsSatisfiedBy, IMatch
        {
            void SomeBehaviour(object[] foos, object[] bars);
        }

        public interface ICanSatisfy
        {
            bool CanSatisfy(string param);
        }

        public interface IIsSatisfiedBy
        {
            bool IsSatisfiedBy(string param);
        }

        public interface ISatisfied
        {
            bool Satisfied(string param);
        }

        public interface ISatisfy
        {
            bool Satisfy(string param);
        }

        public interface IIsMatch
        {
            bool IsMatch(string param);
        }

        public interface IMatch
        {
            bool Match(string param);
        }

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

        public abstract class StubBase
        {
            public void Behaviour()
            {
            }

            public bool IsSatisfiedBy(string param)
            {
                throw new NotImplementedException();
            }
        }

        public class IsSatisfiedByWithIsMatchAndMatch : StubBase, IIsMatch, IMatch
        {
            public bool IsMatch(string param)
            {
                throw new NotImplementedException();
            }

            public bool Match(string param)
            {
                throw new NotImplementedException();
            }
        }
    }
}
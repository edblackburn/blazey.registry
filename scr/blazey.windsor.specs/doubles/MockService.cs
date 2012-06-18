using blazey.windsor.specs.doubles.predicates;

namespace blazey.windsor.specs.doubles
{
    public class MockService
    {
        public Registrar<IMockCandidateSpecification> Registrar { get; private set; }

        public MockService(Registrar<IMockCandidateSpecification> registrar)
        {
            Registrar = registrar;
        }

        public IMockCandidateSpecification SelectItem(string param)
        {
            return Registrar.Get(param);
        }
    }
}
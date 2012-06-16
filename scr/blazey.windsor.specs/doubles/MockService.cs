namespace blazey.windsor.specs.doubles
{
    public class MockService<TComponent>
    {
        public Registrar<TComponent> Registrar { get; private set; }

        public MockService(Registrar<TComponent> registrar)
        {
            Registrar = registrar;
        }

        public TComponent SelectItem<TParam>(TParam param)
        {
            return Registrar.Get(param);
        }
    }
}
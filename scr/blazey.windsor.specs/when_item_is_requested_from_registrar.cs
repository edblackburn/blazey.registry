using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Machine.Specifications;

namespace blazey.windsor.specs
{
    public class when_item_is_requested_from_registrar
    {
        private Establish context = () =>
            {
                var container = new WindsorContainer();
                container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(container.Kernel));
                container.Register(
                    AllTypes.FromThisAssembly().BasedOn<IItem>().WithService.AllInterfaces(),
                    Component.For<Harness>());

                _harness = container.Resolve<Harness>();

            };

        private Because of = () => _exception = Catch.Exception(
            () => _item = _harness.SelectedItem);

        private It should_be_stub_2 =
            () => _item.ShouldBeOfType<StubItem2>();

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static IItem _item;
        private static Exception _exception;
        private static Harness _harness;
    }

    public class StubItem3 : IItem
    {
        public bool IsSatisfiedBy(string param)
        {
            return false;
        }

        public void Behaviour()
        {
            throw new NotImplementedException();
        }
    }

    public class StubItem2 : IItem
    {
        public bool IsSatisfiedBy(string param)
        {
            return true;
        }

        public void Behaviour()
        {
            throw new NotImplementedException();
        }
    }


    public class StubItem1 : IItem
    {
        public bool IsSatisfiedBy(string param)
        {
            return false;
        }

        public void Behaviour()
        {
            throw new NotImplementedException();
        }
    }

    public class Harness
    {
        public Harness(Registrar<IItem> registrar)
        {
            SelectedItem = registrar.Get("key");
        }

        public IItem SelectedItem { get; private set; }
    }

    public interface IItem : Stub.IIsSatisfiedBy
    {
        void Behaviour();
    }
}
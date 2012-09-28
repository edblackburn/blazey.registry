using System.Drawing;
using Machine.Specifications;
using blazey.registry.specs.doubles;

namespace blazey.registry.specs
{
    public class when_we_query_for_a_red_car
    {
        private Establish context = () =>
                                        {
                                            var container = new ContainerBuilder()
                                                .WithAllInstancesBasedOn<ICar>()
                                                .WithAnInstanceOf<CarQuery>()
                                                .Build();

                                            _carQuery = container.Resolve<CarQuery>();
                                        };

        private Because of = () => _car = _carQuery.GetRedCar();

        private It should_return_a_ferrari = () => _car.ShouldBeOfType<Ferrari>();

        private static ICar _car;
        private static CarQuery _carQuery;

        public class CarQuery
        {
            private readonly Registrar<ICar> _carRegistry;

            public CarQuery(Registrar<ICar> carRegistry)
            {
                _carRegistry = carRegistry;
            }

            public ICar GetRedCar()
            {
                return _carRegistry.Get(Color.Red);
            }
        }

        public class Ferrari : ICar
        {
            public bool IsSatisfiedBy(Color color)
            {
                return color == Color.Red;
            }

            public void Drive()
            {
            }
        }

        public class Lamborghini : ICar
        {
            public bool IsSatisfiedBy(Color color)
            {
                return color == Color.Yellow;
            }

            public void Drive()
            {
            }
        }

        public class Jaguar : ICar
        {
            public bool IsSatisfiedBy(Color color)
            {
                return color == Color.DarkGreen;
            }

            public void Drive()
            {
            }
        }

        public interface ICar : IByColour
        {
            void Drive();
        }

        public interface IByColour
        {
            bool IsSatisfiedBy(Color color);
        }
    }
}
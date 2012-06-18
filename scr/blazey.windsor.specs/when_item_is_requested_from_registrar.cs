using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Machine.Specifications;
using blazey.windsor.specs.doubles;
using blazey.windsor.specs.doubles.predicates;

namespace blazey.windsor.specs
{
    public class when_item_is_requested_from_registrar
    {
        private Establish context = () =>
            {
                _container = new WindsorContainer();
                _container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(_container.Kernel));
                _container.Register(
                    AllTypes.FromThisAssembly().BasedOn<IMockCandidateSpecification>().WithServiceAllInterfaces(),
                    Component.For<MockService>());
            };

        private Because of = () => _exception = Catch.Exception(
            () => _instance = _container.Resolve<MockService>().SelectItem("key"));

        private It should_be_of_type_mock_candidate_specification_where_param_is_key =
            () => _instance.ShouldBeOfType<MockCandidateSpecificationWhereParamIsKey>();

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static IMockCandidateSpecification _instance;
        private static IWindsorContainer _container;

    }
}
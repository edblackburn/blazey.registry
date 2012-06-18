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
                //Add registrar sub resolver
                _container.Kernel.Resolver.AddSubResolver(new RegistrarResolver(_container.Kernel));

                //register all dependencies and service
                _container.Register(
                    AllTypes.FromThisAssembly().BasedOn<IDependency>().WithServiceAllInterfaces(),
                    Component.For<Service>());
            };

        private Because of = () => _exception = Catch.Exception(
            () => _instance = _container.Resolve<Service>().SelectItem("key"));

        private It should_be_of_type_mock_candidate_specification_where_param_is_key =
            () => _instance.ShouldBeOfType<DependencyWhereParamIsKey>();

        private It should_not_throw =
            () => _exception.ShouldBeNull();

        private static Exception _exception;
        private static IDependency _instance;
        private static IWindsorContainer _container;

    }
}
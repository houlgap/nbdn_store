using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewPathRegistrySpecs
    {
        public abstract class concern : Observes<ViewPathRegistry,
                                            DefaultViewPathRegistry>
        {

        }

        [Subject(typeof(DefaultViewPathRegistry))]
        public class when_registering_an_assembly : concern
        {
            private Establish c = () =>
            {
                the_criteria = (Type t) => t.IsAssignableFrom(typeof(MyDefaultViewFor));
                change(() => DefaultViewPathRegistry.view_path_registry_criteria).to(the_criteria);
            };

            Because b = () =>
                   sut.register_views_from(typeof(MyDefaultViewFor).Assembly.GetTypes());

            It should_load_all_types_that_inherit_default_view_for = () =>
                   sut.downcast_to<DefaultViewPathRegistry>().registered_views.Keys.ShouldContain(typeof(DefaultViewFor<MyViewModel>));

            It should_have_the_correct_class = () =>
                   sut.get_path_for<MyViewModel>().ShouldEqual("~/web/ViewPathRegistrySpecs/when_registering_an_assembly/MyDefaultViewFor.aspx");

            private static ViewPathRegistryCriteria the_criteria;


            public interface MyViewModel { }
            public class MyDefaultViewFor : DefaultViewFor<MyViewModel> { }

        }
    }


}

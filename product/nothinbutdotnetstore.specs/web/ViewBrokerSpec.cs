using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewBrokerSpec
    {
        public abstract class concern : Observes<ViewBroker,
                                            DefaultViewBroker>
        {
        }

        [Subject(typeof(DefaultViewBroker))]
        public class when_view_for_type_is_requested : concern
        {
            Establish c = () =>
            {
                expected_view = new DefaultViewFor<int>();
                default_views_path_registry = the_dependency<ViewPathRegistry>();
                default_views_path_registry.Stub(x => x.get_path_for<int>()).Return("blah");

                Func<string, Type, object> FakePageFactory =
                    (path, type) =>
                    {
                        requested_path = path;
                        requested_model = type;
                        return ((object) expected_view);
                    };
                change(() => DefaultViewBroker.page_factory).to(FakePageFactory);
            };

            Because b = () =>
                result = sut.get_view_for<int>();

            It should_return_correct_view = () =>
                result.ShouldBe(typeof(ViewFor<int>));

            static ViewFor<int> result;
            static ViewFor<int> expected_view;
            static ViewPathRegistry default_views_path_registry;
            static string requested_path;
            static Type requested_model;
        }
    }
}
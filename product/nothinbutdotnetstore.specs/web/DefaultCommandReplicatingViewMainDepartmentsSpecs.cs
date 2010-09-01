 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{   
    public class DefaultCommandReplicatingViewMainDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            DefaultCommand<IEnumerable<Department>>>
        {
        
        }

        [Subject(typeof(DefaultCommand<IEnumerable<Department>>))]
        public class when_processing_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                all_departments = the_dependency<IEnumerable<Department>>();
                renderer = the_dependency<Renderer>();
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_renderer_to_render_the_main_departments = () =>
                renderer.received(x => x.render(all_departments));

            static Renderer renderer;
            static Request request;
            static IEnumerable<Department> all_departments;
        }
    }
}

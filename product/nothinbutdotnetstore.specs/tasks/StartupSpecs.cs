using System;
using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.specs.web;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Startup))]
        public class when_the_application_has_started_up : concern
        {
            private Establish c = () =>
                                  {
                                      startup_services = new DefaultStartupServices(typeof (when_the_application_has_started_up).Assembly);
                                      ViewPathRegistryCriteria the_criteria = (Type t) => false;
                                      change(() => DefaultViewPathRegistry.view_path_registry_criteria).to(the_criteria);
                                  };
            Because b = () => 
                Startup.run(startup_services);

            It should_be_able_to_access_key_services = () =>
                IOC.retrieve.an<FrontController>().ShouldBeAn<DefaultFrontController>();

            It should_be_have_a_list_of_commands = () =>
                IOC.retrieve.an<IEnumerable<RequestCommand>>().ShouldNotBeEmpty();

            private static DefaultStartupServices startup_services;
        }
    }
}
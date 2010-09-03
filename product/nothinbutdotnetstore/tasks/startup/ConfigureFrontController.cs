using System.Collections.Generic;
using System.Reflection;
using System.Web;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        StartupServices services;

        public ConfigureFrontController(StartupServices services)
        {
            this.services = services;
        }

        public void run()
        {
            services.register_dependency_factory<FrontController>(() => new DefaultFrontController(IOC.retrieve.an<CommandBroker>()));
            services.register_dependency_factory<CommandBroker>(() => new DefaultCommandBroker(IOC.retrieve.an<IEnumerable<RequestCommand>>()));
            services.register_dependency_factory<RequestFactory>(() => new DefaultRequestFactory(IOC.retrieve.an<MappingGateway>()));
            services.register_dependency_factory<ViewBroker>(() => new DefaultViewBroker(IOC.retrieve.an<DefaultViewPathRegistry>()));
            services.register_dependency_factory<Renderer>(() => new WebFormRenderer(IOC.retrieve.an<ViewBroker>()));
            var view_path_registry = new DefaultViewPathRegistry();
            services.register_dependency_factory<ViewPathRegistry>(() => view_path_registry);
            WebFormRenderer.retriever = () => HttpContext.Current;
            DefaultViewPathRegistry.view_path_registry_criteria = Conventions.criteria_to_select_types_for_available_views;
            view_path_registry.register_views_from(services.get_types_from_views_assembly());
        }
    }
}
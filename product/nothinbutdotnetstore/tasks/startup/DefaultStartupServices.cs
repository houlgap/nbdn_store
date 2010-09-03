using System;
using System.Collections.Generic;
using System.Reflection;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupServices : StartupServices
    {
        Assembly assembly_with_views { get; set; }
        IDictionary<Type, DependencyResolver> resolvers = new Dictionary<Type, DependencyResolver>();

        public DefaultStartupServices(Assembly assembly_with_views)
        {
            this.assembly_with_views = assembly_with_views;
        }

        public void register_dependency_factory<Contract>(Func<object> resolver)
        {
            resolvers.Add(typeof (Contract), new FunctionalDependencyResolver(resolver));
        }

        public DependencyResolver get_resolver_for(Type dependency)
        {
            return resolvers[dependency];
        }

        public IEnumerable<Type> get_types_from_views_assembly()
        {
            return assembly_with_views.GetTypes();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public delegate bool ViewPathRegistryCriteria(Type type);
    public class DefaultViewPathRegistry : ViewPathRegistry
    {
        public IDictionary<Type, Type> registered_views = new Dictionary<Type, Type>();
        public static ViewPathRegistryCriteria view_path_registry_criteria = delegate
        {
            throw new NotImplementedException("This needs to be configured at startup");
        };


        public void register_views_from(IEnumerable<Type> types)
        {
            types.Where(t => view_path_registry_criteria(t))
                 .each(type => registered_views.Add(type.BaseType, type));
        }

        public string get_path_for<ViewModel>()
        {
            Type registered_view = registered_views[typeof(DefaultViewFor<ViewModel>)];
            string assembly_name = registered_view.Assembly.GetName().Name;
            return "~/" + registered_view.FullName.Substring(assembly_name.Length + 1).Replace("+", "/").Replace(".", "/") + ".aspx";
        }
    }
}
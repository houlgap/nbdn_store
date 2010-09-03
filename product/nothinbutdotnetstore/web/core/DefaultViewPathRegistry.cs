using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewPathRegistry : ViewPathRegistry
    {
        public IDictionary<Type, Type> registered_views = new Dictionary<Type, Type>();

        public void register_views_from(IEnumerable<Type> types)
        {
            var types_with_base_types = types.Where(t => t.BaseType != null);           //SPECICIATION!
            foreach (Type type in types_with_base_types)                                //EACH
            {
                if (type.BaseType.Name.StartsWith("DefaultViewFor"))                    //SPECIFICATION!
                {
                    registered_views.Add(type.BaseType, type);
                }
            }
        }

        public string get_path_for<ViewModel>()
        {
            Type registered_view = registered_views[typeof (DefaultViewFor<ViewModel>)];
            string assembly_name = registered_view.Assembly.GetName().Name;
            return "~/" + registered_view.FullName.Substring(assembly_name.Length + 1).Replace("+", "/").Replace(".", "/") + ".aspx";
        }
    }
}
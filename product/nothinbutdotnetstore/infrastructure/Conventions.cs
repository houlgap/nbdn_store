using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure
{
    public class Conventions
    {
        public static ViewPathRegistryCriteria criteria_to_select_types_for_available_views = t => t.BaseType != null && t.BaseType.IsAssignableFrom(typeof(ViewFor));
        
    }
}
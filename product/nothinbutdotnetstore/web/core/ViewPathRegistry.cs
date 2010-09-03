using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewPathRegistry
    {
        void register_views_from(IEnumerable<Type> types);
        string get_path_for<T>();
    }
}
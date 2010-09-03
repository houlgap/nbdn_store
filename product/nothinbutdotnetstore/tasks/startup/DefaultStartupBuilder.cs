using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupBuilder : StartupBuilder
    {
        public IEnumerable<StartupCommand> registered_commands { get; set; }
        
        
        public StartupBuilder followed_by<T>()
        {
            throw new NotImplementedException();
        }
    }
}
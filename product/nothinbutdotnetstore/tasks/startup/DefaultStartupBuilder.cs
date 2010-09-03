using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupBuilder : StartupBuilder
    {
        public StartupCommandFactory command_factory;
        public Command command;

        public DefaultStartupBuilder(Command command_to_run, StartupCommandFactory command_factory)
        {
            this.command_factory = command_factory;
            command = command_to_run;
        }

        public DefaultStartupBuilder(Type type, StartupCommandFactory command_factory)
        {
            this.command_factory = command_factory;
            this.command = command_factory.create_command_of(type);
        }

        public StartupBuilder followed_by<T>() where T : StartupCommand
        {
            return new DefaultStartupBuilder(create_chained_command<T>(), command_factory);
        }

        public void finish_by<T>()
        {
            command = create_chained_command<T>();
            command.run();
        }

        private ChainedCommand create_chained_command<T>()
        {
            return new ChainedCommand(command, command_factory.create_command_of(typeof (T)));
        }
    }
}
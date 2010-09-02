using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        private IList<RequestCommand> set_of_commands;

        public StubSetOfCommands()
        {
            this.set_of_commands = new List<RequestCommand>();

            set_of_commands.Add(new DefaultRequestCommand(request => request.page_name.ToLower() == typeof(ViewMainDepartments).Name.ToLower(), new ViewMainDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(), IOC.retrieve.an<Renderer>())));
            set_of_commands.Add(new DefaultRequestCommand(request => request.page_name.ToLower() == typeof(ViewSubDepartments).Name.ToLower(), new ViewSubDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(), IOC.retrieve.an<Renderer>())));
            set_of_commands.Add(new DefaultRequestCommand(request => request.page_name.ToLower() == typeof(ViewProducts).Name.ToLower(), new ViewProducts(IOC.retrieve.an<CatalogBrowsingTasks>(), IOC.retrieve.an<Renderer>())));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<RequestCommand> GetEnumerator()
        {
            foreach (RequestCommand request_command in set_of_commands)
            {
                yield return request_command;
            }
        }
    }
}
<%@ Application Language="C#" %>
<%@ Import Namespace="nothinbutdotnetstore.tasks.startup" %>
<script runat="server">

        private void Application_Start(object sender, EventArgs e)
        {
            StartupServices startup_services = new DefaultStartupServices(GetType().Assembly);
            Startup.run(startup_services);
        }


</script>

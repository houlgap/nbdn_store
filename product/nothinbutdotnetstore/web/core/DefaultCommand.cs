using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommand<ViewModel> : ApplicationCommand
    {
        Renderer renderer;
        private ViewModel view_model;


        public DefaultCommand(Renderer renderer, ViewModel view_model)
        {
            this.renderer = renderer;
            this.view_model = view_model;
        }

        public void process(Request request)
        {
            renderer.render(view_model);

        }
    }
}
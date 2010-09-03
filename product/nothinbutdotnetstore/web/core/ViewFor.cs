using System.Web;

namespace nothinbutdotnetstore.web.core
{
    /// <summary>
    /// Marker interface to enable convention based view discovery
    /// </summary>
    public interface ViewFor
    {

    }

    public interface ViewFor<Model> : IHttpHandler, ViewFor
    {
        Model model { get; set; }
    }
}
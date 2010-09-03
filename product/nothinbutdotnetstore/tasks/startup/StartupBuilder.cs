namespace nothinbutdotnetstore.tasks.startup
{
    public interface StartupBuilder
    {
        StartupBuilder followed_by<T>();
    }
}
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupBuilderSpecs
    {
        public abstract class concern : Observes<StartupBuilder,
                                            DefaultStartupBuilder>
        {

        }

        //[Subject(typeof(DefaultStartupBuilder))]
        //public class when_the_builder_is_first_created: concern
        //{
        //    private Because b = () =>
        //        sut.followed_by

        //    It should_initialise_the_builder_for_the_supplied_type = () =>   


        //    private static void result;

        //}

        [Subject(typeof(DefaultStartupBuilder))]
        public class when_adding_a_following_startup_command : concern
        {
            private Establish c = () =>
                                  {

                                  };

            private Because b = () =>
                                sut.followed_by<MyFollowingStartupCommand>();

            private It should_be_available_in_the_chain = () =>
                sut.ShouldBeAn<DefaultStartupBuilder>().registered_commands.Last().ShouldBeAn<MyFollowingStartupCommand>();


            private class MyFollowingStartupCommand
            {
            }
        }
    }
}

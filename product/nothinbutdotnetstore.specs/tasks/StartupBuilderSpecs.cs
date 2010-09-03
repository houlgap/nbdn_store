 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 
namespace nothinbutdotnetstore.specs.tasks
{   
    public class StartupBuilderSpecs
    {
        public abstract class concern : Observes<contract_interface,
                                            contract_implementation>
        {
        
        }

        [Subject(typeof(contract_implementation))]
        public class when_observation_name : concern
        {
        
            It first_observation = () =>        
                   
        }
    }
}

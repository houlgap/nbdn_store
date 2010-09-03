 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.tasks
 {   
     public class StartupServicesSpecs
     {
         public abstract class concern : Observes<StartupServices,
                                             DefaultStartupServices>
         {
        
         }

         [Subject(typeof(DefaultStartupServices))]
         public class when_a_functional_resolver_has_been_registered : concern
         {
             Because b = () =>
                 {
                     sut.register_dependency_factory<string>(() => "blah");
                     result = sut.get_resolver_for(typeof (string));
                 };


             It should_return_corresponding_resolver = () =>
                    result.ShouldBeAn<FunctionalDependencyResolver>();

             It should_create_functional_resolver_using_passed_delegate = () =>
                 result.create().ShouldEqual("blah");


             static DependencyResolver result;
         }
     }
 }
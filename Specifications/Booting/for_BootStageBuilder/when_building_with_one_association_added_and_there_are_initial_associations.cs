using Machine.Specifications;

namespace Dolittle.Booting.for_BootStageBuilder
{
    public class when_building_with_one_association_added_and_there_are_initial_associations : given.initial_associations
    {
        const string third_key = "ThirdKey";
        static object third_value = "ThirdValue";

        static BootStageResult result;

        Establish context = () => 
        {
            builder.Associate(third_key,third_value);
        };

        Because of = () => result = builder.Build();

        It should_only_have_one_association = () => result.Associations.Count.ShouldEqual(1);
        It should_hold_the_key_added_specifically_to_the_build = () => result.Associations[third_key].ShouldEqual(third_value);
    }
}
using Machine.Specifications;

namespace Dolittle.Serialization.Protobuf.for_MessageDescriptions.given
{
    public class no_message_descriptions
    {
        protected static MessageDescriptions message_descriptions;

        Establish context = () => message_descriptions = new MessageDescriptions();
    }
}
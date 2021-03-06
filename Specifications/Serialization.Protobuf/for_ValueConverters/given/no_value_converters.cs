using System.Collections.Generic;
using Dolittle.Types;
using Machine.Specifications;
using Moq;

namespace Dolittle.Serialization.Protobuf.for_ValueConverters.given
{

    public class no_value_converters : all_dependencies
    {
        protected static ValueConverters    value_converters;

        Establish context = () => 
        {
            value_converter_instances.Setup(_ => _.GetEnumerator()).Returns(new List<IValueConverter>().GetEnumerator());
            value_converters = new ValueConverters(value_converter_instances.Object);
        };
    }
}
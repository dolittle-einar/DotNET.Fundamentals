﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Machine.Specifications;

namespace Dolittle.Types.Specs.for_TypeFinder
{
    [Subject(typeof(TypeFinder))]
    public class when_finding_types_with_multiple_implementations_but_asking_for_a_single : given.a_type_finder
    {
        static Exception exception;

        Establish context = () => contract_to_implementors_map_mock.Setup(c => c.GetImplementorsFor(typeof(IMultiple))).Returns(new[] { typeof(FirstMultiple), typeof(SecondMultiple) });

        Because of = () => exception = Catch.Exception(() => type_finder.FindSingle<IMultiple>());

        It should_throw_a_multiple_types_found_exception = () => exception.ShouldBeOfExactType<MultipleTypesFoundException>();
    }
}
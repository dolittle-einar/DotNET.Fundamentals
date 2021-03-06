/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Dolittle.Serialization.Protobuf
{
    /// <summary>
    /// Defines a system for working with <see cref="IValueConverter">value converters</see>
    /// </summary>
    public interface IValueConverters
    {
        /// <summary>
        /// Check wether or not a specific type can be converted
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool CanConvert(Type type);

        /// <summary>
        /// Get the <see cref="IValueConverter"/> for a given type
        /// </summary>
        /// <param name="type"><see cref="Type"/> to get for</param>
        /// <returns><see cref="IValueConverter"/> for the <see cref="Type"/></returns>
        IValueConverter GetConverterFor(Type type);
    }
}
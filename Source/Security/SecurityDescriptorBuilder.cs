﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.Security
{
    /// <summary>
    /// Defines a builder for building a <see cref="ISecurityDescriptor"/>
    /// </summary>
    public class SecurityDescriptorBuilder : ISecurityDescriptorBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SecurityDescriptorBuilder"/>
        /// </summary>
        /// <param name="descriptor">The <see cref="ISecurityDescriptor"/> we are building</param>
        public SecurityDescriptorBuilder(ISecurityDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

#pragma warning disable 1591 // Xml Comments
        public ISecurityDescriptor Descriptor { get; private set; } 
#pragma warning restore 1591 // Xml Comments
    }
}

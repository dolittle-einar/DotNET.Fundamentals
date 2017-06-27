﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Reflection;

namespace doLittle.Assemblies
{
    /// <summary>
    /// Defines a system that can provide assemblies
    /// </summary>
    public interface ICanProvideAssemblies
    {
        /// <summary>
        /// Get available assemblies that can be provided
        /// </summary>
        /// <returns></returns>
        IEnumerable<AssemblyInfo> AvailableAssemblies { get; }

        /// <summary>
        /// Get a specific assembly based on its <see cref="AssemblyInfo"/>
        /// </summary>
        /// <param name="assemblyInfo"><see cref="AssemblyInfo"/> for the assembly</param>
        /// <returns>Loaded <see cref="Assembly"/></returns>
        Assembly Get(AssemblyInfo assemblyInfo);
    }
}

﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Collections;
using Dolittle.Reflection;

namespace Dolittle.Mapping
{
    /// <summary>
    /// Represents an implementation of <see cref="IMapper"/>
    /// </summary>
    public class Mapper : IMapper
    {
        IMaps _maps;
        IMappingTargets _mappingTargets;

        /// <summary>
        /// Initializes a new instance of <see cref="Mapper"/>
        /// </summary>
        /// <param name="maps"><see cref="IMaps"/> for getting <see cref="IMap"/></param>
        /// <param name="mappingTargets"><see cref=" IMappingTargets"/> to use for getting <see cref="IMappingTarget"/></param>
        public Mapper(IMaps maps, IMappingTargets mappingTargets)
        {   
            _maps = maps;
            _mappingTargets = mappingTargets;
        }

        /// <inheritdoc/>
        public bool CanMap<TTarget, TSource>()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public TTarget Map<TTarget, TSource>(TSource source)
        {
            var map = _maps.GetFor(typeof(TSource), typeof(TTarget));
            var mappingTarget = _mappingTargets.GetFor(typeof(TTarget));

            var target = Activator.CreateInstance<TTarget>();

            map.Properties.ForEach(p => p.Strategy.Perform(mappingTarget, target, p.From.GetValue(source)));

            return target;
        }

        /// <inheritdoc/>
        public void MapToInstance<TTarget, TSource>(TSource source, TTarget target)
        {

        }
    }
}

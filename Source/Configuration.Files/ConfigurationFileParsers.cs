/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.DependencyInversion;
using Dolittle.Types;

namespace Dolittle.Configuration.Files
{
    /// <summary>
    /// Represents an implementation of <see creF="IConfigurationFileParsers"/>
    /// </summary>
    public class ConfigurationFileParsers : IConfigurationFileParsers
    {
        readonly ITypeFinder _typeFinder;
        readonly IEnumerable<ICanParseConfigurationFile> _parsers;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigurationFileParsers"/>
        /// </summary>
        /// <param name="typeFinder"><see cref="ITypeFinder"/> to use for finding parsers</param>
        /// <param name="container"><see cerf="IContainer"/> used to get instances</param>
        public ConfigurationFileParsers(ITypeFinder typeFinder, IContainer container)
        {
            _typeFinder = typeFinder;
            _parsers = typeFinder
                        .FindMultiple<ICanParseConfigurationFile>()
                        .Select(_ => container.Get(_) as ICanParseConfigurationFile);
        }

        /// <inheritdoc/>
        public object Parse(Type type, string filename, string content)
        {
            var parsers = _parsers.Where(_ => _.CanParse(type, filename, content)).ToArray();
            ThrowIfMultipleParsersForConfigurationFile(filename, parsers);
            ThrowIfMissingParserForConfigurationFile(filename, parsers);

            var parser = parsers.Single();
            return parser.Parse(type, filename, content);
        }

        void ThrowIfMultipleParsersForConfigurationFile(string filename, ICanParseConfigurationFile[] parsers)
        {
            if (parsers.Length > 1) throw new MultipleParsersForConfigurationFile(filename);
        }

        void ThrowIfMissingParserForConfigurationFile(string filename, ICanParseConfigurationFile[] parsers)
        {
            if (parsers.Length == 0) throw new MissingParserForConfigurationFile(filename);
        }
    }
}
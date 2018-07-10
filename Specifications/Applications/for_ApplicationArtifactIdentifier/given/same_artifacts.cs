﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Artifacts;
using Machine.Specifications;
using Moq;

namespace Dolittle.Applications.Specs.for_ApplicationArtifactIdentifier.given
{
    public class same_artifacts
    {
        protected static ApplicationArtifactIdentifier identifier_a;
        protected static ApplicationArtifactIdentifier identifier_b;

        Establish context = () =>
        {
            var application = Application.WithName("ApplicationName")
                .WithStructureStartingWith<BoundedContext>(bc => bc.Required)
                .Build();

            var boundedContext = new BoundedContext("BoundedContext");
            var location = new ApplicationLocation(new IApplicationLocationSegment[] 
            {
                boundedContext
            });

            var artifactType = new MyArtifactType("ArtifactType");

            var artifact = new Artifact("Artifact", artifactType, 1);

            identifier_a = new ApplicationArtifactIdentifier(application, location, artifact);
            identifier_b = new ApplicationArtifactIdentifier(application, location, artifact);
        };
    }
}

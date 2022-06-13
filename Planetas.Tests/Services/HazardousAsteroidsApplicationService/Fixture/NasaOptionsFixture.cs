﻿using Microsoft.Extensions.Options;
using Moq;
using Planetas.Infrastructure.Options;

namespace Planetas.ApplicationCore.Tests.Services.HazardousAsteroidsApplication.Fixture
{
    public class NasaOptionsFixture
    {
        public IOptions<NasaApiOptions> NasaApiOptions { get; }

        public NasaOptionsFixture()
        {
            var nasaOptions = new Mock<IOptions<NasaApiOptions>>();

            nasaOptions.SetupGet(opt => opt.Value)
                .Returns(new NasaApiOptions { ApiKey = "test", Url = "http://localhost" });

            NasaApiOptions = nasaOptions.Object;
        }
    }
}

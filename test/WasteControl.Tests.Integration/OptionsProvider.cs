using Microsoft.Extensions.Configuration;
using WasteControl.Infrastructure.DAL;

namespace WasteControl.Tests.Integration
{
    public class OptionsProvider
    {
        private readonly IConfiguration _configuration;

        public OptionsProvider()
        {
            _configuration = GetConfigurationRoot();
        }

        public T Get<T>(string sectionName) where T : class, new() =>
            _configuration.GetOptions<T>(sectionName);

        private static IConfigurationRoot GetConfigurationRoot()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Integration.json")
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }
    }


}
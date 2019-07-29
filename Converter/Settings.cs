using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Converter
{
    class Settings
    {
        private readonly IConfigurationRoot _configuration;

        public Settings()
        {
            var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            _configuration = configurationBuilder.Build();
        }

        public  (string pathToLoad, string pathToSave) GetFilePathValues()
        {
            var pathToLoad = _configuration.GetSection("FilePath:pathToOpen").Value ?? throw new ArgumentNullException(
                                 $"Configuration.GetSection(\"FilePath:pathToOpen\").Value");
            var pathToSave = _configuration.GetSection("FilePath:pathToSave").Value ?? throw new ArgumentNullException(
                                 $"Configuration.GetSection(\"FilePath:pathToSave\").Value");

            return (pathToLoad, pathToSave);
        }

        public string GetFileFormats()
        {
            return _configuration.GetSection("FileFormats:formats").Value ?? throw new ArgumentNullException(
                           $"Configuration.GetSection(\"FileFormats:formats\").Value");
        }
    }
}

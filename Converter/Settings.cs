using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Converter
{
    class PathToOpenEmptyException : Exception
    {
        private string _innerMessage;
        public override string Message { get; } = $"PathToOpen from json can't be empty or null. Description:";

        public PathToOpenEmptyException(string message) => _innerMessage = message;
    }
    class PathToSaveEmptyException : Exception { }


    class Settings
    {
        private readonly IConfigurationRoot _configuration;

        public Settings() => _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public  (string pathToLoad, string pathToSave) GetFilePathValues()
        {
            // null coalescing operator
            var pathToLoad = _configuration.GetSection("FilePath:pathToOpen").Value ?? throw new PathToOpenEmptyException("gre");
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

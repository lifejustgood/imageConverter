using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ImageMagick;
using Microsoft.Extensions.Configuration;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings();
            var converter = new ImageConverter();

            var path = settings.GetFilePathValues();
            var format = settings.GetFileFormats();

            converter.ConvertImagesToGif(path.pathToLoad, path.pathToSave, format);
        }
    }
}

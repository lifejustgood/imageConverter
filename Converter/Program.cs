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
            try
            {
                var settings = new Settings();

                var path = settings.GetFilePathValues();
                var format = settings.GetFileFormats();

                ImageConverter.ConvertImagesToGif(path.pathToLoad, path.pathToSave, format);
            }
            // pattern matching
            catch (Exception e)
            {
                /*switch(e)

                {
                    case e is PathToOpenEmptyException:
                }*/
                    

                Console.WriteLine(e.Message);
            }
        }
    }
}

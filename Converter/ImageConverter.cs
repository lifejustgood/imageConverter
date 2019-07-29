using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ImageMagick;

namespace Converter
{
    class ImageConverter
    {
        public void ConvertImagesToGif(string pathToLoad, string pathToSave, string imageFormats)
        {
            using (MagickImageCollection collection = new MagickImageCollection())
            {
                var files = Directory.GetFiles(pathToLoad).Where(file => Regex.IsMatch(file.ToLower(), @"^.+\.(" + imageFormats + ")$")).ToList();

                if (files.Count == 0)
                {
                    throw new Exception($"There are no files in folder with {imageFormats} extensions");
                }

                files.ForEach(elem => collection.Add(elem));

                collection.ToList().ForEach(r => r.AnimationDelay = 50);

                // Optionally reduce colors
                var settings = new QuantizeSettings { Colors = 256 };
                collection.Quantize(settings);

                ResizeImages(collection);

                // Optionally optimize the images (images should have the same size).
                collection.Optimize();

                // Save gif
                collection.Write(pathToSave + DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt") + ".gif");
            }
        }

        private MagickImageCollection ResizeImages(MagickImageCollection collection, int imageSize = 800)
        {
            collection.Coalesce();

            // Resize each image in the collection to a width of 200. When zero is specified for the height
            // the height will be calculated with the aspect ratio.
            foreach (MagickImage image in collection)
            {
                image.Resize(imageSize, 0);
            }

            return collection;
        }
    }
}

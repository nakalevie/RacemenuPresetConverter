using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RacemenuPresetConverter.app;
using RacemenuPresetConverter.Models;

namespace RacemenuPresetConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputJson = "";
            var diffWeights = false;
            float divider = 0;

            if (args.Count() > 0)
            {
                inputJson = args[0];
                if (args.Count() > 1)
                {
                    diffWeights = args[1].ToLower() == "yes";
                }
                if (args.Count() > 1)
                {
                    float.TryParse(args[2].Replace(".", ","), out divider);
                    if (divider == 0)
                    {
                        Console.WriteLine("Can't parse divider value");
                        divider = 1;
                    }
                }
            }

            if (string.IsNullOrEmpty(inputJson))
            {
                Console.WriteLine("No input file specified");
                return;
            }
            else if(!File.Exists(inputJson))
            {
                Console.WriteLine($"The specified file does not exist: {inputJson}");
                return;
            }

            var inputPreset = JsonConvert.DeserializeObject<Preset>(File.ReadAllText(inputJson));
            var converter = new PresetConverter(System.Configuration.ConfigurationManager.AppSettings["bodyBaseType"]);
            var presetName = Path.GetFileName(inputJson);
            var outputPreset = converter.ConvertToXML(inputPreset, presetName, diffWeights, divider);
            if (!Directory.Exists("exported"))
            {
                Directory.CreateDirectory("exported");
            }
            var outputFile = $"{"exported"}/{presetName.Replace("json", "xml")}";
            File.WriteAllText(outputFile, outputPreset.ToString());

            Console.WriteLine($"Done! Preset saved at: {outputFile}");
        }
    }
}

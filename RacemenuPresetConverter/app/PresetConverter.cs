using Newtonsoft.Json;
using RacemenuPresetConverter.Models;
using System;
using System.Reflection;
using System.Xml.Linq;

namespace RacemenuPresetConverter.app
{
    public class PresetConverter
    {
        public string BodyType { get; set; }

        public PresetConverter(string bodyType)
        {
            BodyType = bodyType;
        }

        public XDocument ConvertToXML(Preset inputPreset, string presetName, bool diffWeights = false, float divider = 2)
        {
            XElement sliderPresets = new XElement("SliderPresets",
                new XElement("Preset",
                    new XAttribute("name", presetName.Replace(".json", "")),
                    new XAttribute("set", BodyType)
                )
            );

            Type type = inputPreset.Morphs.GetType();

            foreach (PropertyInfo property in type.GetProperties())
            {
                var floatVal = ((MorphValue)property.GetValue(inputPreset.Morphs)).Value;
                var value = Math.Ceiling(floatVal * 100);
                if (value == 0)
                    continue;

                var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();

                XElement setSlider1 = new XElement("SetSlider",
                    new XAttribute("name", attribute != null ? attribute.PropertyName : property.Name),
                    new XAttribute("size", "small"),
                    new XAttribute("value", diffWeights ? (int)Math.Ceiling(value / divider) : value)
                );
                sliderPresets.Element("Preset").Add(setSlider1);

                XElement setSlider2 = new XElement("SetSlider",
                   new XAttribute("name", property.Name),
                   new XAttribute("size", "big"),
                   new XAttribute("value", value)
                );
                sliderPresets.Element("Preset").Add(setSlider2);
            }

            return new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), sliderPresets);
        }
    }
}

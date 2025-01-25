using Newtonsoft.Json;

namespace RacemenuPresetConverter.Models
{
    public class Preset
    {
        [JsonProperty("morphs")]
        public BBBMorphs Morphs { get; set; }
    }
}

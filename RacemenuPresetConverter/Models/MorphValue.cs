using Newtonsoft.Json;

namespace RacemenuPresetConverter.Models
{
    public class MorphValue
    {
        [JsonProperty("value")]
        public float Value { get; set; }
    }
}

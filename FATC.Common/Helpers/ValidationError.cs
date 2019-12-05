using Newtonsoft.Json;

namespace FATC.Common.Helpers
{
    public class ValidationError
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}

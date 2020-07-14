using Newtonsoft.Json;

namespace ProjectDiba.Game.Charts
{
    public class Section
    {
        [JsonIgnore]
        public double StartPointMilliseconds { get; set; }

        [JsonIgnore]
        public double EndPointMilliseconds { get; set; }

        /// <summary>
        /// The start point of this section.
        /// </summary>
        [JsonProperty("start")]
        public Time StartPoint { get; set; }

        /// <summary>
        /// The end point of this section.
        /// </summary>
        [JsonProperty("end")]
        public Time EndPoint { get; set; }
    }
}

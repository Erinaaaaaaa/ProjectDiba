using Newtonsoft.Json;

namespace ProjectDiba.Game.Charts
{
    public class Song
    {
        public string Title { get; set; }
        public string TitleOriginal { get; set; }

        public string Artist { get; set; }
        public string ArtistOriginal { get; set; }

        public string Source { get; set; }
        public string SourceOriginal { get; set; }

        public double OffsetToFirstBeat { get; set; }
        public TimingPoint[] TimingPoints { get; set; }

        [JsonIgnore]
        public Chart[] Charts { get; set; }
    }
}

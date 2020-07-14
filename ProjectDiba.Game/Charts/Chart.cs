namespace ProjectDiba.Game.Charts
{
    public class Chart
    {
        public float Rating { get; set; } // Rating should be used for difficulty color
        public string Label { get; set; }
        public string Creator { get; set; }

        public Section ChanceTime { get; set; }
        public Section[] TechnicalZones { get; set; }

        public Note[] Notes { get; set; }
    }
}

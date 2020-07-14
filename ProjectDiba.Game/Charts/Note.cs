using System;
using Newtonsoft.Json;
using osuTK;

namespace ProjectDiba.Game.Charts
{
    public enum NoteShape
    {
        Triangle,
        Square,
        Cross,
        Circle,
        Star
    }

    [Flags]
    public enum NoteType
    {
        Simple = 0,
        Double = 1 << 0,
        // Hold = 1 << 1,
    }

    public class Note
    {
        [JsonIgnore]
        public double Milliseconds { get; set; }

        [JsonIgnore]
        public double? EndMilliseconds { get; set; }

        public Vector2 Position { get; set; }
        public NoteShape Shape { get; set; }
        public NoteType Type { get; set; }
        public Time Time { get; set; }
        public Time? EndTime { get; set; } // Applicable to hold notes only.

        public float EntryAngle { get; set; } = 0;
        public float Frequency { get; set; } = 2;
        public float Amplitude { get; set; } = 500;
        public float Distance { get; set; } = 1200;
    }
}

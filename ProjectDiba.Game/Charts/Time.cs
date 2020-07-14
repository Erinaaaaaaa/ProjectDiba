using System;
using Newtonsoft.Json;

namespace ProjectDiba.Game.Charts
{
    public readonly struct Time : IComparable<Time>, IEquatable<Time>
    {
        [JsonProperty("measure")]
        public int Measure { get; }

        [JsonProperty("beat")]
        public int Beat { get; }

        [JsonProperty("step")]
        public int Step { get; }

        public override string ToString() => $"{Measure}:{Beat}.{Step:000}";

        #region Constructors

        public Time(int measure = 1, int beat = 1, int step = 0)
        {
            Measure = measure;
            Beat = beat;
            Step = step;
        }

        #endregion

        public int CompareTo(Time other)
        {
            if (Measure < other.Measure) return -1;
            if (Measure > other.Measure) return +1;

            if (Beat < other.Beat) return -1;
            if (Beat > other.Beat) return +1;

            if (Step < other.Step) return -1;
            if (Step > other.Step) return +1;

            return 0;
        }

        public bool Equals(Time other)
        {
            return Measure == other.Measure &&
                   Beat == other.Beat &&
                   Step == other.Step;
        }

        public override bool Equals(object obj)
        {
            return obj is Time other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Measure, Beat, Step);
        }

        #region Operators

        public static bool operator <(Time left, Time right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Time left, Time right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Time left, Time right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Time left, Time right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}

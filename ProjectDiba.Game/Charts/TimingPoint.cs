using System;
using Newtonsoft.Json;

namespace ProjectDiba.Game.Charts
{
    public class TimingPoint
    {
        [JsonIgnore]
        public double Milliseconds;

        [JsonProperty("position")]
        public Time Position;

        [JsonProperty("signature")]
        public TimeSignature Signature;

        [JsonProperty("tempo")]
        public double Tempo;

        [JsonIgnore]
        public double BeatLength => (60_000 / Tempo) / (Signature.Denominator / 4D);

        public double GetBeats(Time start, Time end)
        {
            if (end < start)
                return -GetBeats(end, start);

            var measures = end.Measure - start.Measure;
            var beats = end.Beat - start.Beat;
            var steps = end.Step - start.Step;

            return measures * Signature.Numerator + beats + steps / 192D;
        }

        public double GetLengthMilliseconds(Time start, Time end) => BeatLength * GetBeats(start, end);

        public double GetBeats(double milliseconds) => milliseconds / BeatLength;

        public Time AddBeats(Time time, double beats)
        {
            int wholeBeats = Convert.ToInt32(Math.Truncate(beats));
            var addedSteps = Convert.ToInt32((beats - wholeBeats) * 192);

            var addedMeasures = Math.DivRem(wholeBeats, Signature.Numerator, out var addedBeats);

            var newMeasure = time.Measure + addedMeasures;
            var newBeat = time.Beat + addedBeats;
            var newStep = time.Step + addedSteps;

            if (newStep > 192)
            {
                newBeat++;
                newStep -= 192;
            }

            if (newBeat > Signature.Numerator)
            {
                newMeasure++;
                newBeat -= Signature.Numerator;
            }

            return new Time(newMeasure, newBeat, newStep);
        }
    }
}

namespace ProjectDiba.Game.Charts
{
    public class TimeSignature
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public override string ToString() => $"{Numerator}/{Denominator}";
    }
}

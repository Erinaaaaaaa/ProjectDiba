namespace ProjectDiba.Game.Scoring
{
    public struct Hit
    {
        public Judgement Judgement { get; set; }
        public double OffsetMilliseconds { get; set; }
        public bool CorrectButton { get; set; }
        public SampleType Sample { get; set; }
        public int Bonus { get; set; }
    }
}

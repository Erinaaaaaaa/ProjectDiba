using System;

namespace ProjectDiba.Game.Scoring
{
    public class TimingWindows
    {
        public static TimingWindows Diba => new TimingWindows
        {
            Miss = 450,
            Sad = 350,
            Safe = 250,
            Fine = 150,
            Cool = 75,
            CoolPlus = 8
        };

        public double CoolPlus { get; set; }
        public double Cool { get; set; }
        public double Fine { get; set; }
        public double Safe { get; set; }
        public double Sad { get; set; }
        public double Miss { get; set; }

        public double Get(Judgement type)
            => type switch
            {
                Judgement.Miss => Miss,
                Judgement.Sad => Sad,
                Judgement.Safe => Safe,
                Judgement.Fine => Fine,
                Judgement.Cool => Cool,
                Judgement.CoolPlus => CoolPlus,
                _ => throw new ArgumentException($"Invalid judgement type: {type:D}", nameof(type))
            };
    }
}

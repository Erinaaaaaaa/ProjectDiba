using osu.Framework.Timing;

namespace ProjectDiba.Game.Scoring
{
    public class DibaScoreManager : ScoreManager
    {
        public DibaScoreManager(IClock clock)
            : base(clock)
        {
        }

        public override TimingWindows TimingWindows => TimingWindows.Diba;
    }
}

using osu.Framework.Platform;
using osu.Framework;
using ProjectDiba.Game;

namespace ProjectDiba.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"ProjectDiba"))
            using (osu.Framework.Game game = new ProjectDibaGame())
                host.Run(game);
        }
    }
}

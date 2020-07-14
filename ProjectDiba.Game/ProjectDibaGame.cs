using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using ProjectDiba.Game.Screens;

namespace ProjectDiba.Game
{
    public class ProjectDibaGame : ProjectDibaGameBase
    {
        private ScreenStack screenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            Children = new Drawable[]
            {
                new Container()
                {
                    RelativeSizeAxes = Axes.Both,
                    Child = screenStack = new ScreenStack
                    {
                        RelativeSizeAxes = Axes.Both
                    }
                },
            };
            Host.Window.Title = "Project DIBA";
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            screenStack.Push(new MainScreen());
        }
    }
}

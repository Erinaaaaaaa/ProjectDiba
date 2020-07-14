using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;
using osuTK;
using ProjectDiba.Game.Controls;

namespace ProjectDiba.Game.Tests.Visual.Controls
{
    public class TestSceneSlantedContainer : TestScene
    {
        public TestSceneSlantedContainer()
        {
            var sc = new SlantedContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Width = 400,
                Background = new Box()
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Colour4.Blue
                },
                Child = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Colour4.Red
                }
            };

            Add(sc);

            AddSliderStep("Height (via Height)", 10f, 500f, 100f, f => sc.Height = f);
            AddSliderStep("Height (via Size)", 10f, 500f, 100f, f => sc.Size = new Vector2(sc.Width, f));
        }
    }
}

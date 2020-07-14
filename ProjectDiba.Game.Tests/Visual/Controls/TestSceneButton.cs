using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Logging;
using osu.Framework.Testing;
using ProjectDiba.Game.Controls;

namespace ProjectDiba.Game.Tests.Visual.Controls
{
    public class TestSceneButton : TestScene
    {
        public TestSceneButton()
        {
            var txt = new SpriteText
            {
                Colour = Colour4.Black,
                Text = "Ayaya",
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
            };

            var btn = new SlantedButton
            {
                AutoSizeAxes = Axes.Y,
                Width = 200,
                Action = () => Logger.Log("clicked!"),
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Child = new Container
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Padding = new MarginPadding(8),
                    Child = txt
                }
            };

            Add(btn);

            if (!btn.AutoSizeAxes.HasFlag(Axes.X))
                AddSliderStep("Width", 100f, 500f, 200f, f => btn.Width = f);
            if (!btn.AutoSizeAxes.HasFlag(Axes.Y))
                AddSliderStep("Height", 100f, 500f, 200f, f => btn.Height = f);

            AddSliderStep("Text Size", 16f, 64f, 32f, f => txt.Font = txt.Font.With(size: f));
        }
    }
}

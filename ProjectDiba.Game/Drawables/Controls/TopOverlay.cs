using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;

namespace ProjectDiba.Game.Controls
{
    public class TopOverlay : CompositeDrawable
    {
        public Bindable<string> Title => headerTextSprite.Current;

        private readonly SpriteText headerTextSprite;

        public TopOverlay()
        {
            InternalChildren = new Drawable[]
            {
                new Container
                {
                    Alpha = 0.6f,
                    Name = "Background",
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = Colour4.Black,
                        },
                        new Container
                        {
                            X = -6,
                            Anchor = Anchor.CentreRight,
                            Origin = Anchor.CentreRight,
                            AutoSizeAxes = Axes.Both,
                            Child = new SpriteText
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Text = "Project DIBA",
                                Font = FontUsage.Default.With("Overpass-Light", 30),
                                Rotation = 2.5f,
                                UseFullGlyphHeight = true,
                            },
                        }
                    }
                },
                headerTextSprite = new SpriteText
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    Font = FontUsage.Default.With("Overpass-Bold", 28),
                    Current = new Bindable<string>("Main Menu"),
                    X = 6
                }
            };
        }
    }
}

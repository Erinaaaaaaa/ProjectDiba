using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.OpenGL.Textures;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace ProjectDiba.Game.Controls
{
    public class SlantedButton : ClickableContainer
    {
        private SlantedContainer content;

        protected override Container<Drawable> Content => content;

        public new Axes AutoSizeAxes
        {
            get => base.AutoSizeAxes;
            set
            {
                base.AutoSizeAxes = value;

                content.AutoSizeAxes = Axes.None;

                switch (value)
                {
                    case Axes.None:
                        content.RelativeSizeAxes = Axes.Both;
                        break;

                    case Axes.X:
                        content.RelativeSizeAxes = Axes.Y;
                        break;

                    case Axes.Y:
                        content.RelativeSizeAxes = Axes.X;
                        break;

                    case Axes.Both:
                        content.RelativeSizeAxes = Axes.None;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                content.AutoSizeAxes = value;
            }
        }

        public SlantedButton()
        {
            InternalChild = content = new SlantedContainer()
            {
                CornerRadius = 16f,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                AutoSizeAxes = Axes.Both,
                BorderColour = Colour4.Aqua.Darken(1f),
                BorderThickness = 8f,
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore tex)
        {
            content.Background = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Children = new[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.White,
                    },
                    new Sprite
                    {
                        RelativeSizeAxes = Axes.Both,
                        Texture = tex.Get("UI/dot_pattern.png", WrapMode.Repeat, WrapMode.Repeat),
                        TextureRelativeSizeAxes = Axes.None,
                        TextureRectangle = new RectangleF(0, 0, 12, 12)
                    },
                },
            };
        }
    }
}

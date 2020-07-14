using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Layout;
using osuTK;
using ProjectDiba.Game.Utils;

namespace ProjectDiba.Game.Controls
{
    public class SlantedContainer : SlantedContainer<Drawable, Drawable>
    {
    }

    public class SlantedContainer<TBackground, TContent> : Container<TContent>
        where TBackground : Drawable
        where TContent : Drawable
    {
        private readonly Container<TContent> content;
        private readonly Container<TBackground> background;

        protected override Container<TContent> Content => content;

        public TBackground Background
        {
            get => background.Child;
            set => background.Child = value;
        }

        public override float Height
        {
            get => base.Height;
            set
            {
                base.Height = value;

                //Invalidate(Invalidation.DrawSize);
            }
        }

        public override Vector2 Size
        {
            get => base.Size;
            set
            {
                base.Size = value;

                //Invalidate(Invalidation.DrawSize);
            }
        }

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

        public new bool Masking => true;

        public SlantedContainer()
        {
            Shear = Constants.Shear;
            base.Masking = true;

            InternalChildren = new Drawable[]
            {
                background = new Container<TBackground>
                {
                    Name = "Background",
                    Shear = -Constants.Shear,
                    RelativeSizeAxes = Axes.Both,
                    Size = Vector2.One
                },
                content = new Container<TContent>
                {
                    Name = "Content",
                    Shear = -Constants.Shear,
                }
            };
        }

        protected override void LoadComplete()
        {
            AutoSizeAxes = base.AutoSizeAxes;
        }

        protected override bool OnInvalidate(Invalidation invalidation, InvalidationSource source)
        {
            if (invalidation.HasFlag(Invalidation.DrawSize) || invalidation.HasFlag(Invalidation.Layout))
            {
                content.Padding = new MarginPadding { Right = DrawHeight * Shear.X };
                background.Padding = new MarginPadding { Left = -DrawHeight * Shear.X };
            }

            return base.OnInvalidate(invalidation, source);
        }
    }
}

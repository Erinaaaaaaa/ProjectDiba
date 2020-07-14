using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Lines;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Logging;
using osuTK;
using ProjectDiba.Game.Charts;

namespace ProjectDiba.Game.Drawables.Game
{
    public class DrawableNote : CompositeDrawable
    {
        private readonly Note note;

        public DrawableNote(Note note)
        {
            this.note = note;
        }

        public BindableFloat Progression { get; } = new BindableFloat { MinValue = 0, Default = 0 };

        private Container melodyContainer;
        private Sprite melodyIcon;
        private Container trailContainer;
        private Container trailSubContainer;
        private Path trail;

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            var tex = note.Shape switch
            {
                NoteShape.Triangle => textures.Get("Game/Notes/triangle.png"),
                NoteShape.Square => textures.Get("Game/Notes/square.png"),
                NoteShape.Cross => textures.Get("Game/Notes/cross.png"),
                NoteShape.Circle => textures.Get("Game/Notes/circle.png"),
                NoteShape.Star => textures.Get("Game/Notes/circle.png"),
                _ => null,
            };

            InternalChildren = new Drawable[]
            {
                trailContainer = new Container()
                {
                    Anchor = Anchor.Centre,
                    AutoSizeAxes = Axes.Both,
                    Child = trailSubContainer = new Container()
                    {
                        AutoSizeAxes = Axes.Both,
                        Child = trail = new SmoothPath()
                        {
                            Anchor = Anchor.TopLeft,
                            X = -4, Y = -4,
                            PathRadius = 4,
                            Colour = ColourInfo.GradientHorizontal(Colour4.White, Colour4.White.Opacity(0))
                        }
                    }
                },
                melodyContainer = new Container()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(64),
                    Children = new Drawable[]
                    {
                        melodyIcon = new Sprite
                        {
                            Texture = tex,
                            Size = new Vector2(64),
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                        },
                    }
                },
            };

            Progression.ValueChanged += (e) =>
            {
                Alpha = MathF.Min(e.NewValue * 1 / (0.15f), 1);
                melodyContainer.Position = calculatePoint(e.NewValue);

                var list = new List<Vector2>();

                for (var f = e.NewValue; f >= e.NewValue - 0.21f; f -= 0.05f)
                    list.Add(calculatePoint(f, rotate: false));

                var tlc = getTopLeftCorner(list, new Vector2(float.MaxValue));
                trail.Vertices = offsetPoints(list, -tlc).ToList();
                trailSubContainer.Position = tlc;
                trail.Rotation = note.EntryAngle - 90;
            };
        }

        private Vector2 getTopLeftCorner(IEnumerable<Vector2> list, Vector2 seed = default)
        {
            var v2 = seed;

            foreach (var point in list)
            {
                if (v2.X > point.X) v2.X = point.X;
                if (v2.Y > point.Y) v2.Y = point.Y;
            }

            Logger.Log(v2.ToString());

            return v2;
        }

        private IEnumerable<Vector2> offsetPoints(IEnumerable<Vector2> input, Vector2 offset)
            => input.Select(point => point + offset);

        private Vector2 calculatePoint(float progression, bool compensate = true, bool rotate = true)
        {
            var distanceCompensatedProgression = progression * note.Distance;

            var position = MathF.Sin(progression * (MathF.PI * note.Frequency)) * note.Amplitude * (540 / 6500f);

            var v2 = -new Vector2(distanceCompensatedProgression, position);

            var quat = Quaternion.FromEulerAngles(0, 0, (note.EntryAngle - 90) * (MathF.PI / 180));

            if (rotate)
                v2 = Vector2.Transform(v2, quat);

            if (compensate)
            {
                var receptorCompensation = calculatePoint(1, false, rotate);

                v2 -= receptorCompensation;
            }

            return v2;
        }
    }
}

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;
using osuTK;
using ProjectDiba.Game.Charts;
using ProjectDiba.Game.Drawables.Game;

namespace ProjectDiba.Game.Tests.Visual.GameDrawables
{
    public class TestSceneNote : TestScene
    {
        public TestSceneNote()
        {
            var note = new Note()
            {
                Shape = NoteShape.Circle,
                Type = NoteType.Simple,
            };

            var dNote = new DrawableNote(note)
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Size = new Vector2(64)
            };

            Add(new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.White.Darken(2f)
            });

            Add(new DrawSizePreservingFillContainer
            {
                RelativeSizeAxes = Axes.Both,
                TargetDrawSize = new Vector2(1920, 1080),
                Child = dNote
            });

            // DrawableNote related
            AddSliderStep("Progression", 0f, 2, 1, f => dNote.Progression.Value = f);

            // Note related
            AddSliderStep("Entry angle", 0f, 360, 90, f =>
            {
                note.EntryAngle = f;
                dNote.Progression.TriggerChange();
            });

            AddSliderStep("Frequency", 0, 24, 2, f =>
            {
                note.Frequency = f;
                dNote.Progression.TriggerChange();
            });

            AddSliderStep("Amplitude", -6500f, 6500, 500, f =>
            {
                note.Amplitude = f;
                dNote.Progression.TriggerChange();
            });

            AddSliderStep("Distance", 100f, 5000, 1200, f =>
            {
                note.Distance = f;
                dNote.Progression.TriggerChange();
            });

            var animDuration = 2500D;

            AddSliderStep("Animation duration", 1000D, 10000D, 2500D, d => animDuration = d);

            AddStep("Animate", () =>
            {
                dNote.TransformBindableTo(dNote.Progression, 0).TransformBindableTo(dNote.Progression, 2f, animDuration);
            });
        }
    }
}

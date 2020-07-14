using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osuTK;
using ProjectDiba.Resources;

namespace ProjectDiba.Game
{
    public class ProjectDibaGameBase : osu.Framework.Game
    {
        // Anything in this class is shared between the test browser and the game implementation.
        // It allows for caching global dependencies that should be accessible to tests, or changing
        // the screen scaling for all components including the test browser and framework overlays.

        protected override Container<Drawable> Content { get; }

        protected ProjectDibaGameBase()
        {
            // Ensure game and tests scale with window size and screen DPI.
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                // You may want to change TargetDrawSize to your "default" resolution, which will decide how things scale and position when using absolute coordinates.
                TargetDrawSize = new Vector2(1280, 720)
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new DllResourceStore(ProjectDibaResources.ResourceAssembly));

            // FONTS
            var hiresFonts = new FontStore(scaleAdjust: 200);
            Fonts.AddStore(hiresFonts);

            AddFont(Resources, @"Fonts/Overpass/Overpass");
            AddFont(Resources, @"Fonts/Overpass/Overpass-Bold");
            AddFont(Resources, @"Fonts/Overpass/Overpass-Italic");
            AddFont(Resources, @"Fonts/Overpass/Overpass-BoldItalic");
            AddFont(Resources, @"Fonts/Overpass/Overpass-Light", hiresFonts);
            AddFont(Resources, @"Fonts/Overpass/Overpass-Thin", hiresFonts);

            AddFont(Resources, @"Fonts/Noto/Noto");

            // TEXTURES
        }
    }
}

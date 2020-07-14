using System;
using osuTK;

namespace ProjectDiba.Game.Utils
{
    public static class Constants
    {
        /// <summary>
        /// Drawable shear that applies an angle of precisely 27° to the right.
        /// </summary>
        public static Vector2 Shear => new Vector2(MathF.Tan(0.4712389F), 0);
    }
}

using System.Collections.Generic;
using osu.Framework.Input;

namespace ProjectDiba.Game.Input
{
    public class JoystickConfig
    {
        public readonly IReadOnlyDictionary<JoystickButton, GameInput> GameInputs
            = new Dictionary<JoystickButton, GameInput>
            {
                { JoystickButton.Button3, GameInput.Triangle },
                { JoystickButton.Button4, GameInput.Square },
                { JoystickButton.Button1, GameInput.Cross },
                { JoystickButton.Button2, GameInput.Circle },

                { JoystickButton.FirstHatUp, GameInput.Up },
                { JoystickButton.FirstHatLeft, GameInput.Left },
                { JoystickButton.FirstHatDown, GameInput.Down },
                { JoystickButton.FirstHatRight, GameInput.Right },

                { JoystickButton.Button5, GameInput.Star1 },
                { JoystickButton.Button6, GameInput.Star2 },
            };
    }
}

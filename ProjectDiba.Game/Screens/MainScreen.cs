using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using ProjectDiba.Game.Input;
using ProjectDiba.Game.Scoring;

namespace ProjectDiba.Game.Screens
{
    public class MainScreen : Screen
    {
        private JoystickConfig config = new JoystickConfig();
        private DibaScoreManager mgr;

        public MainScreen()
        {
            InternalChild = new BasicButton()
            {
                Action = () => this.Push(new ControllerDisplayScreen()),
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "Ayaya"
            };
        }

        protected override void LoadComplete()
        {
            mgr = new DibaScoreManager(Clock);
        }

        protected override bool OnJoystickPress(JoystickPressEvent e)
        {
            if (config.GameInputs.TryGetValue(e.Button, out var gi))
            {
                mgr.RegisterHit(InputType.Pressed, gi);
                return true;
            }

            return false;
        }

        protected override void OnJoystickRelease(JoystickReleaseEvent e)
        {
            if (config.GameInputs.TryGetValue(e.Button, out var gi))
            {
                mgr.RegisterHit(InputType.Released, gi);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using osu.Framework.Bindables;
using osu.Framework.Logging;
using osu.Framework.Timing;
using ProjectDiba.Game.Input;

namespace ProjectDiba.Game.Scoring
{
    public abstract class ScoreManager
    {
        private readonly IClock clock;

        public Bindable<int> Score { get; }
        public Bindable<int> Combo { get; }

        public abstract TimingWindows TimingWindows { get; }

        public virtual Judgement MinimumJudgementForCombo => Judgement.Fine;
        public virtual bool WrongIsMiss => false;

        public virtual double DoublePressDelta => 100;

        private readonly IDictionary<GameInput, double> downSince = new Dictionary<GameInput, double>();

        protected ScoreManager(IClock clock)
        {
            this.clock = clock;
            Score = new BindableInt { MinValue = 0 };
            Combo = new BindableInt { MinValue = 0 };
        }

        public Hit RegisterHit(InputType inputType, GameInput gameInput)
        {
            var time = clock.CurrentTime;

            // Update currently held inputs
            switch (inputType)
            {
                case InputType.Pressed:
                    if (downSince.ContainsKey(gameInput) && !double.IsNaN(downSince[gameInput]))
                        Logger.Log($"{gameInput} is already down!", level: LogLevel.Debug);
                    downSince[gameInput] = time;
                    break;

                case InputType.Released:
                    if (downSince.ContainsKey(gameInput) && double.IsNaN(downSince[gameInput]))
                        Logger.Log($"{gameInput} is already up!", level: LogLevel.Debug);
                    downSince[gameInput] = double.NaN;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }

            var pressType = getPressType(gameInput, time);

            Logger.Log($"{gameInput} {inputType} @ {time}, {pressType}");

            return new Hit
            {
                Judgement = Judgement.CoolPlus,
                OffsetMilliseconds = TimingWindows.CoolPlus,
                CorrectButton = true,
            };
        }

        private PressType getPressType(GameInput input, double currentTime)
        {
            var opposite = input switch
            {
                GameInput.Triangle => GameInput.Up,
                GameInput.Square => GameInput.Left,
                GameInput.Cross => GameInput.Down,
                GameInput.Circle => GameInput.Right,
                GameInput.Up => GameInput.Triangle,
                GameInput.Left => GameInput.Square,
                GameInput.Down => GameInput.Cross,
                GameInput.Right => GameInput.Circle,
                GameInput.Star1 => GameInput.Star2,
                GameInput.Star2 => GameInput.Star1,
                _ => throw new ArgumentException($"{nameof(input)} is not a valid GameInput", nameof(input))
            };

            if (!downSince.ContainsKey(opposite) || double.IsNaN(downSince[opposite]))
                return PressType.Simple;

            if (currentTime - downSince[opposite] <= DoublePressDelta) return PressType.BonusDouble;

            return PressType.Double;
        }
    }
}

namespace SprejKontroll.Models
{
    public class MouseVelocityHandler
    {
        public Vector2 CurrentVelocity { get; private set; }

        private Vector2 _defaultVelocity;
        private Vector2 _defaultIncrease;

        private int _frame = 0;

        public MouseVelocityHandler(
            Vector2 defaultVelocity,
            Vector2 defaultVelocityIncrease)
        {
            _defaultVelocity = defaultVelocity;
            _defaultIncrease = defaultVelocityIncrease;
            CurrentVelocity = Vector2.Zero;
        }

        public void Reset()
        {
            _frame = 0;
            CurrentVelocity = Vector2.Zero;
        }

        public void Update()
        {
            if (CurrentVelocity == Vector2.Zero)
            {
                CurrentVelocity = new Vector2(
                    _defaultVelocity.X,
                    _defaultVelocity.Y);
            }

            _frame++;

            if (_frame > 80)
            {
                _frame = 0;
                CurrentVelocity.X += _defaultIncrease.X;
                CurrentVelocity.Y += _defaultIncrease.Y;
            }
        }

    }
}

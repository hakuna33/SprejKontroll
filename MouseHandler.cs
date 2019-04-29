using SprejKontroll.Models;
using WindowsInput;

namespace SprejKontroll
{
    public class MouseHandler
    {
        private InputSimulator _simulator = new InputSimulator();

        public MouseHandler()
        {
            _simulator = new InputSimulator();
        }

        public void MoveMouse(Vector2 delta)
        {
            _simulator.Mouse.MoveMouseBy(delta.X, delta.Y);
        }
    }
}

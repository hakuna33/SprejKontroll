using SprejKontroll.Models;
using System;
using System.Windows.Forms;

namespace SprejKontroll
{
    public partial class Form1 : Form
    {
        private MouseVelocityHandler _velocityHandler;
        private MouseHandler _mouseHandler = new MouseHandler();

        public Form1()
        {
            _velocityHandler = new MouseVelocityHandler(
                new Vector2(0, 5),
                new Vector2(0, 1));

            InitializeComponent();
            MouseEventListener.StartMouseEventListener(OnMouseEvent);
        }

        private void OnMouseEvent(bool button1Down, bool button2Down)
        {
            if (button1Down && button2Down)
            {
                _velocityHandler.Update();
            }
            else if (!button1Down)
            {
                _velocityHandler.Reset();
            }
        }
        
        private void TimerTick(object sender, EventArgs e)
        {
            var velocity = _velocityHandler.CurrentVelocity;
            if (velocity == Vector2.Zero)
            {
                return;
            }

            _mouseHandler.MoveMouse(velocity);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

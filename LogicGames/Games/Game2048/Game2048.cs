using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogicGames.Games.Game2048
{
    public partial class Game2048 : GameView
    {
        public Game2048() : base() 
        {
            this.Text = "2048";
            DoubleBuffered = true;
        }

        TimeSpan lastFrameTime = TimeSpan.Zero;
        Stopwatch frameTimer = Stopwatch.StartNew();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            TimeSpan currentFrameTime = frameTimer.Elapsed;
            float deltaTime = (float)(currentFrameTime - lastFrameTime).TotalSeconds;

            container.Location = new Point(ClientRectangle.Width / 2 - container.Width / 2, ClientRectangle.Height / 2 - container.Height / 2);
            e.Graphics.FillRectangle(new SolidBrush(Color.White), container);

            Render(e, deltaTime);

            lastFrameTime = currentFrameTime;
            Invalidate();
        }

        float xpos = 0;
        int speed = 500;
        protected void Render(PaintEventArgs e, float dt)
        {
            e.Graphics.TranslateTransform(base.container.X, base.container.Y);
            
            //example of animation
            xpos += dt*speed;
            if(xpos >= base.container.Width-100)
            {
                xpos = 0;
            }
            e.Graphics.DrawRectangle(new Pen(Color.Red, 2), xpos,0, 100,100);
        }
    }
}

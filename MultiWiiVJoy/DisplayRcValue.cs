using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiWiiVJoy
{
    public partial class DisplayRcValue : UserControl
    {
        private int rcValue = 1000;
        private bool centered = true;

        public int Value
        {
            get { return rcValue; }
            set
            {
                rcValue = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        public bool Centered
        {
            get { return centered; }
            set
            {
                centered = value;
                this.Invalidate();
            }
        }

        protected SolidBrush fillColor = new SolidBrush(Color.Gray);

        public DisplayRcValue()
        {
            InitializeComponent();
        }

        private void DisplayRcValue_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            int width = (int) ((double) (this.ClientSize.Width/1000D)*(double) (rcValue));
            int midX = this.ClientSize.Width/2;

            int x = 0;
            if (this.centered)
            {
                width = width/2;
                x = width >= 0 ? midX : midX - Math.Abs(width);
            }
            graphics.FillRectangle(fillColor, x, 0, Math.Abs(width), this.ClientSize.Height);
            TextRenderer.DrawText(graphics, Convert.ToString(rcValue), this.Font, new Point(midX, 0), Color.Black);
        }
    }
}
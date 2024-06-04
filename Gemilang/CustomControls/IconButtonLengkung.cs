using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.CustomControls
{
    public class IconButtonLengkung : IconButton
    {
        private int _borderRadius = 20;
        private int _borderSize = 2;
        private Color _borderColor = Color.PaleVioletRed;
        private int _iconMargin = 10; // Margin for the icon

        public IconButtonLengkung()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(200, 60);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.TextAlign = ContentAlignment.MiddleLeft; // Align text to the middle left
            UpdatePadding(); // Set initial padding
        }

        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; this.Invalidate(); }
        }

        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; this.Invalidate(); }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; this.Invalidate(); }
        }

        public int IconMargin
        {
            get { return _iconMargin; }
            set
            {
                _iconMargin = value;
                UpdatePadding(); // Adjust padding when margin changes
                this.Invalidate();
            }
        }

        private void UpdatePadding()
        {
            this.Padding = new Padding(_iconMargin + this.IconSize, 0, 0, 0);
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -_borderSize, -_borderSize);
            int smoothSize = _borderSize > 0 ? _borderSize : 1;

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, _borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, _borderRadius - _borderSize))
            using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
            using (Pen penBorder = new Pen(_borderColor, _borderSize))
            {
                this.Region = new Region(pathSurface);
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                if (_borderSize >= 1)
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += (s, ev) => this.Invalidate();
        }
    }
}

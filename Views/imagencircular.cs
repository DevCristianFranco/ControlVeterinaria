using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;



namespace CRUDWindFormsMVP.Views
{
    class imagencircular : PictureBox
    {
        //fields
        private int borderSize = 2;
        private Color borderColor = Color.RoyalBlue;
        private Color borderColor2 = Color.HotPink;
        private DashStyle borderLineStyle = DashStyle.Solid;
        private DashCap borderStyle = DashCap.Flat;
        private float gradientAngle = 50F;

        public imagencircular()
        {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        //Properties
        public int BorderSize
        {
            get
            {
                return borderSize;
            }

            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return borderColor;
            }

            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        public Color BorderColor2
        {
            get
            {
                return borderColor2;
            }

            set
            {
                borderColor2 = value;
                this.Invalidate();
            }
        }

        public DashStyle BorderLineStyle
        {
            get
            {
                return borderLineStyle;
            }

            set
            {
                borderLineStyle = value;
                this.Invalidate();
            }
        }

        public DashCap BorderStyle1
        {
            get
            {
                return borderStyle;
                this.Invalidate();
            }

            set
            {
                borderStyle = value;
                this.Invalidate();
            }
        }

        public float GradientAngle
        {
            get
            {
                return gradientAngle;
                this.Invalidate();
            }

            set
            {
                gradientAngle = value;
                this.Invalidate();
            }
        }

        //Overridden methods
        protected override void OnPaint(PaintEventArgs pe)
        {

            base.OnPaint(pe);
            //Fields
            var graph = pe.Graphics;
            var rectCountourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectCountourSmooth, -borderSize, -borderSize);
            var smoothSize = borderSize > 0 ? borderSize * 3 : 1;
            using (var borderGColor = new LinearGradientBrush(rectBorder, borderColor, borderColor2, gradientAngle))
            using (var pathRegion = new GraphicsPath())
            using (var penSmooth = new Pen(this.Parent.BackColor, smoothSize))
            using (var penBorder = new Pen(borderGColor, borderSize))
            {
                penBorder.DashStyle = borderLineStyle;
                penBorder.DashCap = borderStyle;
                pathRegion.AddEllipse(rectCountourSmooth);
                this.Region = new Region(pathRegion);
                graph.SmoothingMode = SmoothingMode.AntiAlias;

                //Drawing
                graph.DrawEllipse(penSmooth, rectCountourSmooth);
                if (borderSize > 0)
                    graph.DrawEllipse(penBorder, rectBorder);

            }
        } 
    }
}
        
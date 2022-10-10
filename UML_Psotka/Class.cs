using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UML_Psotka
{
    public class Class
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public int MinHeight { get; set; }

        public int MinWidth { get; set; }

        public bool Editable { get; set; }

        public int Width { get; set; }

        public string Name { get; set; }

        public bool isAbstract { get; set; }

        public HashSet<Property> Properties { get; set; } = new HashSet<Property>();

        public HashSet<Method> Methods { get; set; } = new HashSet<Method>();

        public List<string> Names = new List<string>();

        public enum accessModifiers
        {
            PUBLIC = '+',
            PRIVATE = '-',
            PROTECTED = '#',
        }


        public Class(int xPosition, int yPosition)
        {
            this.Name = "";
            this.X = xPosition;
            this.Y = yPosition;
            this.isAbstract = false;
            this.MinHeight = 100;
            this.MinWidth = 100;
            this.Width = MinWidth;
            this.Height = MinHeight;

        }


        public void Draw(Graphics g)
        {

            Font font;

            if (this.isAbstract)
                font = new Font("Arial", 10, FontStyle.Italic);
            else
                font = new Font("Arial", 10);

            Pen p = new Pen(Color.FromArgb(92, 149, 255));
            SolidBrush br = new SolidBrush(Color.FromArgb(185, 230, 255));

            if (this.Editable)
            {
                p = new Pen(Color.FromArgb(248, 117, 117));
                br = new SolidBrush(Color.FromArgb(255, 169, 163));
            }

            g.FillRectangle(br, this.X, this.Y, this.Width, this.Height);
            SizeF size = g.MeasureString(Name, font);

            g.DrawString(this.Name, font, Brushes.Black, (this.Width / 2) + this.X - (size.Width / 2), this.Y);

            g.DrawLine(p, X, Y + size.Height, X + Width, Y + size.Height);

            int CalcY = (int)size.Height + 1;
            font = new Font("Arial", 10);

            foreach (var item in Properties)
            {
                g.DrawString(item.ToString(), font, Brushes.Black, this.X + 3, this.Y + CalcY);
                CalcY += (int)g.MeasureString(item.ToString(), font).Height;
            }
            g.DrawLine(p, X, Y + CalcY, X + Width, Y + CalcY);

            size.Height = 0;

            foreach (var item in Methods)
            {
                g.DrawString(item.ToString(), font, Brushes.Black, this.X + 3, this.Y + CalcY);
                CalcY += (int)g.MeasureString(item.ToString(), font).Height;
            }


            if (Editable)
            {
                Image img2 = UML_Psotka.Properties.Resources.settings;
                g.DrawImage(img2, X, Y + Height - 20, 20, 20);
                g.DrawRectangle(Pens.Black, X, Y + Height - 20, 20, 20);

                img2 = UML_Psotka.Properties.Resources.delete;
                g.DrawImage(img2, X + Width - 20, Y + Height - 20, 20, 20);
                g.DrawRectangle(Pens.Black, X + Width - 20, Y + Height - 20, 20, 20);
            }

            g.DrawRectangle(p, this.X, this.Y, this.Width, this.Height);

        }
        public void RecalcDim()
        {
            Font font;
            if (this.isAbstract)
                font = new Font("Arial", 10, FontStyle.Italic);
            else
                font = new Font("Arial", 10);

            SizeF result;
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(Name, font);
                    if(result.Width + 20 > this.MinWidth)
                    {
                        this.MinWidth = (int)result.Width + 8;
                    }

                    font = new Font("Arial", 10);

                    foreach (var item in Properties)
                    {
                        result = g.MeasureString(item.ToString(), font);
                        if (result.Width > this.MinWidth)
                        {
                            this.MinWidth = (int)result.Width + 8;
                        }

                    }
                    foreach (var item in Methods)
                    {
                        result = g.MeasureString(item.ToString(), font);
                        if (result.Width  > this.MinWidth)
                        {
                            this.MinWidth = (int)result.Width + 8;
                        }

                    }
                }
            }
            if (this.Width < this.MinWidth)
            {
                this.Width = this.MinWidth;
            }

        }

    }
}

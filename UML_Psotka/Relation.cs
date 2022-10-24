using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Psotka
{
    public class Relation
    {
        public Class FirstClass { get; set; }
        public Class SecondClass { get; set; }
        public string FirstClassCard { get; set; }
        public string SecondClassCard { get; set; }
        public relationType RelationType { get; set; }
        public direction DeleteButtonDir { get; set; }

        public Relation(Class firstClass)
        {
            RelationType = relationType.Association;
            FirstClass = firstClass;
        }
        public enum relationType
        {
            Association,
            Inheritance,
            Realization,
            Dependency,
            Aggregation,
            Composition,

        }
        public enum direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            NONE,
        }

        public void Draw(Graphics g, int xM, int yM)
        {
            if (SecondClass == null)
                this.DrawToMouse(g, xM, yM);
            else
                this.DrawBetweenClasess(g, xM, yM);


        }
        public void DrawToMouse(Graphics g, int xM, int yM)
        {
            Pen pen = new Pen(Color.Black);
            if (this.RelationType == relationType.Dependency || this.RelationType == relationType.Realization)
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }

            if (yM < FirstClass.Y)
            {
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, FirstClass.Y, FirstClass.X + FirstClass.Width / 2, yM);
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, yM, xM, yM);
                this.DrawType(g, direction.DOWN, FirstClass);
            }
            else if (yM > FirstClass.Y + FirstClass.Height)
            {
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, FirstClass.Y + FirstClass.Height, FirstClass.X + FirstClass.Width / 2, yM);
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, yM, xM, yM);
                this.DrawType(g, direction.UP, FirstClass);
            }
            else if (xM < FirstClass.X)
            {
                g.DrawLine(pen, FirstClass.X, FirstClass.Y + FirstClass.Height / 2, xM, FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(pen, xM, FirstClass.Y + FirstClass.Height / 2, xM, yM);
                this.DrawType(g, direction.RIGHT, FirstClass);

            }
            else if (xM > FirstClass.X)
            {
                g.DrawLine(pen, FirstClass.X + FirstClass.Width, FirstClass.Y + FirstClass.Height / 2, xM, FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(pen, xM, FirstClass.Y + FirstClass.Height / 2, xM, yM);
                this.DrawType(g, direction.LEFT, FirstClass);
            }
        }
        public void DrawBetweenClasess(Graphics g, int xM, int yM)
        {
            Pen pen = new Pen(Color.Black);
            if (this.RelationType == relationType.Dependency || this.RelationType == relationType.Realization)
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            if (FirstClass.Y + FirstClass.Height >= SecondClass.Y && FirstClass.X + FirstClass.Width < SecondClass.X)
            {
                g.DrawLine(pen, FirstClass.X, FirstClass.Y + FirstClass.Height / 2, FirstClass.X + FirstClass.Width + ((SecondClass.X - (FirstClass.X + FirstClass.Width)) / 2), FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(pen, FirstClass.X + FirstClass.Width + ((SecondClass.X - (FirstClass.X + FirstClass.Width)) / 2), FirstClass.Y + FirstClass.Height / 2, FirstClass.X + FirstClass.Width + ((SecondClass.X - (FirstClass.X + FirstClass.Width)) / 2), SecondClass.Y + SecondClass.Height / 2);
                g.DrawLine(pen, FirstClass.X + FirstClass.Width + ((SecondClass.X - (FirstClass.X + FirstClass.Width)) / 2), SecondClass.Y + SecondClass.Height / 2, SecondClass.X, SecondClass.Y + SecondClass.Height / 2);
                this.DrawType(g, direction.LEFT, FirstClass);
                Font font = new Font("Arial", 10);
                g.DrawString(FirstClassCard, font, Brushes.Black, this.FirstClass.X + this.FirstClass.Width + 20, this.FirstClass.Y + (this.FirstClass.Height / 4) * 3);
                g.DrawString(SecondClassCard, font, Brushes.Black, this.SecondClass.X - 50, this.SecondClass.Y + (this.SecondClass.Height / 5));

                if (SecondClass == null)
                    return;
                if (this.FirstClass.Editable || this.SecondClass.Editable)
                {
                    g.FillEllipse(Brushes.Red, SecondClass.X - 20, SecondClass.Y + SecondClass.Height / 2 - 10, 20, 20);
                    this.DeleteButtonDir = direction.LEFT;
                }
                else
                {
                    this.DeleteButtonDir = direction.NONE;
                }
            }
            else if (SecondClass.Y + SecondClass.Height >= FirstClass.Y && SecondClass.X + SecondClass.Width < FirstClass.X)
            {
                g.DrawLine(pen, SecondClass.X, SecondClass.Y + SecondClass.Height / 2, SecondClass.X + SecondClass.Width + ((FirstClass.X - (SecondClass.X + SecondClass.Width)) / 2), SecondClass.Y + SecondClass.Height / 2);
                g.DrawLine(pen, SecondClass.X + SecondClass.Width + ((FirstClass.X - (SecondClass.X + SecondClass.Width)) / 2), SecondClass.Y + SecondClass.Height / 2, SecondClass.X + SecondClass.Width + ((FirstClass.X - (SecondClass.X + SecondClass.Width)) / 2), FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(pen, SecondClass.X + SecondClass.Width + ((FirstClass.X - (SecondClass.X + SecondClass.Width)) / 2), FirstClass.Y + FirstClass.Height / 2, FirstClass.X, FirstClass.Y + FirstClass.Height / 2);
                this.DrawType(g, direction.RIGHT, FirstClass);
                Font font = new Font("Arial", 10);
                g.DrawString(FirstClassCard, font, Brushes.Black, this.FirstClass.X - 50, this.FirstClass.Y + (this.FirstClass.Height / 4));
                g.DrawString(SecondClassCard, font, Brushes.Black, this.SecondClass.X + this.SecondClass.Width + 20, this.SecondClass.Y + (this.SecondClass.Height / 4) * 3);



                if (SecondClass == null)
                    return;
                if (this.FirstClass.Editable || this.SecondClass.Editable)
                {
                    g.FillEllipse(Brushes.Red, SecondClass.X + SecondClass.Width, SecondClass.Y + SecondClass.Height / 2 - 10, 20, 20);
                    this.DeleteButtonDir = direction.RIGHT;
                }
                else
                {
                    this.DeleteButtonDir = direction.NONE;
                }
            }
            else if (FirstClass.X + FirstClass.Width / 2 > SecondClass.X && FirstClass.Y + FirstClass.Height < SecondClass.Y)
            {
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, FirstClass.Y + FirstClass.Height, FirstClass.X + FirstClass.Width / 2, FirstClass.Y + FirstClass.Height + ((SecondClass.Y - (FirstClass.Y + FirstClass.Height)) / 2));
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, FirstClass.Y + FirstClass.Height + ((SecondClass.Y - (FirstClass.Y + FirstClass.Height)) / 2), SecondClass.X + SecondClass.Width / 2, FirstClass.Y + FirstClass.Height + ((SecondClass.Y - (FirstClass.Y + FirstClass.Height)) / 2));
                g.DrawLine(pen, SecondClass.X + SecondClass.Width / 2, FirstClass.Y + FirstClass.Height + ((SecondClass.Y - (FirstClass.Y + FirstClass.Height)) / 2), SecondClass.X + SecondClass.Width / 2, SecondClass.Y);
                this.DrawType(g, direction.UP, FirstClass);
                Font font = new Font("Arial", 10);
                g.DrawString(FirstClassCard, font, Brushes.Black, this.FirstClass.X + (this.FirstClass.Height / 4) * 3 + 15, this.FirstClass.Y + this.FirstClass.Height + 20);
                g.DrawString(SecondClassCard, font, Brushes.Black, this.SecondClass.X + (this.SecondClass.Height / 4) * 3 + 15, this.SecondClass.Y - 20);


                if (SecondClass == null)
                    return;
                if (this.FirstClass.Editable || this.SecondClass.Editable)
                {
                    g.FillEllipse(Brushes.Red, SecondClass.X + SecondClass.Width / 2 - 10, SecondClass.Y - 20, 20, 20);
                    this.DeleteButtonDir = direction.UP;
                }
                else
                {
                    this.DeleteButtonDir = direction.NONE;
                }
            }
            else if (SecondClass.X + SecondClass.Width / 2 > FirstClass.X && SecondClass.Y + SecondClass.Height < FirstClass.Y)
            {
                g.DrawLine(pen, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height + ((FirstClass.Y - (SecondClass.Y + SecondClass.Height)) / 2));
                g.DrawLine(pen, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height + ((FirstClass.Y - (SecondClass.Y + SecondClass.Height)) / 2), FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height + ((FirstClass.Y - (SecondClass.Y + SecondClass.Height)) / 2));
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height + ((FirstClass.Y - (SecondClass.Y + SecondClass.Height)) / 2), FirstClass.X + FirstClass.Width / 2, FirstClass.Y);
                this.DrawType(g, direction.DOWN, FirstClass);
                Font font = new Font("Arial", 10);
                g.DrawString(FirstClassCard, font, Brushes.Black, this.FirstClass.X + (this.FirstClass.Height / 4) * 3 + 15, this.FirstClass.Y - 20);
                g.DrawString(SecondClassCard, font, Brushes.Black, this.SecondClass.X + (this.SecondClass.Height / 4) * 3 + 15, this.SecondClass.Y + this.SecondClass.Height + 20);

                if (SecondClass == null)
                    return;
                if (this.FirstClass.Editable || this.SecondClass.Editable)
                {
                    g.FillEllipse(Brushes.Red, SecondClass.X + SecondClass.Width / 2 - 10, SecondClass.Y + SecondClass.Height, 20, 20);
                    this.DeleteButtonDir = direction.DOWN;
                }
                else
                {
                    this.DeleteButtonDir = direction.NONE;
                }
            }
            else if (SecondClass.Y + SecondClass.Height < FirstClass.Y)
            {
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, FirstClass.Y, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height / 2, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
                this.DrawType(g, direction.DOWN, FirstClass);
                    Font font = new Font("Arial", 10);
                g.DrawString(FirstClassCard, font, Brushes.Black, this.FirstClass.X + (this.FirstClass.Height / 4) * 3 + 15, this.FirstClass.Y - 20);
                g.DrawString(SecondClassCard, font, Brushes.Black, this.SecondClass.X + this.SecondClass.Width + 35, this.SecondClass.Y + (this.SecondClass.Height / 5));
                if (SecondClass == null)
                    return;
                if (this.FirstClass.Editable || this.SecondClass.Editable)
                {
                    g.FillEllipse(Brushes.Red, SecondClass.X + SecondClass.Width, SecondClass.Y + SecondClass.Height / 2 - 10, 20, 20);
                    this.DeleteButtonDir = direction.RIGHT;
                }
                else
                {
                    this.DeleteButtonDir = direction.NONE;
                }
            }
            else if (SecondClass.Y > FirstClass.Y + FirstClass.Height)
            {
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, FirstClass.Y + FirstClass.Height, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
                g.DrawLine(pen, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height / 2, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
                this.DrawType(g, direction.UP, FirstClass);
                Font font = new Font("Arial", 10);
                g.DrawString(FirstClassCard, font, Brushes.Black, this.FirstClass.X + (this.FirstClass.Height / 4) * 3 + 15, this.FirstClass.Y + this.FirstClass.Height + 20);
                g.DrawString(SecondClassCard, font, Brushes.Black, this.SecondClass.X - 50, this.SecondClass.Y + (this.SecondClass.Height / 4) * 3);


                if (SecondClass == null)
                    return;
                if (this.FirstClass.Editable || this.SecondClass.Editable)
                {
                    g.FillEllipse(Brushes.Red, SecondClass.X - 20, SecondClass.Y + SecondClass.Height / 2 - 10, 20, 20);
                    this.DeleteButtonDir = direction.LEFT;
                }
                else
                {
                    this.DeleteButtonDir = direction.NONE;
                }
            }
          
        }
        public void DrawType(Graphics g, direction d, Class @class)
        {
            switch (d)
            {
                case direction.UP:
                    if (this.RelationType == relationType.Association || this.RelationType == relationType.Dependency)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y + @class.Height, @class.X + @class.Width / 2 + 6, @class.Y + @class.Height + 20);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y + @class.Height, @class.X + @class.Width / 2 - 6, @class.Y + @class.Height + 20);

                    }
                    else if (this.RelationType == relationType.Inheritance || this.RelationType == relationType.Realization)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y + @class.Height, @class.X + @class.Width / 2 + 6, @class.Y + @class.Height + 20);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y + @class.Height, @class.X + @class.Width / 2 - 6, @class.Y + @class.Height + 20);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2 + 6, @class.Y + @class.Height + 20, @class.X + @class.Width / 2 - 6, @class.Y + @class.Height + 20);
                        g.DrawLine(new Pen(Color.FromArgb(126, 108, 108)), @class.X + @class.Width / 2, @class.Y + @class.Height - 1, @class.X + @class.Width / 2, @class.Y + @class.Height + 19);
                    }
                    else if (this.RelationType == relationType.Aggregation)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y + @class.Height, @class.X + @class.Width / 2 + 6, @class.Y + @class.Height + 10);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y + @class.Height, @class.X + @class.Width / 2 - 6, @class.Y + @class.Height + 10);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y + @class.Height + 20, @class.X + @class.Width / 2 - 6, @class.Y + @class.Height + 10);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y + @class.Height + 20, @class.X + @class.Width / 2 + 6, @class.Y + @class.Height + 10);
                        Point[] points = new Point[5];
                        points[0] = new Point(@class.X + @class.Width / 2, @class.Y + @class.Height + 1);
                        points[1] = new Point(@class.X + @class.Width / 2 + 5, @class.Y + @class.Height + 10);
                        points[2] = new Point(@class.X + @class.Width / 2, @class.Y + @class.Height + 19);
                        points[3] = new Point(@class.X + @class.Width / 2 - 5, @class.Y + @class.Height + 10);
                        points[4] = new Point(@class.X + @class.Width / 2, @class.Y + @class.Height + 1);
                        g.FillPolygon(new SolidBrush(Color.FromArgb(126, 108, 108)), points);

                    }
                    else if (this.RelationType == relationType.Composition)
                    {
                        Point[] points = new Point[5];
                        points[0] = new Point(@class.X + @class.Width / 2, @class.Y + @class.Height);
                        points[1] = new Point(@class.X + @class.Width / 2 + 6, @class.Y + @class.Height + 10);
                        points[2] = new Point(@class.X + @class.Width / 2, @class.Y + @class.Height + 20);
                        points[3] = new Point(@class.X + @class.Width / 2 - 6, @class.Y + @class.Height + 10);
                        points[4] = new Point(@class.X + @class.Width / 2, @class.Y + @class.Height);
                        g.FillPolygon(Brushes.Black, points);

                    }

                    break;
                case direction.DOWN:
                    if (this.RelationType == relationType.Association || this.RelationType == relationType.Dependency)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y, @class.X + @class.Width / 2 + 6, @class.Y - 20);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y, @class.X + @class.Width / 2 - 6, @class.Y - 20);

                    }
                    else if (this.RelationType == relationType.Inheritance || this.RelationType == relationType.Realization)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y, @class.X + @class.Width / 2 + 6, @class.Y - 20);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y, @class.X + @class.Width / 2 - 6, @class.Y - 20);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2 + 6, @class.Y - 20, @class.X + @class.Width / 2 - 6, @class.Y - 20);
                        g.DrawLine(new Pen(Color.FromArgb(126, 108, 108)), @class.X + @class.Width / 2, @class.Y + 1, @class.X + @class.Width / 2, @class.Y - 19);
                    }
                    else if (this.RelationType == relationType.Aggregation)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y, @class.X + @class.Width / 2 + 6, @class.Y - 10);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y, @class.X + @class.Width / 2 - 6, @class.Y - 10);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y - 20, @class.X + @class.Width / 2 + 6, @class.Y - 10);
                        g.DrawLine(Pens.Black, @class.X + @class.Width / 2, @class.Y - 20, @class.X + @class.Width / 2 - 6, @class.Y - 10);
                        Point[] points = new Point[5];
                        points[0] = new Point(@class.X + @class.Width / 2, @class.Y - 1);
                        points[1] = new Point(@class.X + @class.Width / 2 + 5, @class.Y - 10);
                        points[2] = new Point(@class.X + @class.Width / 2, @class.Y - 19);
                        points[3] = new Point(@class.X + @class.Width / 2 - 5, @class.Y - 10);
                        points[4] = new Point(@class.X + @class.Width / 2, @class.Y - 1);
                        g.FillPolygon(new SolidBrush(Color.FromArgb(126, 108, 108)), points);


                    }
                    else if (this.RelationType == relationType.Composition)
                    {
                        Point[] points = new Point[5];
                        points[0] = new Point(@class.X + @class.Width / 2, @class.Y);
                        points[1] = new Point(@class.X + @class.Width / 2 + 6, @class.Y - 10);
                        points[2] = new Point(@class.X + @class.Width / 2, @class.Y - 20);
                        points[3] = new Point(@class.X + @class.Width / 2 - 6, @class.Y - 10);
                        points[4] = new Point(@class.X + @class.Width / 2, @class.Y);
                        g.FillPolygon(Brushes.Black, points);

                    }

                    break;
                case direction.RIGHT:
                    if (this.RelationType == relationType.Association || this.RelationType == relationType.Dependency)
                    {
                        g.DrawLine(Pens.Black, @class.X, @class.Y + @class.Height / 2, @class.X - 20, @class.Y + @class.Height / 2 + 6);
                        g.DrawLine(Pens.Black, @class.X, @class.Y + @class.Height / 2, @class.X - 20, @class.Y + @class.Height / 2 - 6);

                    }
                    else if (this.RelationType == relationType.Inheritance || this.RelationType == relationType.Realization)
                    {
                        g.DrawLine(Pens.Black, @class.X, @class.Y + @class.Height / 2, @class.X - 20, @class.Y + @class.Height / 2 + 6);
                        g.DrawLine(Pens.Black, @class.X, @class.Y + @class.Height / 2, @class.X - 20, @class.Y + @class.Height / 2 - 6);
                        g.DrawLine(Pens.Black, @class.X - 20, @class.Y + @class.Height / 2 + 6, @class.X - 20, @class.Y + @class.Height / 2 - 6);
                        g.DrawLine(new Pen(Color.FromArgb(126, 108, 108)), @class.X - 1, @class.Y + @class.Height / 2, @class.X - 19, @class.Y + @class.Height / 2);

                    }
                    else if (this.RelationType == relationType.Aggregation)
                    {
                        g.DrawLine(Pens.Black, @class.X, @class.Y + @class.Height / 2, @class.X - 10, @class.Y + @class.Height / 2 + 6);
                        g.DrawLine(Pens.Black, @class.X, @class.Y + @class.Height / 2, @class.X - 10, @class.Y + @class.Height / 2 - 6);
                        g.DrawLine(Pens.Black, @class.X - 20, @class.Y + @class.Height / 2, @class.X - 10, @class.Y + @class.Height / 2 + 6);
                        g.DrawLine(Pens.Black, @class.X - 20, @class.Y + @class.Height / 2, @class.X - 10, @class.Y + @class.Height / 2 - 6);
                        Point[] points = new Point[5];
                        points[0] = new Point(@class.X - 1, @class.Y + @class.Height / 2);
                        points[1] = new Point(@class.X - 10, @class.Y + @class.Height / 2 + 5);
                        points[2] = new Point(@class.X - 19, @class.Y + @class.Height / 2);
                        points[3] = new Point(@class.X - 10, @class.Y + @class.Height / 2 - 5);
                        points[4] = new Point(@class.X - 1, @class.Y + @class.Height / 2);
                        g.FillPolygon(new SolidBrush(Color.FromArgb(126, 108, 108)), points);

                    }
                    else if (this.RelationType == relationType.Composition)
                    {
                        Point[] points = new Point[5];
                        points[0] = new Point(@class.X, @class.Y + @class.Height / 2);
                        points[1] = new Point(@class.X - 10, @class.Y + @class.Height / 2 + 6);
                        points[2] = new Point(@class.X - 20, @class.Y + @class.Height / 2);
                        points[3] = new Point(@class.X - 10, @class.Y + @class.Height / 2 - 6);
                        points[4] = new Point(@class.X, @class.Y + @class.Height / 2);
                        g.FillPolygon(Brushes.Black, points);
                    }
                    break;

                case direction.LEFT:
                    if (this.RelationType == relationType.Association || this.RelationType == relationType.Dependency)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width, @class.Y + @class.Height / 2, @class.X + @class.Width + 20, @class.Y + @class.Height / 2 + 6);
                        g.DrawLine(Pens.Black, @class.X + @class.Width, @class.Y + @class.Height / 2, @class.X + @class.Width + 20, @class.Y + @class.Height / 2 - 6);
                    }
                    else if (this.RelationType == relationType.Inheritance || this.RelationType == relationType.Realization)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width, @class.Y + @class.Height / 2, @class.X + @class.Width + 20, @class.Y + @class.Height / 2 + 6);
                        g.DrawLine(Pens.Black, @class.X + @class.Width, @class.Y + @class.Height / 2, @class.X + @class.Width + 20, @class.Y + @class.Height / 2 - 6);
                        g.DrawLine(Pens.Black, @class.X + @class.Width + 20, @class.Y + @class.Height / 2 + 6, @class.X + @class.Width + 20, @class.Y + @class.Height / 2 - 6);
                        g.DrawLine(new Pen(Color.FromArgb(126, 108, 108)), @class.X + @class.Width + 1, @class.Y + @class.Height / 2, @class.X + @class.Width + 19, @class.Y + @class.Height / 2);

                    }
                    else if (this.RelationType == relationType.Aggregation)
                    {
                        g.DrawLine(Pens.Black, @class.X + @class.Width, @class.Y + @class.Height / 2, @class.X + @class.Width + 10, @class.Y + @class.Height / 2 + 6);
                        g.DrawLine(Pens.Black, @class.X + @class.Width, @class.Y + @class.Height / 2, @class.X + @class.Width + 10, @class.Y + @class.Height / 2 - 6);
                        g.DrawLine(Pens.Black, @class.X + @class.Width + 20, @class.Y + @class.Height / 2, @class.X + @class.Width + 10, @class.Y + @class.Height / 2 + 6);
                        g.DrawLine(Pens.Black, @class.X + @class.Width + 20, @class.Y + @class.Height / 2, @class.X + @class.Width + 10, @class.Y + @class.Height / 2 - 6);
                        Point[] points = new Point[5];
                        points[0] = new Point(@class.X + @class.Width + 1, @class.Y + @class.Height / 2);
                        points[1] = new Point(@class.X + @class.Width + 10, @class.Y + @class.Height / 2 + 5);
                        points[2] = new Point(@class.X + @class.Width + 19, @class.Y + @class.Height / 2);
                        points[3] = new Point(@class.X + @class.Width + 10, @class.Y + @class.Height / 2 - 5);
                        points[4] = new Point(@class.X + @class.Width + 1, @class.Y + @class.Height / 2);
                        g.FillPolygon(new SolidBrush(Color.FromArgb(126, 108, 108)), points);
                    }
                    else if (this.RelationType == relationType.Composition)
                    {
                        Point[] points = new Point[5];
                        points[0] = new Point(@class.X + @class.Width, @class.Y + @class.Height / 2);
                        points[1] = new Point(@class.X + @class.Width + 10, @class.Y + @class.Height / 2 + 6);
                        points[2] = new Point(@class.X + @class.Width + 20, @class.Y + @class.Height / 2);
                        points[3] = new Point(@class.X + @class.Width + 10, @class.Y + @class.Height / 2 - 6);
                        points[4] = new Point(@class.X + @class.Width, @class.Y + @class.Height / 2);
                        g.FillPolygon(Brushes.Black, points);
                    }

                    break;
            }
        }

    }
}

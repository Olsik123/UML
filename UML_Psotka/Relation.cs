using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Psotka
{
    public class Relation
    {
        public Class FirstClass { get; set; }
        public Class SecondClass { get; set; }
        public Relation(Class firstClass)
        {
            FirstClass = firstClass;            
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
            if (yM < FirstClass.Y)
            {
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width / 2, FirstClass.Y, FirstClass.X + FirstClass.Width / 2, yM);
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width / 2, yM, xM, yM);
            }
            else if (yM > FirstClass.Y + FirstClass.Height)
            {
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width / 2, FirstClass.Y + FirstClass.Height, FirstClass.X + FirstClass.Width / 2, yM);
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width / 2, yM, xM, yM);
            }
            else if (xM < FirstClass.X)
            {
                g.DrawLine(Pens.Black, FirstClass.X, FirstClass.Y + FirstClass.Height / 2, xM, FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(Pens.Black, xM, FirstClass.Y + FirstClass.Height / 2, xM, yM);
            }
            else if (xM > FirstClass.X)
            {
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width, FirstClass.Y + FirstClass.Height / 2, xM, FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(Pens.Black, xM, FirstClass.Y + FirstClass.Height / 2, xM, yM);
            }
        }
        public void DrawBetweenClasess(Graphics g, int xM, int yM)
        {
            if (SecondClass.Y + SecondClass.Height < FirstClass.Y)
            {
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width / 2, FirstClass.Y, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height / 2, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
            }
            else if (SecondClass.Y > FirstClass.Y + FirstClass.Height)
            {
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width / 2, FirstClass.Y + FirstClass.Height, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width / 2, SecondClass.Y + SecondClass.Height / 2, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
            }
            else if (FirstClass.Y + FirstClass.Height / 2 >= SecondClass.Y && FirstClass.X + FirstClass.Width < SecondClass.X)
            {
                g.DrawLine(Pens.Black, FirstClass.X, FirstClass.Y + FirstClass.Height / 2, FirstClass.X + FirstClass.Width + ((SecondClass.X - (FirstClass.X + FirstClass.Width )) / 2), FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width + ((SecondClass.X - (FirstClass.X + FirstClass.Width)) / 2), FirstClass.Y + FirstClass.Height / 2, FirstClass.X + FirstClass.Width + ((SecondClass.X - (FirstClass.X + FirstClass.Width)) / 2), SecondClass.Y + SecondClass.Height/2);
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width + ((SecondClass.X - (FirstClass.X + FirstClass.Width)) / 2), SecondClass.Y + SecondClass.Height / 2, SecondClass.X, SecondClass.Y + SecondClass.Height / 2);
            }
            else if (SecondClass.Y + SecondClass.Height / 2 >= FirstClass.Y && SecondClass.X + SecondClass.Width < FirstClass.X)
            {
                g.DrawLine(Pens.Black, SecondClass.X, SecondClass.Y + SecondClass.Height / 2, SecondClass.X + SecondClass.Width + ((FirstClass.X - (SecondClass.X + SecondClass.Width)) / 2), SecondClass.Y + SecondClass.Height / 2);
                g.DrawLine(Pens.Black, SecondClass.X + SecondClass.Width + ((FirstClass.X - (SecondClass.X + SecondClass.Width)) / 2), SecondClass.Y + SecondClass.Height / 2, SecondClass.X + SecondClass.Width + ((FirstClass.X - (SecondClass.X + SecondClass.Width)) / 2), FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(Pens.Black, SecondClass.X + SecondClass.Width + ((FirstClass.X - (SecondClass.X + SecondClass.Width)) / 2), FirstClass.Y + FirstClass.Height / 2, FirstClass.X, FirstClass.Y + FirstClass.Height / 2);
            }
            else if (SecondClass.X + SecondClass.Width < FirstClass.X)
            {
                g.DrawLine(Pens.Black, FirstClass.X, FirstClass.Y + FirstClass.Height / 2, SecondClass.X + SecondClass.Width / 2, FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(Pens.Black, SecondClass.X + SecondClass.Width / 2, FirstClass.Y + FirstClass.Height / 2, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
            }
            else if (SecondClass.X > FirstClass.X)
            {
                g.DrawLine(Pens.Black, FirstClass.X + FirstClass.Width, FirstClass.Y + FirstClass.Height / 2, SecondClass.X + SecondClass.Width / 2, FirstClass.Y + FirstClass.Height / 2);
                g.DrawLine(Pens.Black, SecondClass.X + SecondClass.Width / 2, FirstClass.Y + FirstClass.Height / 2, SecondClass.X + SecondClass.Width / 2, SecondClass.Y + SecondClass.Height / 2);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_Psotka
{
    public class Application2
    {
        public List<Class> Classes { get; set; } = new List<Class>();

        public Class EditClass { get; set; }

        public int CursorX { get; set; }

        public int CursorY { get; set; }


        public void Draw(Graphics g)
        {

            foreach (Class item in Classes)
            {
                item.Draw(g);
            }
            if (EditClass != null)
                EditClass.Draw(g);
        }
        public void CreateClass(Frm_Class frm)
        {
            frm.ClassList = Classes;
            if (frm.ShowDialog() == DialogResult.OK)
                 Classes.Add(frm.Class);
        }
        public void DoubleClick(int xM, int yM)
        {
            if (EditClass != null)
                if (EditClass.X < xM && xM < EditClass.X + EditClass.Width && EditClass.Y < yM && yM < EditClass.Y + EditClass.Height)
                {
                    Frm_ClassSettings frm = new Frm_ClassSettings(EditClass, this.Classes);
                    frm.ShowDialog();
                    EditClass.RecalcDim();
                }
        }
        public void MouseUp(int xM, int yM)
        {
            if (EditClass != null)
            {
                if (EditClass.X + EditClass.Width - 20 < xM && xM < EditClass.X + EditClass.Width && EditClass.Y + EditClass.Height - 20 < yM && yM < EditClass.Y + EditClass.Height)
                {

                    Frm_DeleteClass frm = new Frm_DeleteClass(EditClass.Name);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Classes.Remove(EditClass);
                        this.EditClass = null;
                        return;
                    }

                }
                else if (EditClass.X < xM && xM < EditClass.X + 20 && EditClass.Y + EditClass.Height - 20 < yM && yM < EditClass.Y + EditClass.Height)
                {
                    Frm_ClassSettings frm = new Frm_ClassSettings(EditClass,this.Classes);
                    frm.ShowDialog();
                    EditClass.RecalcDim();

                }
            }

        }
        public void MouseDown(int xM, int yM)
        {
            this.CursorX = xM;
            this.CursorY = yM;
            bool changed = false;
            foreach (Class item in Classes.AsEnumerable().Reverse())
            {
                if (item.X < xM && xM < item.X + item.Width && item.Y < yM && yM < item.Y + item.Height)
                {
                    changed = true;

                    if (item == EditClass)
                    {
                        Classes.Remove(EditClass);
                        Classes.Add(EditClass);
                        break;
                    }
                    if (EditClass != null)
                    {
                        EditClass.Editable = false;
                        Classes.Remove(EditClass);
                        Classes.Add(EditClass);
                    }
                    EditClass = item;
                    EditClass.Editable = true;
                    break;
                }
            }
            if (EditClass != null && !changed)
            {
                EditClass.Editable = false;
                Classes.Remove(EditClass);
                Classes.Add(EditClass);
                EditClass = null;
            }

        }

        public void MouseMove(int xM, int yM, int pcW, int pcH)
        {
            if (EditClass == null)
                return;

            EditClass.X += xM - this.CursorX;
            EditClass.Y += yM - this.CursorY;

            this.CursorX = xM;
            this.CursorY = yM;

            if (EditClass.X < 0)
                EditClass.X = 0;
            if (EditClass.Y < 0)
                EditClass.Y = 1;
            if (EditClass.X + EditClass.Width > pcW)
                EditClass.X = pcW - 1 - EditClass.Width;
            if (EditClass.Y + EditClass.Height > pcH)
                EditClass.Y = pcH - 1 - EditClass.Height;


        }
    }
}

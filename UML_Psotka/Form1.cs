using System;
using System.Drawing.Imaging;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;

namespace UML_Psotka
{

    public partial class Form1 : Form
    {


        private Application2 App = new Application2();
        private int StartX = 20;
        private int StartY = 20;


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            GC.Collect();
            Graphics g = e.Graphics;
            this.App.Draw(g);
        }
        private void button_import_Click(object sender, EventArgs e)
        {
            Frm_ImpFRM frm = new Frm_ImpFRM();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.App.ImportCode(frm.Path);

            }
        }


        private void button_code_Click(object sender, EventArgs e)
        {
            Frm_ExpFRM frm = new Frm_ExpFRM();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string path = frm.Path + @"\" + frm.Name;
                this.App.GenerateCode(path);
               
            }
        }


        private void button_txt_Click(object sender, EventArgs e)
        {
            Frm_ExpFRM frm = new Frm_ExpFRM();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string path = frm.Path + @"\" + frm.Name;
                this.App.GenerateJson(path);

            }
        }

        private void button_png_Click(object sender, EventArgs e)
        {
            if (this.App.EditClass != null)
                this.App.EditClass.Editable = false;

            this.pictureBox.Refresh();
            Frm_ExpFRM frm = new Frm_ExpFRM();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(this.pictureBox.Width, this.pictureBox.Height);
                Graphics g = Graphics.FromImage(image);
                g.FillRectangle(new SolidBrush(Color.FromArgb(126, 108, 108)), 0, 0, this.pictureBox.Width, this.pictureBox.Height);
                this.App.Draw(g);
                image.Save(frm.Path + @"\" + frm.Name + ".png", ImageFormat.Png);
            }
            if (this.App.EditClass != null)
                this.App.EditClass.Editable = true;
            this.pictureBox.Refresh();
        }

        private void button_newClass_Click(object sender, EventArgs e)
        {
            if (this.StartX + 100 <= this.pictureBox.Width)
                this.StartX += 100;
            else if (this.StartY > this.pictureBox.Height)
                this.StartY = 10;
            else
            {
                this.StartX = 30;
                this.StartY += 10;
            }
            Frm_Class frm = new Frm_Class(new Class(StartX, StartY));
            this.App.CreateClass(frm);
            this.pictureBox.Refresh();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.App.MouseDown(e.X, e.Y);

            }
            else if (e.Button == MouseButtons.Right)
            {

                Relation rel = this.App.Relations.LastOrDefault();
                if (rel != null)
                {
                    if (rel.SecondClass == null)
                    {
                        this.contextMenuStrip_Relation.Show(this, new Point(e.X, e.Y));
                    }
                }
            }
            this.pictureBox.Refresh();

        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox.Refresh();
            this.App.ChangePosition(e.X, e.Y);
            if (e.Button != MouseButtons.Left)
                return;
            this.App.MouseMove(e.X, e.Y, this.pictureBox.Width, this.pictureBox.Height);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.App.MouseUp(e.X, e.Y);
            this.pictureBox.Refresh();
        }


        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.App.DoubleClick(e.X, e.Y);
            this.pictureBox.Refresh();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.App.Relations.Remove(this.App.Relations.LastOrDefault());
            this.App.MakingRelation = false;
        }



        private void associationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relation rel = this.App.Relations.LastOrDefault();
            rel.RelationType = Relation.relationType.Association;
        }

        private void ingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relation rel = this.App.Relations.LastOrDefault();
            rel.RelationType = Relation.relationType.Inheritance;
        }

        private void aggregationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relation rel = this.App.Relations.LastOrDefault();
            rel.RelationType = Relation.relationType.Aggregation;
        }

        private void realizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relation rel = this.App.Relations.LastOrDefault();
            rel.RelationType = Relation.relationType.Realization;
        }

        private void dependencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relation rel = this.App.Relations.LastOrDefault();
            rel.RelationType = Relation.relationType.Dependency;
        }

        private void compositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relation rel = this.App.Relations.LastOrDefault();
            rel.RelationType = Relation.relationType.Composition;
        }

        private void button_relations_Click(object sender, EventArgs e)
        {

        }
    }
}
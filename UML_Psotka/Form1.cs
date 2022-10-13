using System;

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

        }


        private void button_code_Click(object sender, EventArgs e)
        {

        }


        private void button_txt_Click(object sender, EventArgs e)
        {

        }

        private void button_png_Click(object sender, EventArgs e)
        {

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
            if (e.Button != MouseButtons.Left)
                return;
            this.App.MouseDown(e.X, e.Y);
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
    }
}
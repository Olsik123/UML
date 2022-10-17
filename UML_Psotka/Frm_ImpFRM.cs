using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_Psotka
{
    public partial class Frm_ImpFRM : Form
    {
        public string Path { get; set; }


        public Frm_ImpFRM()
        {
            InitializeComponent();
        }

        private void button_SelectPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "json files (*.json)|*.json";
            file.InitialDirectory = @"C:\Users\Public\Desktop";
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.textBox_Path.Text = file.FileName;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                this.DialogResult = DialogResult.OK;
                this.Path = this.textBox_Path.Text;
                this.Close();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

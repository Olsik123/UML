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
    public partial class Frm_ExpFRM : Form
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Frm_ExpFRM()
        {
            InitializeComponent();
        }

        private void button_SelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.InitialDirectory = @"C:\Users\Public\Desktop";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.textBox_Path.Text = folder.SelectedPath;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                this.DialogResult = DialogResult.OK;
                this.Path = this.textBox_Path.Text;
                this.Name = this.textbox_Name.Text;
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

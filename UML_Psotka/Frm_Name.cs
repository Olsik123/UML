using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_Psotka
{
    public partial class Frm_Name : Form
    {
        public string Name { get; set; }
        public List<Class> ClassList = new List<Class>();
        public Frm_Name(string name, List<Class> classList)
        {
            InitializeComponent();
            Name = name;
            this.textBox1.Text = name;
            this.label1.Text = "Rename : " + name;
            ClassList = classList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.Name= this.textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            this.errorProvider1.SetError(this.textBox1, null);
            Regex rx = new Regex(@"^[a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]+$");
            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                this.errorProvider1.SetError(this.textBox1, "Pole nesmí být prázdné!");
                e.Cancel = true;
            }
            else if (this.textBox1.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.textBox1, "Nesmí mít mezery!");
                e.Cancel = true;
            }
            else if (!rx.IsMatch(this.textBox1.Text))
            {
                this.errorProvider1.SetError(this.textBox1, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
            else if (this.ClassList.Any(x => x.Name == this.textBox1.Text))
            {
                this.errorProvider1.SetError(this.textBox1, "Jméno musí být unikátní!");
                e.Cancel = true;
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

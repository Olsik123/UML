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
    public partial class Frm_Parameter : Form
    {
        public string DataType { get; set; }
        public Frm_Parameter()
        {
            InitializeComponent();

        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.DataType = this.textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.textBox1, null);

            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                this.errorProvider1.SetError(this.textBox1, "Pole je povinné");
                e.Cancel = true;
            }

            if (this.textBox1.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.textBox1, "Nesmí mít mezery!");
                e.Cancel = true;
            }

            Regex rx = new Regex(@"^[a-zA-Z0-9_ěščřžýáíéůú]+$");
            if (!rx.IsMatch(this.textBox1.Text))
            {
                this.errorProvider1.SetError(this.textBox1, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
        }
    }
}

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
using static UML_Psotka.Class;

namespace UML_Psotka
{
    public partial class Frm_Paramcs : Form
    {
        public Frm_Paramcs()
        {
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(dataType)))
            {
                comboBox1.Items.Add(item.ToString());
            }

        }
        public string DataType { get; set; }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                this.DialogResult = DialogResult.OK;
                this.DataType = this.comboBox1.Text;
                this.Close();
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {


            this.errorProvider1.SetError(comboBox1, null);
            Regex rx = new Regex(@"^[a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]+$");

            if (string.IsNullOrWhiteSpace(this.comboBox1.Text))
            {
                this.errorProvider1.SetError(this.comboBox1, "Pole nesmí být prázdné!");
                e.Cancel = true;
            }
            else if (this.comboBox1.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.comboBox1, "Nesmí mít mezery!");
                e.Cancel = true;
            }
            else if (!rx.IsMatch(this.comboBox1.Text))
            {
                this.errorProvider1.SetError(this.comboBox1, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }


        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

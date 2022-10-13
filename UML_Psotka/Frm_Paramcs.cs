using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
                comboBox_DT.Items.Add(item.ToString());
            }

        }
        public string  Name { get; set; }
        public string  DataType { get; set; }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {             
                this.DialogResult = DialogResult.OK;
                this.Name = this.textBox_Name.Text;
                this.DataType = this.comboBox_DT.Text;
                this.Close();
            }
        }
        private void textBox_Name_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.textBox_Name, null);
            Regex rx = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]*$");

            if (string.IsNullOrWhiteSpace(this.textBox_Name.Text))
            {
                this.errorProvider1.SetError(this.textBox_Name, "Pole nesmí být prázdné!");
                e.Cancel = true;
            }
            else if (this.textBox_Name.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.textBox_Name, "Nesmí mít mezery!");
                e.Cancel = true;
            }
            else if (!rx.IsMatch(this.textBox_Name.Text))
            {
                this.errorProvider1.SetError(this.textBox_Name, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
        }
        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {


            this.errorProvider1.SetError(comboBox_DT, null);
            Regex rx = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]*$");

            if (string.IsNullOrWhiteSpace(this.comboBox_DT.Text))
            {
                this.errorProvider1.SetError(this.comboBox_DT, "Pole nesmí být prázdné!");
                e.Cancel = true;
            }
            else if (this.comboBox_DT.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.comboBox_DT, "Nesmí mít mezery!");
                e.Cancel = true;
            }
            else if (!rx.IsMatch(this.comboBox_DT.Text))
            {
                this.errorProvider1.SetError(this.comboBox_DT, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }


        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Paramcs_Load(object sender, EventArgs e)
        {

        }

        
    }
}

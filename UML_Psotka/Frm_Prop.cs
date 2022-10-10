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
    public partial class Frm_Prop : Form
    {
        public Property Property { get; set; }
        public Frm_Prop(Property prop)
        {
            
            Property = prop;
            InitializeComponent();
            this.textBox_Name.Text = prop.Name;
            this.textBox_DataType.Text = prop.DataType;
            this.comboBox_AccM.DataSource = Enum.GetValues(typeof(accessModifiers));
            this.comboBox_AccM.Text = prop.AccessM.ToString();

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Property.Name = this.textBox_Name.Text;
                Property.DataType = this.textBox_DataType.Text;
                Property.AccessM = (accessModifiers) Enum.Parse(typeof(accessModifiers),this.comboBox_AccM.SelectedValue.ToString(),true);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void button_back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBox_AccM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Name_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.textBox_Name, null);

            if (String.IsNullOrWhiteSpace(this.textBox_Name.Text))
            {
                this.errorProvider1.SetError(this.textBox_Name, "Pole je povinné");
                e.Cancel = true;
            }
            if (this.textBox_Name.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.textBox_Name, "Nesmí mít mezery!");
                e.Cancel = true;
            }

            Regex rx = new Regex(@"^[a-zA-Z0-9_ěščřžýáíéůú]+$");
            if (!rx.IsMatch(this.textBox_Name.Text))
            {
                this.errorProvider1.SetError(this.textBox_Name, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
        }

        private void textBox_DataType_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.textBox_DataType, null);

            if (String.IsNullOrWhiteSpace(this.textBox_DataType.Text))
            {
                this.errorProvider1.SetError(this.textBox_DataType, "Pole je povinné");
                e.Cancel = true;
            }
            if (this.textBox_DataType.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.textBox_DataType, "Nesmí mít mezery!");
                e.Cancel = true;
            }

            Regex rx = new Regex(@"^[a-zA-Z0-9_ěščřžýáíéůú]+$");
            if (!rx.IsMatch(this.textBox_DataType.Text))
            {
                this.errorProvider1.SetError(this.textBox_DataType, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
        }

  
    }
}

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
        public List<Class> ClassList = new List<Class>();
        public Class Class { get; set; }


        public Frm_Prop(Property prop, Class classs)
        {

            Property = prop;
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(dataType)))
            {
                comboBox_DataType.Items.Add(item.ToString());
            }
            this.textBox_Name.Text = prop.Name;
            this.comboBox_DataType.Text = prop.DataType;
            this.comboBox_AccM.DataSource = Enum.GetValues(typeof(accessModifiers));
            this.comboBox_AccM.Text = prop.AccessM.ToString();
            Class = classs;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Property.Name = this.textBox_Name.Text;
                Property.DataType = this.comboBox_DataType.Text;
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
            Regex rx = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]*$");
            if (String.IsNullOrWhiteSpace(this.textBox_Name.Text))
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
            else if (this.Class.Properties.Any(x => x.Name == this.textBox_Name.Text))
            {
                this.errorProvider1.SetError(this.textBox_Name, "Jméno musí být unikátní!");
                e.Cancel = true;
            }
        }

        private void textBox_DataType_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.comboBox_DataType, null);
            Regex rx = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]*$");
            if (String.IsNullOrWhiteSpace(this.comboBox_DataType.Text))
            {
                this.errorProvider1.SetError(this.comboBox_DataType, "Pole nesmí být prázdné!");
                e.Cancel = true;
            }
            else if (this.comboBox_DataType.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.comboBox_DataType, "Nesmí mít mezery!");
                e.Cancel = true;
            }

            else if (!rx.IsMatch(this.comboBox_DataType.Text))
            {
                this.errorProvider1.SetError(this.comboBox_DataType, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
        }

  
    }
}

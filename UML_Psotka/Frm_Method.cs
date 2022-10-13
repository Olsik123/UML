using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static UML_Psotka.Class;

namespace UML_Psotka
{
    public partial class Frm_Method : Form
    {
        public Method Method { get; set; }
        public Class Class{ get; set; }

        public Frm_Method(Method method, Class classs)
        {
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(dataType)))
            {
                comboBox_Output.Items.Add(item.ToString());
            }
            Method = method;
            this.comboBox_Name.Text = method.Name;
            this.comboBox_Output.Text = method.Output;
            this.comboBox_AccM.DataSource = Enum.GetValues(typeof(accessModifiers));
            this.comboBox_AccM.Text = method.AccessM.ToString();
            this.listBox1.DataSource = this.Method.Parameters.ToList();
            Class = classs;
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                Method.Name = this.comboBox_Name.Text;
                Method.Output = this.comboBox_Output.Text;
                Method.AccessM = (accessModifiers)Enum.Parse(typeof(accessModifiers), this.comboBox_AccM.SelectedValue.ToString(), true);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button_addPar_Click(object sender, EventArgs e)
        {
            Frm_Paramcs frm = new Frm_Paramcs();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.Method.Parameters.Add(frm.Name,frm.DataType);
                this.listBox1.DataSource = this.Method.Parameters.ToList();
            }
        }

        private void button_DeleteParameter_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count <= 0)
                return;
            string prop = ((KeyValuePair<string, string>)this.listBox1.SelectedItem).Key;
            this.Method.Parameters.Remove(prop);
            this.listBox1.DataSource = this.Method.Parameters.ToList();
        }


        private void textBox_Name_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.comboBox_Name, null);
            Regex rx = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]*$");
            if (string.IsNullOrWhiteSpace(this.comboBox_Name.Text))
            {
                this.errorProvider1.SetError(this.comboBox_Name, "Nesmí být prázdné!");
                e.Cancel = true;
            }
            else if (this.comboBox_Name.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.comboBox_Name, "Nesmí mít mezery!");
                e.Cancel = true;
            }
            else if (!rx.IsMatch(this.comboBox_Name.Text))
            {
                this.errorProvider1.SetError(this.comboBox_Name, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
            else if (this.Class.Methods.Any(x => x.Name == this.comboBox_Name.Text))
            {
                this.errorProvider1.SetError(this.comboBox_Name, "Jméno musí být unikátní!");
                e.Cancel = true;
            }
        }

        private void textBox_Output_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.comboBox_Output, null);
            Regex rx = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]*$");
            if (string.IsNullOrEmpty(this.comboBox_Output.Text))
            {
                this.errorProvider1.SetError(this.comboBox_Output, "Pole nesmí být prázdné!");
                e.Cancel = true;
            }
            else if (this.comboBox_Output.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.comboBox_Output, "Nesmí mít mezery!");
                e.Cancel = true;
            }
            else if (!rx.IsMatch(this.comboBox_Output.Text))
            {
                this.errorProvider1.SetError(this.comboBox_Output, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
        }
    }
}

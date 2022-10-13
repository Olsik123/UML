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
    public partial class Frm_ClassSettings : Form
    {
        public Class Class { get; set; }
        public List<Class> ClassList = new List<Class>();



        public Frm_ClassSettings(Class @class,List<Class> classList)
        {
            this.Class = @class;
            InitializeComponent();
            this.ClassList = classList;
            this.textBox_Name.Text = this.Class.Name;
            this.listBox_Methods.DataSource = Class.Methods.ToList();
            this.listBox_Properties.DataSource = Class.Properties.ToList();
            this.comboBox_ClassType.DataSource = Enum.GetValues(typeof(classType));
            this.comboBox_ClassType.Text = this.Class.ClassType.ToString();
        }

        private void button_AddProp_Click(object sender, EventArgs e)
        {

            Frm_Prop frm = new Frm_Prop(new Property(),this.Class);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Class.Properties.Add(frm.Property);
                this.listBox_Properties.DataSource = Class.Properties.ToList();
            }

        }

        private void button_PropUpd_Click(object sender, EventArgs e)
        {
            if (this.listBox_Properties.Items.Count <= 0)
                return;
            Property prop = this.listBox_Properties.SelectedItem as Property;
            Frm_Prop frm = new Frm_Prop(prop, this.Class);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Class.Properties.Remove(prop);
                this.Class.Properties.Add(frm.Property);
                this.listBox_Properties.DataSource = Class.Properties.ToList();
            }
        }

        private void button_PropDel_Click(object sender, EventArgs e)
        {
            if (this.listBox_Properties.Items.Count <= 0)
                return;
            Property prop = this.listBox_Properties.SelectedItem as Property;
            this.Class.Properties.Remove(prop);
            this.listBox_Properties.DataSource = Class.Properties.ToList();

        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                this.Class.Name = this.textBox_Name.Text;
                this.Class.ClassType = (classType)Enum.Parse(typeof(classType), this.comboBox_ClassType.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Frm_ClassSettings_Load(object sender, EventArgs e)
        {

        }


        private void button_AddMethod_Click(object sender, EventArgs e)
        {
            Frm_Method frm = new Frm_Method(new Method(), this.Class);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Class.Methods.Add(frm.Method);
                this.listBox_Methods.DataSource = Class.Methods.ToList();
            }

        }

        private void button_MethUpd_Click(object sender, EventArgs e)
        {
            if (this.listBox_Methods.Items.Count <= 0)
                return;
            Method meth = this.listBox_Methods.SelectedItem as Method;
            Frm_Method frm = new Frm_Method(meth, this.Class);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Class.Methods.Remove(meth);
                this.Class.Methods.Add(frm.Method);
                this.listBox_Methods.DataSource = Class.Methods.ToList();
            }

        }

        private void button_MethDel_Click(object sender, EventArgs e)
        {
            if (this.listBox_Methods.Items.Count <= 0)
                return;
            Method meth = this.listBox_Methods.SelectedItem as Method;
            this.Class.Methods.Remove(meth);
            this.listBox_Methods.DataSource = Class.Methods.ToList();
        }

        private void textBox_Name_Validating(object sender, CancelEventArgs e)
        {

            this.errorProvider1.SetError(this.textBox_Name, null);
            Regex rx = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]*$");
            if (string.IsNullOrEmpty(this.textBox_Name.Text))
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

        private void comboBox_ClassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Class.ClassType = (classType) Enum.Parse(typeof(classType),this.comboBox_ClassType.Text);
        }
    }
}

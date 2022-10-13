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
    public partial class Frm_Class : Form
    {
        public Class Class;

        public List<Class> ClassList = new List<Class>();

        public Frm_Class(Class @class)
        {
            Class = @class;
            InitializeComponent();
            this.textBox_name.Text = Class.Name;
            this.comboBox_ClassType.DataSource = Enum.GetValues(typeof(classType));

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.Class.Name = this.textBox_name.Text;
                this.Class.ClassType = (classType)Enum.Parse(typeof(classType), this.comboBox_ClassType.SelectedValue.ToString(), true);
                this.DialogResult = DialogResult.OK;
                Font font;

                if (Class.ClassType == classType.ABSTRACT)
                    font = new Font("Arial", 10, FontStyle.Italic);
                else
                    font = new Font("Arial", 10);

                Graphics g = this.CreateGraphics();

                if (g.MeasureString(Class.Name, font).Width + 50 > Class.MinWidth)
                {
                    Class.MinWidth = Convert.ToInt32(g.MeasureString(Class.Name, font).Width + 50);
                    if (Class.MinWidth > Class.Width)
                        Class.Width = Class.MinWidth;
                }




                this.Close();
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_name_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.textBox_name, null);
            Regex rx = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_ěščřžýáíéůúĚŠČŘŽÝÁÍÉŮÚ]*$");

            if (string.IsNullOrWhiteSpace(this.textBox_name.Text))
            {
                this.errorProvider1.SetError(this.textBox_name, "Pole nesmí být prázdné!");
                e.Cancel = true;
            }
            else if (this.textBox_name.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.textBox_name, "Nesmí mít mezery!");
                e.Cancel = true;
            }
            else if (!rx.IsMatch(this.textBox_name.Text))
            {
                this.errorProvider1.SetError(this.textBox_name, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
            else if (this.ClassList.Any(x => x.Name == this.textBox_name.Text))
            {
                this.errorProvider1.SetError(this.textBox_name, "Jméno musí být unikátní!");
                e.Cancel = true;
            }
        }

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UML_Psotka.Class;
using static UML_Psotka.Relation;

namespace UML_Psotka
{
    public partial class Frm_Relation : Form
    {
        public Relation Rel { get; set; }   
        public Frm_Relation(Relation rel)
        {

            Rel = rel;
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(relationType)))
            {
                comboBox_RelationType.Items.Add(item.ToString());
            }
            this.comboBox_RelationType.Text = Rel.RelationType.ToString();
            this.comboBox_ParentCard.Items.Add("0..1");
            this.comboBox_ParentCard.Items.Add("0..*");
            this.comboBox_ParentCard.Items.Add("1..*");
            this.comboBox_ParentCard.Items.Add("1");
            this.comboBox_TargetCard.Items.Add("0..1");
            this.comboBox_TargetCard.Items.Add("0..*");
            this.comboBox_TargetCard.Items.Add("1..*");
            this.comboBox_TargetCard.Items.Add("1");
            label_parent.Text = "Parent: " + Rel.FirstClass.Name;
            label_target.Text = "Target: " + Rel.SecondClass.Name;

        }

        private void Frm_Relation_Load(object sender, EventArgs e)
        {

        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                this.Rel.SecondClassCard = this.comboBox_TargetCard.Text;
                this.Rel.FirstClassCard = this.comboBox_ParentCard.Text;
                this.Rel.RelationType = (relationType)Enum.Parse(typeof(relationType), this.comboBox_RelationType.SelectedItem.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button_Swap_Click(object sender, EventArgs e)
        {
            (this.Rel.SecondClass, this.Rel.FirstClass) = (this.Rel.FirstClass, this.Rel.SecondClass);
            label_parent.Text = "Parent: " + Rel.FirstClass.Name;
            label_target.Text = "Target: " + Rel.SecondClass.Name;
        }
    }
}

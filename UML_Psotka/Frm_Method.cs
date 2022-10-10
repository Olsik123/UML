﻿using System;
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
    public partial class Frm_Method : Form
    {
        public Method Method { get; set; }

        public Frm_Method(Method method)
        {
            InitializeComponent();
            Method = method;
            this.textBox_Name.Text = method.Name;
            this.textBox_Output.Text = method.Output;
            this.comboBox_AccM.DataSource = Enum.GetValues(typeof(accessModifiers));
            this.comboBox_AccM.Text = method.AccessM.ToString();
            this.listBox1.DataSource = this.Method.Parameters.ToList(); 
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Method.Name = this.textBox_Name.Text;
                Method.Output = this.textBox_Output.Text;
                Method.AccessM = (accessModifiers)Enum.Parse(typeof(accessModifiers), this.comboBox_AccM.SelectedValue.ToString(), true);
                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
        }

        private void button_addPar_Click(object sender, EventArgs e)
        {
            Frm_Parameter frm = new Frm_Parameter();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.Method.Parameters.Add(frm.DataType);
                this.listBox1.DataSource = this.Method.Parameters.ToList();
            }
        }

        private void button_DeleteParameter_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count <= 0)
                return;
            string prop = this.listBox1.SelectedItem as string;
            this.Method.Parameters.Remove(prop);
            this.listBox1.DataSource = this.Method.Parameters.ToList();
        }

        private void textBox_Name_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.textBox_Name, null);

            if (string.IsNullOrWhiteSpace(this.textBox_Name.Text))
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

        private void textBox_Output_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.textBox_Output, null);
            if (string.IsNullOrEmpty(this.textBox_Output.Text))
            {
                this.errorProvider1.SetError(this.textBox_Output, "Pole je povinné");
                e.Cancel = true;
            }
            if (this.textBox_Output.Text.Contains(' '))
            {
                this.errorProvider1.SetError(this.textBox_Output, "Nesmí mít mezery!");
                e.Cancel = true;
            }
            Regex rx = new Regex(@"^[a-zA-Z0-9_ěščřžýáíéůú]+$");
            if (!rx.IsMatch(this.textBox_Output.Text))
            {
                this.errorProvider1.SetError(this.textBox_Output, "Pouze písmena,čísla a podtržítko!");
                e.Cancel = true;
            }
        }
    }
}

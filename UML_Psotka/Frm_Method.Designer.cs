namespace UML_Psotka
{
    partial class Frm_Method
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_AccM = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_addPar = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_DeleteParameter = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox_Output = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // comboBox_Name
            // 
            this.comboBox_Name.Location = new System.Drawing.Point(87, 25);
            this.comboBox_Name.Name = "comboBox_Name";
            this.comboBox_Name.Size = new System.Drawing.Size(126, 23);
            this.comboBox_Name.TabIndex = 1;
            this.comboBox_Name.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Name_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "DT output:";
            // 
            // comboBox_AccM
            // 
            this.comboBox_AccM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AccM.FormattingEnabled = true;
            this.comboBox_AccM.Location = new System.Drawing.Point(87, 83);
            this.comboBox_AccM.Name = "comboBox_AccM";
            this.comboBox_AccM.Size = new System.Drawing.Size(126, 23);
            this.comboBox_AccM.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Access M.:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(87, 126);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(126, 94);
            this.listBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Parameters:";
            // 
            // button_addPar
            // 
            this.button_addPar.Location = new System.Drawing.Point(15, 144);
            this.button_addPar.Name = "button_addPar";
            this.button_addPar.Size = new System.Drawing.Size(67, 23);
            this.button_addPar.TabIndex = 9;
            this.button_addPar.Text = "Add";
            this.button_addPar.UseVisualStyleBackColor = true;
            this.button_addPar.Click += new System.EventHandler(this.button_addPar_Click);
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(87, 252);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(53, 23);
            this.button_Ok.TabIndex = 9;
            this.button_Ok.Text = "Ok";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_DeleteParameter
            // 
            this.button_DeleteParameter.Location = new System.Drawing.Point(15, 173);
            this.button_DeleteParameter.Name = "button_DeleteParameter";
            this.button_DeleteParameter.Size = new System.Drawing.Size(67, 22);
            this.button_DeleteParameter.TabIndex = 9;
            this.button_DeleteParameter.Text = "Delete";
            this.button_DeleteParameter.UseVisualStyleBackColor = true;
            this.button_DeleteParameter.Click += new System.EventHandler(this.button_DeleteParameter_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // comboBox_Output
            // 
            this.comboBox_Output.FormattingEnabled = true;
            this.comboBox_Output.Location = new System.Drawing.Point(87, 54);
            this.comboBox_Output.Name = "comboBox_Output";
            this.comboBox_Output.Size = new System.Drawing.Size(126, 23);
            this.comboBox_Output.TabIndex = 10;
            this.comboBox_Output.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Output_Validating);
            // 
            // Frm_Method
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(241, 287);
            this.Controls.Add(this.comboBox_Output);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.button_DeleteParameter);
            this.Controls.Add(this.button_addPar);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox_AccM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Method";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Method";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox comboBox_Name;
        private Label label2;
        private ComboBox comboBox_AccM;
        private Label label3;
        private ListBox listBox1;
        private Label label4;
        private Button button_addPar;
        private Button button_Ok;
        private Button button_DeleteParameter;
        private ErrorProvider errorProvider1;
        private ComboBox comboBox_Output;
    }
}
namespace UML_Psotka
{
    partial class Frm_ClassSettings
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
            this.listBox_Properties = new System.Windows.Forms.ListBox();
            this.listBox_Methods = new System.Windows.Forms.ListBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_AddProp = new System.Windows.Forms.Button();
            this.button_AddMethod = new System.Windows.Forms.Button();
            this.label_Class = new System.Windows.Forms.Label();
            this.button_PropUpd = new System.Windows.Forms.Button();
            this.button_PropDel = new System.Windows.Forms.Button();
            this.button_Rename = new System.Windows.Forms.Button();
            this.button_MethUpd = new System.Windows.Forms.Button();
            this.button_MethDel = new System.Windows.Forms.Button();
            this.checkBox_Abstract = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_Properties
            // 
            this.listBox_Properties.FormattingEnabled = true;
            this.listBox_Properties.ItemHeight = 15;
            this.listBox_Properties.Location = new System.Drawing.Point(12, 95);
            this.listBox_Properties.Name = "listBox_Properties";
            this.listBox_Properties.Size = new System.Drawing.Size(193, 229);
            this.listBox_Properties.TabIndex = 0;
            // 
            // listBox_Methods
            // 
            this.listBox_Methods.FormattingEnabled = true;
            this.listBox_Methods.ItemHeight = 15;
            this.listBox_Methods.Location = new System.Drawing.Point(261, 95);
            this.listBox_Methods.Name = "listBox_Methods";
            this.listBox_Methods.Size = new System.Drawing.Size(299, 259);
            this.listBox_Methods.TabIndex = 0;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(222, 415);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "Ok";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_AddProp
            // 
            this.button_AddProp.Location = new System.Drawing.Point(12, 330);
            this.button_AddProp.Name = "button_AddProp";
            this.button_AddProp.Size = new System.Drawing.Size(53, 23);
            this.button_AddProp.TabIndex = 1;
            this.button_AddProp.Text = "Add ";
            this.button_AddProp.UseVisualStyleBackColor = true;
            this.button_AddProp.Click += new System.EventHandler(this.button_AddProp_Click);
            // 
            // button_AddMethod
            // 
            this.button_AddMethod.Location = new System.Drawing.Point(261, 360);
            this.button_AddMethod.Name = "button_AddMethod";
            this.button_AddMethod.Size = new System.Drawing.Size(83, 23);
            this.button_AddMethod.TabIndex = 1;
            this.button_AddMethod.Text = "Add";
            this.button_AddMethod.UseVisualStyleBackColor = true;
            this.button_AddMethod.Click += new System.EventHandler(this.button_AddMethod_Click);
            // 
            // label_Class
            // 
            this.label_Class.AutoSize = true;
            this.label_Class.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Class.Location = new System.Drawing.Point(180, 9);
            this.label_Class.Name = "label_Class";
            this.label_Class.Size = new System.Drawing.Size(164, 33);
            this.label_Class.TabIndex = 2;
            this.label_Class.Text = "label_Class";
            // 
            // button_PropUpd
            // 
            this.button_PropUpd.Location = new System.Drawing.Point(71, 330);
            this.button_PropUpd.Name = "button_PropUpd";
            this.button_PropUpd.Size = new System.Drawing.Size(75, 23);
            this.button_PropUpd.TabIndex = 1;
            this.button_PropUpd.Text = "Update";
            this.button_PropUpd.UseVisualStyleBackColor = true;
            this.button_PropUpd.Click += new System.EventHandler(this.button_PropUpd_Click);
            // 
            // button_PropDel
            // 
            this.button_PropDel.Location = new System.Drawing.Point(152, 330);
            this.button_PropDel.Name = "button_PropDel";
            this.button_PropDel.Size = new System.Drawing.Size(53, 23);
            this.button_PropDel.TabIndex = 1;
            this.button_PropDel.Text = "Delete";
            this.button_PropDel.UseVisualStyleBackColor = true;
            this.button_PropDel.Click += new System.EventHandler(this.button_PropDel_Click);
            // 
            // button_Rename
            // 
            this.button_Rename.Location = new System.Drawing.Point(88, 377);
            this.button_Rename.Name = "button_Rename";
            this.button_Rename.Size = new System.Drawing.Size(117, 23);
            this.button_Rename.TabIndex = 1;
            this.button_Rename.Text = "Rename class";
            this.button_Rename.UseVisualStyleBackColor = true;
            this.button_Rename.Click += new System.EventHandler(this.button_Rename_Click);
            // 
            // button_MethUpd
            // 
            this.button_MethUpd.Location = new System.Drawing.Point(350, 360);
            this.button_MethUpd.Name = "button_MethUpd";
            this.button_MethUpd.Size = new System.Drawing.Size(108, 23);
            this.button_MethUpd.TabIndex = 1;
            this.button_MethUpd.Text = "Update";
            this.button_MethUpd.UseVisualStyleBackColor = true;
            this.button_MethUpd.Click += new System.EventHandler(this.button_MethUpd_Click);
            // 
            // button_MethDel
            // 
            this.button_MethDel.Location = new System.Drawing.Point(464, 360);
            this.button_MethDel.Name = "button_MethDel";
            this.button_MethDel.Size = new System.Drawing.Size(96, 23);
            this.button_MethDel.TabIndex = 1;
            this.button_MethDel.Text = "Delete";
            this.button_MethDel.UseVisualStyleBackColor = true;
            this.button_MethDel.Click += new System.EventHandler(this.button_MethDel_Click);
            // 
            // checkBox_Abstract
            // 
            this.checkBox_Abstract.AutoSize = true;
            this.checkBox_Abstract.Location = new System.Drawing.Point(12, 377);
            this.checkBox_Abstract.Name = "checkBox_Abstract";
            this.checkBox_Abstract.Size = new System.Drawing.Size(70, 19);
            this.checkBox_Abstract.TabIndex = 3;
            this.checkBox_Abstract.Text = "Abstract";
            this.checkBox_Abstract.UseVisualStyleBackColor = true;
            this.checkBox_Abstract.CheckedChanged += new System.EventHandler(this.checkBox_Abstract_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Properties:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(261, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Methods:";
            // 
            // Frm_ClassSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox_Abstract);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Class);
            this.Controls.Add(this.button_Rename);
            this.Controls.Add(this.button_AddMethod);
            this.Controls.Add(this.button_MethDel);
            this.Controls.Add(this.button_PropDel);
            this.Controls.Add(this.button_MethUpd);
            this.Controls.Add(this.button_PropUpd);
            this.Controls.Add(this.button_AddProp);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.listBox_Methods);
            this.Controls.Add(this.listBox_Properties);
            this.Name = "Frm_ClassSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ClassSettings";
            this.Load += new System.EventHandler(this.Frm_ClassSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBox_Properties;
        private ListBox listBox_Methods;
        private Button button_Save;
        private Button button_AddProp;
        private Button button_AddMethod;
        private Label label_Class;
        private Button button_PropUpd;
        private Button button_PropDel;
        private Button button_Rename;
        private Button button_MethUpd;
        private Button button_MethDel;
        private CheckBox checkBox_Abstract;
        private Label label1;
        private Label label2;
    }
}
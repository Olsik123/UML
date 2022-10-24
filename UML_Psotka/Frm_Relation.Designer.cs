namespace UML_Psotka
{
    partial class Frm_Relation
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_RelationType = new System.Windows.Forms.ComboBox();
            this.comboBox_TargetCard = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_target = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_parent = new System.Windows.Forms.Label();
            this.comboBox_ParentCard = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Swap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relation";
            // 
            // comboBox_RelationType
            // 
            this.comboBox_RelationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RelationType.FormattingEnabled = true;
            this.comboBox_RelationType.Location = new System.Drawing.Point(87, 109);
            this.comboBox_RelationType.Name = "comboBox_RelationType";
            this.comboBox_RelationType.Size = new System.Drawing.Size(121, 23);
            this.comboBox_RelationType.TabIndex = 1;
            // 
            // comboBox_TargetCard
            // 
            this.comboBox_TargetCard.FormattingEnabled = true;
            this.comboBox_TargetCard.Location = new System.Drawing.Point(120, 230);
            this.comboBox_TargetCard.Name = "comboBox_TargetCard";
            this.comboBox_TargetCard.Size = new System.Drawing.Size(121, 23);
            this.comboBox_TargetCard.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 4;
            // 
            // label_target
            // 
            this.label_target.AutoSize = true;
            this.label_target.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_target.Location = new System.Drawing.Point(70, 212);
            this.label_target.Name = "label_target";
            this.label_target.Size = new System.Drawing.Size(54, 15);
            this.label_target.TabIndex = 5;
            this.label_target.Text = "Target:";
            this.label_target.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 6;
            // 
            // label_parent
            // 
            this.label_parent.AutoSize = true;
            this.label_parent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_parent.Location = new System.Drawing.Point(69, 155);
            this.label_parent.Name = "label_parent";
            this.label_parent.Size = new System.Drawing.Size(55, 15);
            this.label_parent.TabIndex = 7;
            this.label_parent.Text = "Parent:";
            this.label_parent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox_ParentCard
            // 
            this.comboBox_ParentCard.FormattingEnabled = true;
            this.comboBox_ParentCard.Location = new System.Drawing.Point(120, 173);
            this.comboBox_ParentCard.Name = "comboBox_ParentCard";
            this.comboBox_ParentCard.Size = new System.Drawing.Size(121, 23);
            this.comboBox_ParentCard.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Cardinality:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cardinality:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(74, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Relation type:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(12, 269);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 9;
            this.button_Ok.Text = "Ok";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(218, 269);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 9;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Swap
            // 
            this.button_Swap.Location = new System.Drawing.Point(212, 201);
            this.button_Swap.Name = "button_Swap";
            this.button_Swap.Size = new System.Drawing.Size(81, 23);
            this.button_Swap.TabIndex = 9;
            this.button_Swap.Text = "Swap parent";
            this.button_Swap.UseVisualStyleBackColor = true;
            this.button_Swap.Click += new System.EventHandler(this.button_Swap_Click);
            // 
            // Frm_Relation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 304);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Swap);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_parent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_target);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_TargetCard);
            this.Controls.Add(this.comboBox_ParentCard);
            this.Controls.Add(this.comboBox_RelationType);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Relation";
            this.Text = "Frm_Relation";
            this.Load += new System.EventHandler(this.Frm_Relation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboBox_RelationType;
        private ComboBox comboBox_TargetCard;
        private Label label2;
        private Label label_target;
        private Label label4;
        private Label label_parent;
        private ComboBox comboBox_ParentCard;
        private Label label8;
        private Label label6;
        private Label label7;
        private Button button_Ok;
        private Button button_Cancel;
        private Button button_Swap;
    }
}
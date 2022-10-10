namespace UML_Psotka
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button_import = new System.Windows.Forms.Button();
            this.button_newClass = new System.Windows.Forms.Button();
            this.button_code = new System.Windows.Forms.Button();
            this.button_txt = new System.Windows.Forms.Button();
            this.button_png = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.pictureBox.Location = new System.Drawing.Point(83, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1113, 687);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // button_import
            // 
            this.button_import.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button_import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_import.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_import.Location = new System.Drawing.Point(12, 658);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(58, 31);
            this.button_import.TabIndex = 1;
            this.button_import.Text = ".txt";
            this.button_import.UseVisualStyleBackColor = false;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // button_newClass
            // 
            this.button_newClass.Image = global::UML_Psotka.Properties.Resources.add_class;
            this.button_newClass.Location = new System.Drawing.Point(7, 12);
            this.button_newClass.Name = "button_newClass";
            this.button_newClass.Size = new System.Drawing.Size(70, 79);
            this.button_newClass.TabIndex = 1;
            this.button_newClass.UseVisualStyleBackColor = true;
            this.button_newClass.Click += new System.EventHandler(this.button_newClass_Click);
            // 
            // button_code
            // 
            this.button_code.BackColor = System.Drawing.Color.IndianRed;
            this.button_code.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_code.Location = new System.Drawing.Point(12, 530);
            this.button_code.Name = "button_code";
            this.button_code.Size = new System.Drawing.Size(58, 31);
            this.button_code.TabIndex = 1;
            this.button_code.Text = ".cls";
            this.button_code.UseVisualStyleBackColor = false;
            this.button_code.Click += new System.EventHandler(this.button_code_Click);
            // 
            // button_txt
            // 
            this.button_txt.BackColor = System.Drawing.Color.IndianRed;
            this.button_txt.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_txt.Location = new System.Drawing.Point(12, 493);
            this.button_txt.Name = "button_txt";
            this.button_txt.Size = new System.Drawing.Size(58, 31);
            this.button_txt.TabIndex = 1;
            this.button_txt.Text = ".txt";
            this.button_txt.UseVisualStyleBackColor = false;
            this.button_txt.Click += new System.EventHandler(this.button_txt_Click);
            // 
            // button_png
            // 
            this.button_png.BackColor = System.Drawing.Color.IndianRed;
            this.button_png.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_png.Location = new System.Drawing.Point(12, 567);
            this.button_png.Name = "button_png";
            this.button_png.Size = new System.Drawing.Size(58, 31);
            this.button_png.TabIndex = 1;
            this.button_png.Text = ".png";
            this.button_png.UseVisualStyleBackColor = false;
            this.button_png.Click += new System.EventHandler(this.button_png_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = " EXPORT ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 639);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "  IMPORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "NEW CLASS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1208, 711);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_txt);
            this.Controls.Add(this.button_code);
            this.Controls.Add(this.button_png);
            this.Controls.Add(this.button_newClass);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.pictureBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private Button button_import;
        private Button button_newClass;
        private Button button_code;
        private Button button_txt;
        private Button button_png;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
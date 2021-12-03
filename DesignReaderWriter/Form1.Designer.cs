namespace DesignReaderWriter
{
    partial class mainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_DesignType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DesignID = new System.Windows.Forms.TextBox();
            this.btn_Read = new System.Windows.Forms.Button();
            this.btn_Write = new System.Windows.Forms.Button();
            this.txt_Design = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String";
            // 
            // txt_ConnectionString
            // 
            this.txt_ConnectionString.Location = new System.Drawing.Point(138, 60);
            this.txt_ConnectionString.Name = "txt_ConnectionString";
            this.txt_ConnectionString.Size = new System.Drawing.Size(551, 23);
            this.txt_ConnectionString.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Design Type";
            // 
            // cmb_DesignType
            // 
            this.cmb_DesignType.FormattingEnabled = true;
            this.cmb_DesignType.Items.AddRange(new object[] {
            "Design",
            "Template"});
            this.cmb_DesignType.Location = new System.Drawing.Point(139, 105);
            this.cmb_DesignType.Name = "cmb_DesignType";
            this.cmb_DesignType.Size = new System.Drawing.Size(350, 23);
            this.cmb_DesignType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Design ID";
            // 
            // txt_DesignID
            // 
            this.txt_DesignID.Location = new System.Drawing.Point(139, 154);
            this.txt_DesignID.Name = "txt_DesignID";
            this.txt_DesignID.Size = new System.Drawing.Size(158, 23);
            this.txt_DesignID.TabIndex = 5;
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(139, 203);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(75, 23);
            this.btn_Read.TabIndex = 6;
            this.btn_Read.Text = "Read";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // btn_Write
            // 
            this.btn_Write.Location = new System.Drawing.Point(222, 203);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(75, 23);
            this.btn_Write.TabIndex = 7;
            this.btn_Write.Text = "Write";
            this.btn_Write.UseVisualStyleBackColor = true;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // txt_Design
            // 
            this.txt_Design.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Design.Location = new System.Drawing.Point(138, 248);
            this.txt_Design.MaxLength = 9000000;
            this.txt_Design.Multiline = true;
            this.txt_Design.Name = "txt_Design";
            this.txt_Design.Size = new System.Drawing.Size(551, 519);
            this.txt_Design.TabIndex = 8;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 794);
            this.Controls.Add(this.txt_Design);
            this.Controls.Add(this.btn_Write);
            this.Controls.Add(this.btn_Read);
            this.Controls.Add(this.txt_DesignID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_DesignType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ConnectionString);
            this.Controls.Add(this.label1);
            this.Name = "mainForm";
            this.Text = "Design Reader Writer";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_DesignType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_DesignID;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.TextBox txt_Design;
    }
}

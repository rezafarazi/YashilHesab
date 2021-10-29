namespace rest
{
    partial class Form4
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
            this.btnyes = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnno = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mj_Ashgar", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "آیا مایلید برنامه را ادامه دهید؟";
            // 
            // btnyes
            // 
            this.btnyes.Depth = 0;
            this.btnyes.Location = new System.Drawing.Point(28, 129);
            this.btnyes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnyes.Name = "btnyes";
            this.btnyes.Primary = true;
            this.btnyes.Size = new System.Drawing.Size(75, 23);
            this.btnyes.TabIndex = 1;
            this.btnyes.Text = "بله";
            this.btnyes.UseVisualStyleBackColor = true;
            this.btnyes.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // btnno
            // 
            this.btnno.Depth = 0;
            this.btnno.Location = new System.Drawing.Point(214, 129);
            this.btnno.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnno.Name = "btnno";
            this.btnno.Primary = true;
            this.btnno.Size = new System.Drawing.Size(75, 23);
            this.btnno.TabIndex = 2;
            this.btnno.Text = "خیر";
            this.btnno.UseVisualStyleBackColor = true;
            this.btnno.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 185);
            this.Controls.Add(this.btnno);
            this.Controls.Add(this.btnyes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public MaterialSkin.Controls.MaterialRaisedButton btnyes;
        public MaterialSkin.Controls.MaterialRaisedButton btnno;
    }
}
namespace WordMemorizer.Core
{
    partial class FormAddWeek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddWeek));
            this.BtnImport = new System.Windows.Forms.Button();
            this.txtWordInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnImport
            // 
            this.BtnImport.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnImport.Location = new System.Drawing.Point(882, 486);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(174, 56);
            this.BtnImport.TabIndex = 0;
            this.BtnImport.Text = "添加";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnCreateWeekPlan_Click);
            // 
            // txtWordInput
            // 
            this.txtWordInput.Location = new System.Drawing.Point(33, 36);
            this.txtWordInput.Multiline = true;
            this.txtWordInput.Name = "txtWordInput";
            this.txtWordInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWordInput.Size = new System.Drawing.Size(793, 506);
            this.txtWordInput.TabIndex = 1;
            // 
            // FormAddWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 586);
            this.Controls.Add(this.txtWordInput);
            this.Controls.Add(this.BtnImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAddWeek";
            this.Text = "添加本周单词";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.TextBox txtWordInput;
    }
}
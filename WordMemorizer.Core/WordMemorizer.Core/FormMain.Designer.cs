namespace WordMemorizer.Core
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnRead = new System.Windows.Forms.Button();
            this.TBWord = new System.Windows.Forms.TextBox();
            this.TBMeaning = new System.Windows.Forms.TextBox();
            this.BtnSetWeek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnRead
            // 
            this.BtnRead.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRead.Location = new System.Drawing.Point(162, 324);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(126, 52);
            this.BtnRead.TabIndex = 0;
            this.BtnRead.Text = "发音";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // TBWord
            // 
            this.TBWord.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBWord.Location = new System.Drawing.Point(162, 235);
            this.TBWord.Name = "TBWord";
            this.TBWord.Size = new System.Drawing.Size(312, 42);
            this.TBWord.TabIndex = 1;
            this.TBWord.Text = "carro";
            // 
            // TBMeaning
            // 
            this.TBMeaning.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBMeaning.Location = new System.Drawing.Point(638, 235);
            this.TBMeaning.Name = "TBMeaning";
            this.TBMeaning.Size = new System.Drawing.Size(312, 42);
            this.TBMeaning.TabIndex = 2;
            this.TBMeaning.Text = "车";
            // 
            // BtnSetWeek
            // 
            this.BtnSetWeek.Location = new System.Drawing.Point(1223, 591);
            this.BtnSetWeek.Name = "BtnSetWeek";
            this.BtnSetWeek.Size = new System.Drawing.Size(114, 56);
            this.BtnSetWeek.TabIndex = 3;
            this.BtnSetWeek.Text = "周计划";
            this.BtnSetWeek.UseVisualStyleBackColor = true;
            this.BtnSetWeek.Click += new System.EventHandler(this.BtnSetWeek_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 668);
            this.Controls.Add(this.BtnSetWeek);
            this.Controls.Add(this.TBMeaning);
            this.Controls.Add(this.TBWord);
            this.Controls.Add(this.BtnRead);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "单词记忆";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.TextBox TBWord;
        private System.Windows.Forms.TextBox TBMeaning;
        private System.Windows.Forms.Button BtnSetWeek;
    }
}


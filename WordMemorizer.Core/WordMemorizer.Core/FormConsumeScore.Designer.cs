namespace WordMemorizer.Core
{
    partial class FormConsumeScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsumeScore));
            this.LVList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TbConsumedScore = new System.Windows.Forms.TextBox();
            this.LblScores = new System.Windows.Forms.Label();
            this.LblAvailableBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LVList
            // 
            this.LVList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.LVList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LVList.FullRowSelect = true;
            this.LVList.GridLines = true;
            this.LVList.HideSelection = false;
            this.LVList.Location = new System.Drawing.Point(28, 32);
            this.LVList.Name = "LVList";
            this.LVList.Size = new System.Drawing.Size(952, 360);
            this.LVList.TabIndex = 0;
            this.LVList.UseCompatibleStateImageBehavior = false;
            this.LVList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "积分";
            this.columnHeader3.Width = 200;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(836, 421);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(144, 52);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "消费";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TbConsumedScore
            // 
            this.TbConsumedScore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbConsumedScore.Location = new System.Drawing.Point(632, 435);
            this.TbConsumedScore.MaxLength = 10;
            this.TbConsumedScore.Name = "TbConsumedScore";
            this.TbConsumedScore.Size = new System.Drawing.Size(187, 31);
            this.TbConsumedScore.TabIndex = 2;
            // 
            // LblScores
            // 
            this.LblScores.AutoSize = true;
            this.LblScores.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblScores.Location = new System.Drawing.Point(36, 441);
            this.LblScores.Name = "LblScores";
            this.LblScores.Size = new System.Drawing.Size(21, 21);
            this.LblScores.TabIndex = 3;
            this.LblScores.Text = "0";
            // 
            // LblAvailableBalance
            // 
            this.LblAvailableBalance.AutoSize = true;
            this.LblAvailableBalance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAvailableBalance.Location = new System.Drawing.Point(36, 515);
            this.LblAvailableBalance.Name = "LblAvailableBalance";
            this.LblAvailableBalance.Size = new System.Drawing.Size(21, 21);
            this.LblAvailableBalance.TabIndex = 4;
            this.LblAvailableBalance.Text = "0";
            // 
            // FormConsumeScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 582);
            this.Controls.Add(this.LblAvailableBalance);
            this.Controls.Add(this.LblScores);
            this.Controls.Add(this.TbConsumedScore);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LVList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsumeScore";
            this.Text = "积分消费";
            this.Load += new System.EventHandler(this.FormConsumeScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LVList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TbConsumedScore;
        private System.Windows.Forms.Label LblScores;
        private System.Windows.Forms.Label LblAvailableBalance;
    }
}
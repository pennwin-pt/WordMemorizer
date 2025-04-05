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
            this.BtnAppend = new System.Windows.Forms.Button();
            this.LvWeeklyPlan = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LblCount = new System.Windows.Forms.Label();
            this.CBHideText = new System.Windows.Forms.CheckBox();
            this.CBHideChinese = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtnImport
            // 
            this.BtnImport.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnImport.Location = new System.Drawing.Point(1295, 779);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(156, 56);
            this.BtnImport.TabIndex = 0;
            this.BtnImport.Text = "重建";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnReCreateWeekPlan_Click);
            // 
            // txtWordInput
            // 
            this.txtWordInput.Location = new System.Drawing.Point(673, 36);
            this.txtWordInput.Multiline = true;
            this.txtWordInput.Name = "txtWordInput";
            this.txtWordInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWordInput.Size = new System.Drawing.Size(778, 715);
            this.txtWordInput.TabIndex = 1;
            // 
            // BtnAppend
            // 
            this.BtnAppend.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAppend.Location = new System.Drawing.Point(1095, 779);
            this.BtnAppend.Name = "BtnAppend";
            this.BtnAppend.Size = new System.Drawing.Size(156, 56);
            this.BtnAppend.TabIndex = 2;
            this.BtnAppend.Text = "追加";
            this.BtnAppend.UseVisualStyleBackColor = true;
            this.BtnAppend.Click += new System.EventHandler(this.BtnAppend_Click);
            // 
            // LvWeeklyPlan
            // 
            this.LvWeeklyPlan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2});
            this.LvWeeklyPlan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LvWeeklyPlan.FullRowSelect = true;
            this.LvWeeklyPlan.GridLines = true;
            this.LvWeeklyPlan.HideSelection = false;
            this.LvWeeklyPlan.Location = new System.Drawing.Point(12, 36);
            this.LvWeeklyPlan.MultiSelect = false;
            this.LvWeeklyPlan.Name = "LvWeeklyPlan";
            this.LvWeeklyPlan.Size = new System.Drawing.Size(617, 715);
            this.LvWeeklyPlan.TabIndex = 3;
            this.LvWeeklyPlan.UseCompatibleStateImageBehavior = false;
            this.LvWeeklyPlan.View = System.Windows.Forms.View.Details;
            this.LvWeeklyPlan.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvWeeklyPlan_MouseDoubleClick);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "ID";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "单词";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "中文含义";
            this.columnHeader2.Width = 300;
            // 
            // LblCount
            // 
            this.LblCount.AutoSize = true;
            this.LblCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCount.Location = new System.Drawing.Point(12, 766);
            this.LblCount.Name = "LblCount";
            this.LblCount.Size = new System.Drawing.Size(189, 21);
            this.LblCount.TabIndex = 4;
            this.LblCount.Text = "本周计划单词：0个";
            // 
            // CBHideText
            // 
            this.CBHideText.AutoSize = true;
            this.CBHideText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBHideText.Location = new System.Drawing.Point(497, 766);
            this.CBHideText.Name = "CBHideText";
            this.CBHideText.Size = new System.Drawing.Size(132, 28);
            this.CBHideText.TabIndex = 5;
            this.CBHideText.Text = "隐藏单词";
            this.CBHideText.UseVisualStyleBackColor = true;
            this.CBHideText.CheckedChanged += new System.EventHandler(this.CBHideText_CheckedChanged);
            // 
            // CBHideChinese
            // 
            this.CBHideChinese.AutoSize = true;
            this.CBHideChinese.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBHideChinese.Location = new System.Drawing.Point(497, 807);
            this.CBHideChinese.Name = "CBHideChinese";
            this.CBHideChinese.Size = new System.Drawing.Size(132, 28);
            this.CBHideChinese.TabIndex = 6;
            this.CBHideChinese.Text = "隐藏中文";
            this.CBHideChinese.UseVisualStyleBackColor = true;
            this.CBHideChinese.CheckedChanged += new System.EventHandler(this.CBHideChinese_CheckedChanged);
            // 
            // FormAddWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 935);
            this.Controls.Add(this.CBHideChinese);
            this.Controls.Add(this.CBHideText);
            this.Controls.Add(this.LblCount);
            this.Controls.Add(this.LvWeeklyPlan);
            this.Controls.Add(this.BtnAppend);
            this.Controls.Add(this.txtWordInput);
            this.Controls.Add(this.BtnImport);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAddWeek";
            this.Text = "添加本周单词";
            this.Load += new System.EventHandler(this.FormAddWeek_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.TextBox txtWordInput;
        private System.Windows.Forms.Button BtnAppend;
        private System.Windows.Forms.ListView LvWeeklyPlan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label LblCount;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.CheckBox CBHideText;
        private System.Windows.Forms.CheckBox CBHideChinese;
    }
}
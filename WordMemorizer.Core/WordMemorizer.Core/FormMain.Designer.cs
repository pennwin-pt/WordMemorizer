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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblDay = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.LblTotalScores = new System.Windows.Forms.Label();
            this.BtnExamChineseMeaning = new System.Windows.Forms.Button();
            this.BtnPronounciation = new System.Windows.Forms.Button();
            this.BtnExamPortuguese = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnCorrection = new System.Windows.Forms.Button();
            this.BtnReload = new System.Windows.Forms.Button();
            this.BtnSetWeek = new System.Windows.Forms.Button();
            this.LblIndex = new System.Windows.Forms.Label();
            this.CBHideChinese = new System.Windows.Forms.CheckBox();
            this.CBHideText = new System.Windows.Forms.CheckBox();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnReadSentence = new System.Windows.Forms.Button();
            this.TbSentenceChinese = new System.Windows.Forms.TextBox();
            this.TbSentence = new System.Windows.Forms.TextBox();
            this.TBChineseMeaning = new System.Windows.Forms.TextBox();
            this.TBText = new System.Windows.Forms.TextBox();
            this.BtnRead = new System.Windows.Forms.Button();
            this.RBToday = new System.Windows.Forms.RadioButton();
            this.RBYesterday = new System.Windows.Forms.RadioButton();
            this.RBTomorrow = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblDay,
            this.LblDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 744);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1480, 31);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblDay
            // 
            this.LblDay.BackColor = System.Drawing.SystemColors.Control;
            this.LblDay.ForeColor = System.Drawing.Color.Black;
            this.LblDay.Name = "LblDay";
            this.LblDay.Size = new System.Drawing.Size(70, 24);
            this.LblDay.Text = "LblDay";
            // 
            // LblDate
            // 
            this.LblDate.ForeColor = System.Drawing.Color.Black;
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(195, 24);
            this.LblDate.Text = "toolStripStatusLabel2";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.RBTomorrow);
            this.PnlMain.Controls.Add(this.RBYesterday);
            this.PnlMain.Controls.Add(this.RBToday);
            this.PnlMain.Controls.Add(this.LblTotalScores);
            this.PnlMain.Controls.Add(this.BtnExamChineseMeaning);
            this.PnlMain.Controls.Add(this.BtnPronounciation);
            this.PnlMain.Controls.Add(this.BtnExamPortuguese);
            this.PnlMain.Controls.Add(this.button1);
            this.PnlMain.Controls.Add(this.BtnCorrection);
            this.PnlMain.Controls.Add(this.BtnReload);
            this.PnlMain.Controls.Add(this.BtnSetWeek);
            this.PnlMain.Controls.Add(this.LblIndex);
            this.PnlMain.Controls.Add(this.CBHideChinese);
            this.PnlMain.Controls.Add(this.CBHideText);
            this.PnlMain.Controls.Add(this.BtnNext);
            this.PnlMain.Controls.Add(this.BtnPrev);
            this.PnlMain.Controls.Add(this.BtnReadSentence);
            this.PnlMain.Controls.Add(this.TbSentenceChinese);
            this.PnlMain.Controls.Add(this.TbSentence);
            this.PnlMain.Controls.Add(this.TBChineseMeaning);
            this.PnlMain.Controls.Add(this.TBText);
            this.PnlMain.Controls.Add(this.BtnRead);
            this.PnlMain.Location = new System.Drawing.Point(36, 12);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1412, 691);
            this.PnlMain.TabIndex = 33;
            // 
            // LblTotalScores
            // 
            this.LblTotalScores.AutoSize = true;
            this.LblTotalScores.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTotalScores.Location = new System.Drawing.Point(95, 58);
            this.LblTotalScores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTotalScores.Name = "LblTotalScores";
            this.LblTotalScores.Size = new System.Drawing.Size(197, 33);
            this.LblTotalScores.TabIndex = 41;
            this.LblTotalScores.Text = "累计得分：0";
            // 
            // BtnExamChineseMeaning
            // 
            this.BtnExamChineseMeaning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExamChineseMeaning.Location = new System.Drawing.Point(1029, 58);
            this.BtnExamChineseMeaning.Name = "BtnExamChineseMeaning";
            this.BtnExamChineseMeaning.Size = new System.Drawing.Size(114, 56);
            this.BtnExamChineseMeaning.TabIndex = 39;
            this.BtnExamChineseMeaning.Text = "测验含义";
            this.BtnExamChineseMeaning.UseVisualStyleBackColor = true;
            this.BtnExamChineseMeaning.Click += new System.EventHandler(this.BtnExamChineseMeaning_Click);
            // 
            // BtnPronounciation
            // 
            this.BtnPronounciation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPronounciation.Location = new System.Drawing.Point(1273, 58);
            this.BtnPronounciation.Name = "BtnPronounciation";
            this.BtnPronounciation.Size = new System.Drawing.Size(114, 56);
            this.BtnPronounciation.TabIndex = 38;
            this.BtnPronounciation.Text = "发音练习";
            this.BtnPronounciation.UseVisualStyleBackColor = true;
            this.BtnPronounciation.Click += new System.EventHandler(this.BtnPronounciation_Click);
            // 
            // BtnExamPortuguese
            // 
            this.BtnExamPortuguese.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExamPortuguese.Location = new System.Drawing.Point(1151, 58);
            this.BtnExamPortuguese.Name = "BtnExamPortuguese";
            this.BtnExamPortuguese.Size = new System.Drawing.Size(114, 56);
            this.BtnExamPortuguese.TabIndex = 37;
            this.BtnExamPortuguese.Text = "测验葡语";
            this.BtnExamPortuguese.UseVisualStyleBackColor = true;
            this.BtnExamPortuguese.Click += new System.EventHandler(this.BtnExamPortuguese_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(1274, 540);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 56);
            this.button1.TabIndex = 36;
            this.button1.Text = "查看余额";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnCorrection
            // 
            this.BtnCorrection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCorrection.Location = new System.Drawing.Point(1154, 540);
            this.BtnCorrection.Name = "BtnCorrection";
            this.BtnCorrection.Size = new System.Drawing.Size(114, 56);
            this.BtnCorrection.TabIndex = 35;
            this.BtnCorrection.Text = "归还分数";
            this.BtnCorrection.UseVisualStyleBackColor = true;
            this.BtnCorrection.Click += new System.EventHandler(this.BtnCorrection_Click);
            // 
            // BtnReload
            // 
            this.BtnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReload.Location = new System.Drawing.Point(1154, 602);
            this.BtnReload.Name = "BtnReload";
            this.BtnReload.Size = new System.Drawing.Size(114, 56);
            this.BtnReload.TabIndex = 34;
            this.BtnReload.Text = "重新加载";
            this.BtnReload.UseVisualStyleBackColor = true;
            this.BtnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // BtnSetWeek
            // 
            this.BtnSetWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetWeek.Location = new System.Drawing.Point(1274, 602);
            this.BtnSetWeek.Name = "BtnSetWeek";
            this.BtnSetWeek.Size = new System.Drawing.Size(114, 56);
            this.BtnSetWeek.TabIndex = 33;
            this.BtnSetWeek.Text = "周计划";
            this.BtnSetWeek.UseVisualStyleBackColor = true;
            this.BtnSetWeek.Click += new System.EventHandler(this.BtnSetWeek_Click);
            // 
            // LblIndex
            // 
            this.LblIndex.AutoSize = true;
            this.LblIndex.Location = new System.Drawing.Point(312, 568);
            this.LblIndex.Name = "LblIndex";
            this.LblIndex.Size = new System.Drawing.Size(35, 18);
            this.LblIndex.TabIndex = 23;
            this.LblIndex.Text = "1/6";
            // 
            // CBHideChinese
            // 
            this.CBHideChinese.AutoSize = true;
            this.CBHideChinese.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBHideChinese.Location = new System.Drawing.Point(755, 592);
            this.CBHideChinese.Name = "CBHideChinese";
            this.CBHideChinese.Size = new System.Drawing.Size(150, 32);
            this.CBHideChinese.TabIndex = 22;
            this.CBHideChinese.Text = "隐藏中文";
            this.CBHideChinese.UseVisualStyleBackColor = true;
            this.CBHideChinese.Click += new System.EventHandler(this.CBHideChinese_CheckedChanged);
            // 
            // CBHideText
            // 
            this.CBHideText.AutoSize = true;
            this.CBHideText.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBHideText.Location = new System.Drawing.Point(755, 540);
            this.CBHideText.Name = "CBHideText";
            this.CBHideText.Size = new System.Drawing.Size(150, 32);
            this.CBHideText.TabIndex = 21;
            this.CBHideText.Text = "隐藏单词";
            this.CBHideText.UseVisualStyleBackColor = true;
            this.CBHideText.Click += new System.EventHandler(this.CBHideText_CheckedChanged);
            // 
            // BtnNext
            // 
            this.BtnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNext.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnNext.Location = new System.Drawing.Point(378, 540);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(180, 76);
            this.BtnNext.TabIndex = 20;
            this.BtnNext.Text = "下一个";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrev.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPrev.Location = new System.Drawing.Point(101, 540);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(180, 76);
            this.BtnPrev.TabIndex = 19;
            this.BtnPrev.Text = "上一个";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnReadSentence
            // 
            this.BtnReadSentence.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReadSentence.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReadSentence.Location = new System.Drawing.Point(795, 310);
            this.BtnReadSentence.Name = "BtnReadSentence";
            this.BtnReadSentence.Size = new System.Drawing.Size(104, 46);
            this.BtnReadSentence.TabIndex = 18;
            this.BtnReadSentence.Text = "声音";
            this.BtnReadSentence.UseVisualStyleBackColor = true;
            this.BtnReadSentence.Click += new System.EventHandler(this.BtnReadSentence_Click);
            // 
            // TbSentenceChinese
            // 
            this.TbSentenceChinese.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbSentenceChinese.Location = new System.Drawing.Point(93, 388);
            this.TbSentenceChinese.Name = "TbSentenceChinese";
            this.TbSentenceChinese.ReadOnly = true;
            this.TbSentenceChinese.Size = new System.Drawing.Size(662, 42);
            this.TbSentenceChinese.TabIndex = 17;
            this.TbSentenceChinese.Text = "请擦掉黑板。";
            // 
            // TbSentence
            // 
            this.TbSentence.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbSentence.Location = new System.Drawing.Point(93, 311);
            this.TbSentence.Name = "TbSentence";
            this.TbSentence.ReadOnly = true;
            this.TbSentence.Size = new System.Drawing.Size(662, 42);
            this.TbSentence.TabIndex = 16;
            this.TbSentence.Text = "Apague o quadro, por favor.";
            // 
            // TBChineseMeaning
            // 
            this.TBChineseMeaning.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBChineseMeaning.Location = new System.Drawing.Point(93, 234);
            this.TBChineseMeaning.Name = "TBChineseMeaning";
            this.TBChineseMeaning.ReadOnly = true;
            this.TBChineseMeaning.Size = new System.Drawing.Size(662, 42);
            this.TBChineseMeaning.TabIndex = 15;
            this.TBChineseMeaning.Text = "擦掉";
            // 
            // TBText
            // 
            this.TBText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBText.Location = new System.Drawing.Point(93, 160);
            this.TBText.Name = "TBText";
            this.TBText.ReadOnly = true;
            this.TBText.Size = new System.Drawing.Size(662, 42);
            this.TBText.TabIndex = 14;
            this.TBText.Text = "Apagar";
            // 
            // BtnRead
            // 
            this.BtnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRead.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRead.Location = new System.Drawing.Point(795, 156);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(104, 46);
            this.BtnRead.TabIndex = 13;
            this.BtnRead.Text = "声音";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnReadWordText_Click);
            // 
            // RBToday
            // 
            this.RBToday.AutoSize = true;
            this.RBToday.Checked = true;
            this.RBToday.Location = new System.Drawing.Point(1074, 156);
            this.RBToday.Name = "RBToday";
            this.RBToday.Size = new System.Drawing.Size(69, 22);
            this.RBToday.TabIndex = 42;
            this.RBToday.TabStop = true;
            this.RBToday.Text = "今天";
            this.RBToday.UseVisualStyleBackColor = true;
            // 
            // RBYesterday
            // 
            this.RBYesterday.AutoSize = true;
            this.RBYesterday.Location = new System.Drawing.Point(1174, 156);
            this.RBYesterday.Name = "RBYesterday";
            this.RBYesterday.Size = new System.Drawing.Size(69, 22);
            this.RBYesterday.TabIndex = 43;
            this.RBYesterday.Text = "之前";
            this.RBYesterday.UseVisualStyleBackColor = true;
            // 
            // RBTomorrow
            // 
            this.RBTomorrow.AutoSize = true;
            this.RBTomorrow.Location = new System.Drawing.Point(1274, 156);
            this.RBTomorrow.Name = "RBTomorrow";
            this.RBTomorrow.Size = new System.Drawing.Size(69, 22);
            this.RBTomorrow.TabIndex = 44;
            this.RBTomorrow.Text = "明天";
            this.RBTomorrow.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 775);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "单词记忆";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblDay;
        private System.Windows.Forms.ToolStripStatusLabel LblDate;
        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Button BtnExamChineseMeaning;
        private System.Windows.Forms.Button BtnPronounciation;
        private System.Windows.Forms.Button BtnExamPortuguese;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnCorrection;
        private System.Windows.Forms.Button BtnReload;
        private System.Windows.Forms.Button BtnSetWeek;
        private System.Windows.Forms.Label LblIndex;
        private System.Windows.Forms.CheckBox CBHideChinese;
        private System.Windows.Forms.CheckBox CBHideText;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnReadSentence;
        private System.Windows.Forms.TextBox TbSentenceChinese;
        private System.Windows.Forms.TextBox TbSentence;
        private System.Windows.Forms.TextBox TBChineseMeaning;
        private System.Windows.Forms.TextBox TBText;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.Label LblTotalScores;
        private System.Windows.Forms.RadioButton RBTomorrow;
        private System.Windows.Forms.RadioButton RBYesterday;
        private System.Windows.Forms.RadioButton RBToday;
    }
}


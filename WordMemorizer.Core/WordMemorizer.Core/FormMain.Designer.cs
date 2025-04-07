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
            this.BtnRead = new System.Windows.Forms.Button();
            this.TBText = new System.Windows.Forms.TextBox();
            this.TBChineseMeaning = new System.Windows.Forms.TextBox();
            this.BtnSetWeek = new System.Windows.Forms.Button();
            this.TbSentence = new System.Windows.Forms.TextBox();
            this.TbSentenceChinese = new System.Windows.Forms.TextBox();
            this.BtnReadSentence = new System.Windows.Forms.Button();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.CBHideText = new System.Windows.Forms.CheckBox();
            this.CBHideChinese = new System.Windows.Forms.CheckBox();
            this.LblIndex = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblDay = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnReload = new System.Windows.Forms.Button();
            this.BtnExamPortuguese = new System.Windows.Forms.Button();
            this.BtnPronounciation = new System.Windows.Forms.Button();
            this.BtnExamChineseMeaning = new System.Windows.Forms.Button();
            this.CHKIsExam = new System.Windows.Forms.CheckBox();
            this.BtnCorrection = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnRead
            // 
            this.BtnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRead.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRead.Location = new System.Drawing.Point(605, 63);
            this.BtnRead.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(69, 31);
            this.BtnRead.TabIndex = 0;
            this.BtnRead.Text = "声音";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnReadWordText_Click);
            // 
            // TBText
            // 
            this.TBText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBText.Location = new System.Drawing.Point(137, 65);
            this.TBText.Margin = new System.Windows.Forms.Padding(2);
            this.TBText.Name = "TBText";
            this.TBText.ReadOnly = true;
            this.TBText.Size = new System.Drawing.Size(443, 30);
            this.TBText.TabIndex = 1;
            this.TBText.Text = "Apagar";
            // 
            // TBChineseMeaning
            // 
            this.TBChineseMeaning.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBChineseMeaning.Location = new System.Drawing.Point(137, 115);
            this.TBChineseMeaning.Margin = new System.Windows.Forms.Padding(2);
            this.TBChineseMeaning.Name = "TBChineseMeaning";
            this.TBChineseMeaning.ReadOnly = true;
            this.TBChineseMeaning.Size = new System.Drawing.Size(443, 30);
            this.TBChineseMeaning.TabIndex = 2;
            this.TBChineseMeaning.Text = "擦掉";
            // 
            // BtnSetWeek
            // 
            this.BtnSetWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetWeek.Location = new System.Drawing.Point(812, 379);
            this.BtnSetWeek.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSetWeek.Name = "BtnSetWeek";
            this.BtnSetWeek.Size = new System.Drawing.Size(76, 37);
            this.BtnSetWeek.TabIndex = 3;
            this.BtnSetWeek.Text = "周计划";
            this.BtnSetWeek.UseVisualStyleBackColor = true;
            this.BtnSetWeek.Click += new System.EventHandler(this.BtnSetWeek_Click);
            // 
            // TbSentence
            // 
            this.TbSentence.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbSentence.Location = new System.Drawing.Point(137, 166);
            this.TbSentence.Margin = new System.Windows.Forms.Padding(2);
            this.TbSentence.Name = "TbSentence";
            this.TbSentence.ReadOnly = true;
            this.TbSentence.Size = new System.Drawing.Size(443, 30);
            this.TbSentence.TabIndex = 5;
            this.TbSentence.Text = "Apague o quadro, por favor.";
            // 
            // TbSentenceChinese
            // 
            this.TbSentenceChinese.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbSentenceChinese.Location = new System.Drawing.Point(137, 217);
            this.TbSentenceChinese.Margin = new System.Windows.Forms.Padding(2);
            this.TbSentenceChinese.Name = "TbSentenceChinese";
            this.TbSentenceChinese.ReadOnly = true;
            this.TbSentenceChinese.Size = new System.Drawing.Size(443, 30);
            this.TbSentenceChinese.TabIndex = 6;
            this.TbSentenceChinese.Text = "请擦掉黑板。";
            // 
            // BtnReadSentence
            // 
            this.BtnReadSentence.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReadSentence.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReadSentence.Location = new System.Drawing.Point(605, 165);
            this.BtnReadSentence.Margin = new System.Windows.Forms.Padding(2);
            this.BtnReadSentence.Name = "BtnReadSentence";
            this.BtnReadSentence.Size = new System.Drawing.Size(69, 31);
            this.BtnReadSentence.TabIndex = 7;
            this.BtnReadSentence.Text = "声音";
            this.BtnReadSentence.UseVisualStyleBackColor = true;
            this.BtnReadSentence.Click += new System.EventHandler(this.BtnReadSentence_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrev.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPrev.Location = new System.Drawing.Point(137, 284);
            this.BtnPrev.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(120, 51);
            this.BtnPrev.TabIndex = 8;
            this.BtnPrev.Text = "上一个";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNext.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnNext.Location = new System.Drawing.Point(322, 284);
            this.BtnNext.Margin = new System.Windows.Forms.Padding(2);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(120, 51);
            this.BtnNext.TabIndex = 9;
            this.BtnNext.Text = "下一个";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // CBHideText
            // 
            this.CBHideText.AutoSize = true;
            this.CBHideText.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBHideText.Location = new System.Drawing.Point(573, 284);
            this.CBHideText.Margin = new System.Windows.Forms.Padding(2);
            this.CBHideText.Name = "CBHideText";
            this.CBHideText.Size = new System.Drawing.Size(104, 23);
            this.CBHideText.TabIndex = 10;
            this.CBHideText.Text = "隐藏单词";
            this.CBHideText.UseVisualStyleBackColor = true;
            this.CBHideText.CheckedChanged += new System.EventHandler(this.CBHideText_CheckedChanged);
            // 
            // CBHideChinese
            // 
            this.CBHideChinese.AutoSize = true;
            this.CBHideChinese.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBHideChinese.Location = new System.Drawing.Point(573, 319);
            this.CBHideChinese.Margin = new System.Windows.Forms.Padding(2);
            this.CBHideChinese.Name = "CBHideChinese";
            this.CBHideChinese.Size = new System.Drawing.Size(104, 23);
            this.CBHideChinese.TabIndex = 11;
            this.CBHideChinese.Text = "隐藏中文";
            this.CBHideChinese.UseVisualStyleBackColor = true;
            this.CBHideChinese.CheckedChanged += new System.EventHandler(this.CBHideChinese_CheckedChanged);
            // 
            // LblIndex
            // 
            this.LblIndex.AutoSize = true;
            this.LblIndex.Location = new System.Drawing.Point(278, 303);
            this.LblIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblIndex.Name = "LblIndex";
            this.LblIndex.Size = new System.Drawing.Size(23, 12);
            this.LblIndex.TabIndex = 12;
            this.LblIndex.Text = "1/6";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblDay,
            this.LblDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(907, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblDay
            // 
            this.LblDay.BackColor = System.Drawing.SystemColors.Control;
            this.LblDay.ForeColor = System.Drawing.Color.Black;
            this.LblDay.Name = "LblDay";
            this.LblDay.Size = new System.Drawing.Size(47, 17);
            this.LblDay.Text = "LblDay";
            // 
            // LblDate
            // 
            this.LblDate.ForeColor = System.Drawing.Color.Black;
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(131, 17);
            this.LblDate.Text = "toolStripStatusLabel2";
            // 
            // BtnReload
            // 
            this.BtnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReload.Location = new System.Drawing.Point(729, 379);
            this.BtnReload.Margin = new System.Windows.Forms.Padding(2);
            this.BtnReload.Name = "BtnReload";
            this.BtnReload.Size = new System.Drawing.Size(76, 37);
            this.BtnReload.TabIndex = 14;
            this.BtnReload.Text = "重新加载";
            this.BtnReload.UseVisualStyleBackColor = true;
            this.BtnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // BtnExamPortuguese
            // 
            this.BtnExamPortuguese.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExamPortuguese.Location = new System.Drawing.Point(813, 111);
            this.BtnExamPortuguese.Margin = new System.Windows.Forms.Padding(2);
            this.BtnExamPortuguese.Name = "BtnExamPortuguese";
            this.BtnExamPortuguese.Size = new System.Drawing.Size(76, 37);
            this.BtnExamPortuguese.TabIndex = 15;
            this.BtnExamPortuguese.Text = "测验葡语";
            this.BtnExamPortuguese.UseVisualStyleBackColor = true;
            this.BtnExamPortuguese.Click += new System.EventHandler(this.BtnExamPortuguese_Click);
            // 
            // BtnPronounciation
            // 
            this.BtnPronounciation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPronounciation.Location = new System.Drawing.Point(813, 161);
            this.BtnPronounciation.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPronounciation.Name = "BtnPronounciation";
            this.BtnPronounciation.Size = new System.Drawing.Size(76, 37);
            this.BtnPronounciation.TabIndex = 16;
            this.BtnPronounciation.Text = "发音练习";
            this.BtnPronounciation.UseVisualStyleBackColor = true;
            this.BtnPronounciation.Click += new System.EventHandler(this.BtnPronounciation_Click);
            // 
            // BtnExamChineseMeaning
            // 
            this.BtnExamChineseMeaning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExamChineseMeaning.Location = new System.Drawing.Point(813, 60);
            this.BtnExamChineseMeaning.Margin = new System.Windows.Forms.Padding(2);
            this.BtnExamChineseMeaning.Name = "BtnExamChineseMeaning";
            this.BtnExamChineseMeaning.Size = new System.Drawing.Size(76, 37);
            this.BtnExamChineseMeaning.TabIndex = 17;
            this.BtnExamChineseMeaning.Text = "测验含义";
            this.BtnExamChineseMeaning.UseVisualStyleBackColor = true;
            this.BtnExamChineseMeaning.Click += new System.EventHandler(this.BtnExamChineseMeaning_Click);
            // 
            // CHKIsExam
            // 
            this.CHKIsExam.AutoSize = true;
            this.CHKIsExam.Checked = true;
            this.CHKIsExam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHKIsExam.Location = new System.Drawing.Point(813, 209);
            this.CHKIsExam.Margin = new System.Windows.Forms.Padding(2);
            this.CHKIsExam.Name = "CHKIsExam";
            this.CHKIsExam.Size = new System.Drawing.Size(72, 16);
            this.CHKIsExam.TabIndex = 18;
            this.CHKIsExam.Text = "测验今天";
            this.CHKIsExam.UseVisualStyleBackColor = true;
            // 
            // BtnCorrection
            // 
            this.BtnCorrection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCorrection.Location = new System.Drawing.Point(646, 379);
            this.BtnCorrection.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCorrection.Name = "BtnCorrection";
            this.BtnCorrection.Size = new System.Drawing.Size(76, 37);
            this.BtnCorrection.TabIndex = 19;
            this.BtnCorrection.Text = "归还分数";
            this.BtnCorrection.UseVisualStyleBackColor = true;
            this.BtnCorrection.Click += new System.EventHandler(this.BtnCorrection_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 445);
            this.Controls.Add(this.BtnCorrection);
            this.Controls.Add(this.CHKIsExam);
            this.Controls.Add(this.BtnExamChineseMeaning);
            this.Controls.Add(this.BtnPronounciation);
            this.Controls.Add(this.BtnExamPortuguese);
            this.Controls.Add(this.BtnReload);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.LblIndex);
            this.Controls.Add(this.CBHideChinese);
            this.Controls.Add(this.CBHideText);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnPrev);
            this.Controls.Add(this.BtnReadSentence);
            this.Controls.Add(this.TbSentenceChinese);
            this.Controls.Add(this.TbSentence);
            this.Controls.Add(this.BtnSetWeek);
            this.Controls.Add(this.TBChineseMeaning);
            this.Controls.Add(this.TBText);
            this.Controls.Add(this.BtnRead);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "单词记忆";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.TextBox TBText;
        private System.Windows.Forms.TextBox TBChineseMeaning;
        private System.Windows.Forms.Button BtnSetWeek;
        private System.Windows.Forms.TextBox TbSentence;
        private System.Windows.Forms.TextBox TbSentenceChinese;
        private System.Windows.Forms.Button BtnReadSentence;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.CheckBox CBHideText;
        private System.Windows.Forms.CheckBox CBHideChinese;
        private System.Windows.Forms.Label LblIndex;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblDay;
        private System.Windows.Forms.ToolStripStatusLabel LblDate;
        private System.Windows.Forms.Button BtnReload;
        private System.Windows.Forms.Button BtnExamPortuguese;
        private System.Windows.Forms.Button BtnPronounciation;
        private System.Windows.Forms.Button BtnExamChineseMeaning;
        private System.Windows.Forms.CheckBox CHKIsExam;
        private System.Windows.Forms.Button BtnCorrection;
    }
}


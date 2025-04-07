namespace WordMemorizer.Core
{
    partial class FormExam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExam));
            this.TbChinese = new System.Windows.Forms.TextBox();
            this.TbText = new System.Windows.Forms.TextBox();
            this.PbResult = new System.Windows.Forms.PictureBox();
            this.pbWaveform = new System.Windows.Forms.PictureBox();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.LblIndex = new System.Windows.Forms.Label();
            this.LblThisRoundScores = new System.Windows.Forms.Label();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnRead = new System.Windows.Forms.Button();
            this.BtnListenSelf = new System.Windows.Forms.Button();
            this.LblTotalScores = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWaveform)).BeginInit();
            this.SuspendLayout();
            // 
            // TbChinese
            // 
            this.TbChinese.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbChinese.Location = new System.Drawing.Point(97, 375);
            this.TbChinese.Name = "TbChinese";
            this.TbChinese.ReadOnly = true;
            this.TbChinese.Size = new System.Drawing.Size(406, 30);
            this.TbChinese.TabIndex = 8;
            // 
            // TbText
            // 
            this.TbText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbText.Location = new System.Drawing.Point(97, 292);
            this.TbText.Name = "TbText";
            this.TbText.ReadOnly = true;
            this.TbText.Size = new System.Drawing.Size(403, 30);
            this.TbText.TabIndex = 7;
            // 
            // PbResult
            // 
            this.PbResult.Image = ((System.Drawing.Image)(resources.GetObject("PbResult.Image")));
            this.PbResult.Location = new System.Drawing.Point(756, 118);
            this.PbResult.Name = "PbResult";
            this.PbResult.Size = new System.Drawing.Size(321, 259);
            this.PbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbResult.TabIndex = 14;
            this.PbResult.TabStop = false;
            // 
            // pbWaveform
            // 
            this.pbWaveform.BackColor = System.Drawing.Color.Black;
            this.pbWaveform.Location = new System.Drawing.Point(756, 413);
            this.pbWaveform.Name = "pbWaveform";
            this.pbWaveform.Size = new System.Drawing.Size(321, 50);
            this.pbWaveform.TabIndex = 13;
            this.pbWaveform.TabStop = false;
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopRecording.Location = new System.Drawing.Point(962, 469);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(115, 50);
            this.btnStopRecording.TabIndex = 12;
            this.btnStopRecording.Text = "结束";
            this.btnStopRecording.UseVisualStyleBackColor = true;
            this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartRecording.Location = new System.Drawing.Point(756, 469);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(115, 50);
            this.btnStartRecording.TabIndex = 11;
            this.btnStartRecording.Text = "开始";
            this.btnStartRecording.UseVisualStyleBackColor = true;
            this.btnStartRecording.Click += new System.EventHandler(this.btnStartRecording_Click);
            // 
            // LblIndex
            // 
            this.LblIndex.AutoSize = true;
            this.LblIndex.Location = new System.Drawing.Point(281, 484);
            this.LblIndex.Name = "LblIndex";
            this.LblIndex.Size = new System.Drawing.Size(28, 14);
            this.LblIndex.TabIndex = 17;
            this.LblIndex.Text = "0/0";
            this.LblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblThisRoundScores
            // 
            this.LblThisRoundScores.AutoSize = true;
            this.LblThisRoundScores.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblThisRoundScores.Location = new System.Drawing.Point(94, 118);
            this.LblThisRoundScores.Name = "LblThisRoundScores";
            this.LblThisRoundScores.Size = new System.Drawing.Size(290, 48);
            this.LblThisRoundScores.TabIndex = 18;
            this.LblThisRoundScores.Text = "本轮得分：0";
            // 
            // BtnNext
            // 
            this.BtnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNext.Location = new System.Drawing.Point(346, 463);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(154, 56);
            this.BtnNext.TabIndex = 19;
            this.BtnNext.Text = "继续";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnRead
            // 
            this.BtnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRead.Location = new System.Drawing.Point(506, 292);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(111, 42);
            this.BtnRead.TabIndex = 20;
            this.BtnRead.Text = "教我读";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Visible = false;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // BtnListenSelf
            // 
            this.BtnListenSelf.Location = new System.Drawing.Point(1097, 413);
            this.BtnListenSelf.Name = "BtnListenSelf";
            this.BtnListenSelf.Size = new System.Drawing.Size(50, 50);
            this.BtnListenSelf.TabIndex = 21;
            this.BtnListenSelf.Text = "听";
            this.BtnListenSelf.UseVisualStyleBackColor = true;
            this.BtnListenSelf.Click += new System.EventHandler(this.BtnListenSelf_Click);
            // 
            // LblTotalScores
            // 
            this.LblTotalScores.AutoSize = true;
            this.LblTotalScores.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTotalScores.Location = new System.Drawing.Point(94, 53);
            this.LblTotalScores.Name = "LblTotalScores";
            this.LblTotalScores.Size = new System.Drawing.Size(290, 48);
            this.LblTotalScores.TabIndex = 22;
            this.LblTotalScores.Text = "累计得分：0";
            // 
            // FormExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 672);
            this.Controls.Add(this.LblTotalScores);
            this.Controls.Add(this.BtnListenSelf);
            this.Controls.Add(this.BtnRead);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.LblThisRoundScores);
            this.Controls.Add(this.LblIndex);
            this.Controls.Add(this.PbResult);
            this.Controls.Add(this.pbWaveform);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.btnStartRecording);
            this.Controls.Add(this.TbChinese);
            this.Controls.Add(this.TbText);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测验";
            this.Load += new System.EventHandler(this.FormExam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWaveform)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbChinese;
        private System.Windows.Forms.TextBox TbText;
        private System.Windows.Forms.PictureBox PbResult;
        private System.Windows.Forms.PictureBox pbWaveform;
        private System.Windows.Forms.Button btnStopRecording;
        private System.Windows.Forms.Button btnStartRecording;
        private System.Windows.Forms.Label LblIndex;
        private System.Windows.Forms.Label LblThisRoundScores;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.Button BtnListenSelf;
        private System.Windows.Forms.Label LblTotalScores;
    }
}
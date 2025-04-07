using System;
using System.Drawing;
using System.Windows.Forms;

namespace WordMemorizer.Core
{
    partial class FormPronunciation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPronunciation));
            this.TbText = new System.Windows.Forms.TextBox();
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.pbWaveform = new System.Windows.Forms.PictureBox();
            this.BtnRead = new System.Windows.Forms.Button();
            this.TbChinese = new System.Windows.Forms.TextBox();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.PbResult = new System.Windows.Forms.PictureBox();
            this.LblIndex = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbWaveform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // TbText
            // 
            this.TbText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbText.Location = new System.Drawing.Point(125, 51);
            this.TbText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbText.Name = "TbText";
            this.TbText.ReadOnly = true;
            this.TbText.Size = new System.Drawing.Size(270, 30);
            this.TbText.TabIndex = 1;
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartRecording.Location = new System.Drawing.Point(538, 285);
            this.btnStartRecording.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(77, 33);
            this.btnStartRecording.TabIndex = 2;
            this.btnStartRecording.Text = "开始";
            this.btnStartRecording.UseVisualStyleBackColor = true;
            this.btnStartRecording.Click += new System.EventHandler(this.BtnStartRecording_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopRecording.Location = new System.Drawing.Point(675, 285);
            this.btnStopRecording.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(77, 33);
            this.btnStopRecording.TabIndex = 3;
            this.btnStopRecording.Text = "结束";
            this.btnStopRecording.UseVisualStyleBackColor = true;
            this.btnStopRecording.Click += new System.EventHandler(this.BtnStopRecording_Click);
            // 
            // pbWaveform
            // 
            this.pbWaveform.BackColor = System.Drawing.Color.Black;
            this.pbWaveform.Location = new System.Drawing.Point(538, 248);
            this.pbWaveform.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbWaveform.Name = "pbWaveform";
            this.pbWaveform.Size = new System.Drawing.Size(214, 33);
            this.pbWaveform.TabIndex = 4;
            this.pbWaveform.TabStop = false;
            // 
            // BtnRead
            // 
            this.BtnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRead.Location = new System.Drawing.Point(398, 51);
            this.BtnRead.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(74, 28);
            this.BtnRead.TabIndex = 5;
            this.BtnRead.Text = "提示";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // TbChinese
            // 
            this.TbChinese.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbChinese.Location = new System.Drawing.Point(125, 107);
            this.TbChinese.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbChinese.Name = "TbChinese";
            this.TbChinese.ReadOnly = true;
            this.TbChinese.Size = new System.Drawing.Size(272, 30);
            this.TbChinese.TabIndex = 6;
            // 
            // BtnPrev
            // 
            this.BtnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrev.Location = new System.Drawing.Point(130, 199);
            this.BtnPrev.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(103, 37);
            this.BtnPrev.TabIndex = 7;
            this.BtnPrev.Text = "上一个";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNext.Location = new System.Drawing.Point(293, 199);
            this.BtnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(103, 37);
            this.BtnNext.TabIndex = 8;
            this.BtnNext.Text = "下一个";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // PbResult
            // 
            this.PbResult.Image = ((System.Drawing.Image)(resources.GetObject("PbResult.Image")));
            this.PbResult.Location = new System.Drawing.Point(538, 51);
            this.PbResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PbResult.Name = "PbResult";
            this.PbResult.Size = new System.Drawing.Size(214, 173);
            this.PbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbResult.TabIndex = 10;
            this.PbResult.TabStop = false;
            // 
            // LblIndex
            // 
            this.LblIndex.AutoSize = true;
            this.LblIndex.Location = new System.Drawing.Point(251, 212);
            this.LblIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblIndex.Name = "LblIndex";
            this.LblIndex.Size = new System.Drawing.Size(23, 12);
            this.LblIndex.TabIndex = 11;
            this.LblIndex.Text = "0/0";
            this.LblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPronunciation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 367);
            this.Controls.Add(this.LblIndex);
            this.Controls.Add(this.PbResult);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnPrev);
            this.Controls.Add(this.TbChinese);
            this.Controls.Add(this.BtnRead);
            this.Controls.Add(this.pbWaveform);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.btnStartRecording);
            this.Controls.Add(this.TbText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormPronunciation";
            this.Text = "发音练习";
            this.Load += new System.EventHandler(this.FormPronunciation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbWaveform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox TbText;
        private Button btnStartRecording;
        private Button btnStopRecording;
        private PictureBox pbWaveform;
        private Button BtnRead;
        private TextBox TbChinese;
        private Button BtnPrev;
        private Button BtnNext;
        private PictureBox PbResult;
        private Label LblIndex;
    }
}
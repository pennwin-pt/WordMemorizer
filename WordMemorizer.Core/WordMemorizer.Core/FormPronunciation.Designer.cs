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
            this.TbText.Location = new System.Drawing.Point(188, 77);
            this.TbText.Name = "TbText";
            this.TbText.Size = new System.Drawing.Size(403, 42);
            this.TbText.TabIndex = 1;
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.Location = new System.Drawing.Point(807, 428);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(115, 50);
            this.btnStartRecording.TabIndex = 2;
            this.btnStartRecording.Text = "开始";
            this.btnStartRecording.UseVisualStyleBackColor = true;
            this.btnStartRecording.Click += new System.EventHandler(this.BtnStartRecording_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Location = new System.Drawing.Point(1013, 428);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(115, 50);
            this.btnStopRecording.TabIndex = 3;
            this.btnStopRecording.Text = "结束";
            this.btnStopRecording.UseVisualStyleBackColor = true;
            this.btnStopRecording.Click += new System.EventHandler(this.BtnStopRecording_Click);
            // 
            // pbWaveform
            // 
            this.pbWaveform.BackColor = System.Drawing.Color.Black;
            this.pbWaveform.Location = new System.Drawing.Point(807, 372);
            this.pbWaveform.Name = "pbWaveform";
            this.pbWaveform.Size = new System.Drawing.Size(321, 50);
            this.pbWaveform.TabIndex = 4;
            this.pbWaveform.TabStop = false;
            // 
            // BtnRead
            // 
            this.BtnRead.Location = new System.Drawing.Point(597, 77);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(111, 42);
            this.BtnRead.TabIndex = 5;
            this.BtnRead.Text = "提示";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // TbChinese
            // 
            this.TbChinese.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbChinese.Location = new System.Drawing.Point(188, 160);
            this.TbChinese.Name = "TbChinese";
            this.TbChinese.Size = new System.Drawing.Size(406, 42);
            this.TbChinese.TabIndex = 6;
            // 
            // BtnPrev
            // 
            this.BtnPrev.Location = new System.Drawing.Point(195, 299);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(154, 56);
            this.BtnPrev.TabIndex = 7;
            this.BtnPrev.Text = "上一个";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(440, 299);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(154, 56);
            this.BtnNext.TabIndex = 8;
            this.BtnNext.Text = "下一个";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // PbResult
            // 
            this.PbResult.Image = ((System.Drawing.Image)(resources.GetObject("PbResult.Image")));
            this.PbResult.Location = new System.Drawing.Point(807, 77);
            this.PbResult.Name = "PbResult";
            this.PbResult.Size = new System.Drawing.Size(321, 259);
            this.PbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbResult.TabIndex = 10;
            this.PbResult.TabStop = false;
            // 
            // LblIndex
            // 
            this.LblIndex.AutoSize = true;
            this.LblIndex.Location = new System.Drawing.Point(377, 318);
            this.LblIndex.Name = "LblIndex";
            this.LblIndex.Size = new System.Drawing.Size(35, 18);
            this.LblIndex.TabIndex = 11;
            this.LblIndex.Text = "0/0";
            this.LblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPronunciation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 550);
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
            this.Name = "FormPronunciation";
            this.Text = "发音测评";
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
using System.ComponentModel;

namespace InscryptionTextureConverter
{
    partial class ConvertTextureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertTextureForm));
            this.templateImage = new System.Windows.Forms.PictureBox();
            this.originalBackground = new System.Windows.Forms.PictureBox();
            this.originalPortrait = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.originalSelect = new System.Windows.Forms.Button();
            this.TrackPanelColor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.templateImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // templateImage
            // 
            this.templateImage.Image = ((System.Drawing.Image)(resources.GetObject("templateImage.Image")));
            this.templateImage.InitialImage = null;
            this.templateImage.Location = new System.Drawing.Point(290, 12);
            this.templateImage.Name = "templateImage";
            this.templateImage.Size = new System.Drawing.Size(114, 94);
            this.templateImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.templateImage.TabIndex = 0;
            this.templateImage.TabStop = false;
            this.templateImage.Click += new System.EventHandler(this.templateImage_Click);
            // 
            // originalBackground
            // 
            this.originalBackground.Image = ((System.Drawing.Image)(resources.GetObject("originalBackground.Image")));
            this.originalBackground.InitialImage = null;
            this.originalBackground.Location = new System.Drawing.Point(12, 113);
            this.originalBackground.Name = "originalBackground";
            this.originalBackground.Size = new System.Drawing.Size(125, 190);
            this.originalBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.originalBackground.TabIndex = 1;
            this.originalBackground.TabStop = false;
            // 
            // originalPortrait
            // 
            this.originalPortrait.BackColor = System.Drawing.Color.Transparent;
            this.originalPortrait.Image = ((System.Drawing.Image)(resources.GetObject("originalPortrait.Image")));
            this.originalPortrait.InitialImage = null;
            this.originalPortrait.Location = new System.Drawing.Point(23, 147);
            this.originalPortrait.Name = "originalPortrait";
            this.originalPortrait.Size = new System.Drawing.Size(114, 94);
            this.originalPortrait.TabIndex = 2;
            this.originalPortrait.TabStop = false;
            this.originalPortrait.Click += new System.EventHandler(this.originalPortrait_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(44, 338);
            this.trackBar1.Maximum = 6;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(83, 45);
            this.trackBar1.TabIndex = 16;
            // 
            // originalSelect
            // 
            this.originalSelect.Location = new System.Drawing.Point(12, 309);
            this.originalSelect.Name = "originalSelect";
            this.originalSelect.Size = new System.Drawing.Size(125, 23);
            this.originalSelect.TabIndex = 17;
            this.originalSelect.Text = "Select";
            this.originalSelect.UseVisualStyleBackColor = true;
            // 
            // TrackPanelColor
            // 
            this.TrackPanelColor.BackColor = System.Drawing.Color.White;
            this.TrackPanelColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TrackPanelColor.Location = new System.Drawing.Point(12, 338);
            this.TrackPanelColor.Name = "TrackPanelColor";
            this.TrackPanelColor.Size = new System.Drawing.Size(26, 25);
            this.TrackPanelColor.TabIndex = 18;
            // 
            // ConvertTextureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 680);
            this.Controls.Add(this.TrackPanelColor);
            this.Controls.Add(this.originalSelect);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.originalPortrait);
            this.Controls.Add(this.originalBackground);
            this.Controls.Add(this.templateImage);
            this.Name = "ConvertTextureForm";
            this.Text = "Convert Texture";
            this.Load += new System.EventHandler(this.ConvertTextureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.templateImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel TrackPanelColor;

        private System.Windows.Forms.Button originalSelect;

        private System.Windows.Forms.Button originalInvertButton;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TrackBar trackBar1;

        private System.Windows.Forms.PictureBox originalBackground;

        private System.Windows.Forms.PictureBox originalPortrait;

        private System.Windows.Forms.PictureBox templateImage;

        #endregion
    }
}
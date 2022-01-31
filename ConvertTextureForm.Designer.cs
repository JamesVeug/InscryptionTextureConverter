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
            this.minBackground = new System.Windows.Forms.PictureBox();
            this.maxBackground = new System.Windows.Forms.PictureBox();
            this.averageBackground = new System.Windows.Forms.PictureBox();
            this.medianBackground = new System.Windows.Forms.PictureBox();
            this.minPortrait = new System.Windows.Forms.PictureBox();
            this.maxPortrait = new System.Windows.Forms.PictureBox();
            this.averagePortrait = new System.Windows.Forms.PictureBox();
            this.medianPortrait = new System.Windows.Forms.PictureBox();
            this.originalSelectButton = new System.Windows.Forms.Button();
            this.minSelectButton = new System.Windows.Forms.Button();
            this.maxSelectButton = new System.Windows.Forms.Button();
            this.averageSelectButton = new System.Windows.Forms.Button();
            this.medianSelectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.templateImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.averageBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.averagePortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianPortrait)).BeginInit();
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
            this.originalBackground.Location = new System.Drawing.Point(12, 130);
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
            this.originalPortrait.Location = new System.Drawing.Point(23, 164);
            this.originalPortrait.Name = "originalPortrait";
            this.originalPortrait.Size = new System.Drawing.Size(114, 94);
            this.originalPortrait.TabIndex = 2;
            this.originalPortrait.TabStop = false;
            this.originalPortrait.Click += new System.EventHandler(this.originalPortrait_Click);
            // 
            // minBackground
            // 
            this.minBackground.Image = ((System.Drawing.Image)(resources.GetObject("minBackground.Image")));
            this.minBackground.InitialImage = null;
            this.minBackground.Location = new System.Drawing.Point(143, 130);
            this.minBackground.Name = "minBackground";
            this.minBackground.Size = new System.Drawing.Size(125, 190);
            this.minBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minBackground.TabIndex = 3;
            this.minBackground.TabStop = false;
            // 
            // maxBackground
            // 
            this.maxBackground.Image = ((System.Drawing.Image)(resources.GetObject("maxBackground.Image")));
            this.maxBackground.InitialImage = null;
            this.maxBackground.Location = new System.Drawing.Point(279, 130);
            this.maxBackground.Name = "maxBackground";
            this.maxBackground.Size = new System.Drawing.Size(125, 190);
            this.maxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.maxBackground.TabIndex = 4;
            this.maxBackground.TabStop = false;
            // 
            // averageBackground
            // 
            this.averageBackground.Image = ((System.Drawing.Image)(resources.GetObject("averageBackground.Image")));
            this.averageBackground.InitialImage = null;
            this.averageBackground.Location = new System.Drawing.Point(410, 130);
            this.averageBackground.Name = "averageBackground";
            this.averageBackground.Size = new System.Drawing.Size(125, 190);
            this.averageBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.averageBackground.TabIndex = 5;
            this.averageBackground.TabStop = false;
            // 
            // medianBackground
            // 
            this.medianBackground.Image = ((System.Drawing.Image)(resources.GetObject("medianBackground.Image")));
            this.medianBackground.InitialImage = null;
            this.medianBackground.Location = new System.Drawing.Point(541, 130);
            this.medianBackground.Name = "medianBackground";
            this.medianBackground.Size = new System.Drawing.Size(125, 190);
            this.medianBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.medianBackground.TabIndex = 6;
            this.medianBackground.TabStop = false;
            // 
            // minPortrait
            // 
            this.minPortrait.BackColor = System.Drawing.Color.Transparent;
            this.minPortrait.Location = new System.Drawing.Point(154, 164);
            this.minPortrait.Name = "minPortrait";
            this.minPortrait.Size = new System.Drawing.Size(114, 94);
            this.minPortrait.TabIndex = 7;
            this.minPortrait.TabStop = false;
            // 
            // maxPortrait
            // 
            this.maxPortrait.BackColor = System.Drawing.Color.Transparent;
            this.maxPortrait.Location = new System.Drawing.Point(290, 164);
            this.maxPortrait.Name = "maxPortrait";
            this.maxPortrait.Size = new System.Drawing.Size(114, 94);
            this.maxPortrait.TabIndex = 8;
            this.maxPortrait.TabStop = false;
            // 
            // averagePortrait
            // 
            this.averagePortrait.BackColor = System.Drawing.Color.Transparent;
            this.averagePortrait.Location = new System.Drawing.Point(421, 164);
            this.averagePortrait.Name = "averagePortrait";
            this.averagePortrait.Size = new System.Drawing.Size(114, 94);
            this.averagePortrait.TabIndex = 9;
            this.averagePortrait.TabStop = false;
            // 
            // medianPortrait
            // 
            this.medianPortrait.BackColor = System.Drawing.Color.Transparent;
            this.medianPortrait.Location = new System.Drawing.Point(550, 164);
            this.medianPortrait.Name = "medianPortrait";
            this.medianPortrait.Size = new System.Drawing.Size(114, 94);
            this.medianPortrait.TabIndex = 10;
            this.medianPortrait.TabStop = false;
            // 
            // originalSelectButton
            // 
            this.originalSelectButton.Location = new System.Drawing.Point(12, 326);
            this.originalSelectButton.Name = "originalSelectButton";
            this.originalSelectButton.Size = new System.Drawing.Size(125, 23);
            this.originalSelectButton.TabIndex = 11;
            this.originalSelectButton.Text = "Select";
            this.originalSelectButton.UseVisualStyleBackColor = true;
            this.originalSelectButton.Click += new System.EventHandler(this.originalSelectButton_Click);
            // 
            // minSelectButton
            // 
            this.minSelectButton.Location = new System.Drawing.Point(143, 326);
            this.minSelectButton.Name = "minSelectButton";
            this.minSelectButton.Size = new System.Drawing.Size(125, 23);
            this.minSelectButton.TabIndex = 12;
            this.minSelectButton.Text = "Select";
            this.minSelectButton.UseVisualStyleBackColor = true;
            this.minSelectButton.Click += new System.EventHandler(this.minSelectButton_Click);
            // 
            // maxSelectButton
            // 
            this.maxSelectButton.Location = new System.Drawing.Point(279, 326);
            this.maxSelectButton.Name = "maxSelectButton";
            this.maxSelectButton.Size = new System.Drawing.Size(125, 23);
            this.maxSelectButton.TabIndex = 13;
            this.maxSelectButton.Text = "Select";
            this.maxSelectButton.UseVisualStyleBackColor = true;
            this.maxSelectButton.Click += new System.EventHandler(this.maxSelectButton_Click);
            // 
            // averageSelectButton
            // 
            this.averageSelectButton.Location = new System.Drawing.Point(410, 326);
            this.averageSelectButton.Name = "averageSelectButton";
            this.averageSelectButton.Size = new System.Drawing.Size(125, 23);
            this.averageSelectButton.TabIndex = 14;
            this.averageSelectButton.Text = "Select";
            this.averageSelectButton.UseVisualStyleBackColor = true;
            this.averageSelectButton.Click += new System.EventHandler(this.averageSelectButton_Click);
            // 
            // medianSelectButton
            // 
            this.medianSelectButton.Location = new System.Drawing.Point(541, 326);
            this.medianSelectButton.Name = "medianSelectButton";
            this.medianSelectButton.Size = new System.Drawing.Size(125, 23);
            this.medianSelectButton.TabIndex = 15;
            this.medianSelectButton.Text = "Select";
            this.medianSelectButton.UseVisualStyleBackColor = true;
            this.medianSelectButton.Click += new System.EventHandler(this.medianSelectButton_Click);
            // 
            // ConvertTextureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 450);
            this.Controls.Add(this.medianSelectButton);
            this.Controls.Add(this.averageSelectButton);
            this.Controls.Add(this.maxSelectButton);
            this.Controls.Add(this.minSelectButton);
            this.Controls.Add(this.originalSelectButton);
            this.Controls.Add(this.medianPortrait);
            this.Controls.Add(this.averagePortrait);
            this.Controls.Add(this.maxPortrait);
            this.Controls.Add(this.minPortrait);
            this.Controls.Add(this.medianBackground);
            this.Controls.Add(this.averageBackground);
            this.Controls.Add(this.maxBackground);
            this.Controls.Add(this.minBackground);
            this.Controls.Add(this.originalPortrait);
            this.Controls.Add(this.originalBackground);
            this.Controls.Add(this.templateImage);
            this.Name = "ConvertTextureForm";
            this.Text = "ConvertTextureForm";
            this.Load += new System.EventHandler(this.ConvertTextureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.templateImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.averageBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.averagePortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianPortrait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button medianSelectButton;
        private System.Windows.Forms.PictureBox originalBackground;
        private System.Windows.Forms.PictureBox minBackground;
        private System.Windows.Forms.PictureBox maxBackground;

        private System.Windows.Forms.Button averageSelectButton;

        private System.Windows.Forms.Button maxSelectButton;

        private System.Windows.Forms.Button minSelectButton;

        private System.Windows.Forms.Button originalSelectButton;

        private System.Windows.Forms.PictureBox medianPortrait;
        private System.Windows.Forms.PictureBox minPortrait;
        private System.Windows.Forms.PictureBox maxPortrait;

        private System.Windows.Forms.PictureBox averageBackground;

        private System.Windows.Forms.PictureBox originalPortrait;

        private System.Windows.Forms.PictureBox medianBackground;

        private System.Windows.Forms.PictureBox templateImage;

        private System.Windows.Forms.PictureBox averagePortrait;

        #endregion
    }
}
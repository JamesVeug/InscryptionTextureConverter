namespace InscryptionTextureConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Portrait = new System.Windows.Forms.PictureBox();
            this.card = new System.Windows.Forms.PictureBox();
            this.BrowseBackground = new System.Windows.Forms.Button();
            this.BrowsePortrait = new System.Windows.Forms.Button();
            this.ConvertFileButton = new System.Windows.Forms.Button();
            this.BackgroundPath = new System.Windows.Forms.TextBox();
            this.PortraitText = new System.Windows.Forms.TextBox();
            this.SigilText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputDirectory = new System.Windows.Forms.TextBox();
            this.OutputBrowse = new System.Windows.Forms.Button();
            this.Sigil = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SigilBrowse = new System.Windows.Forms.TextBox();
            this.SiglButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TransparentColorButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.RemoveBackgroundButton = new System.Windows.Forms.Button();
            this.convertFolderButton = new System.Windows.Forms.Button();
            this.keepColorCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Portrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sigil)).BeginInit();
            this.SuspendLayout();
            // 
            // Portrait
            // 
            this.Portrait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Portrait.BackColor = System.Drawing.Color.Transparent;
            this.Portrait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Portrait.Image = ((System.Drawing.Image)(resources.GetObject("Portrait.Image")));
            this.Portrait.Location = new System.Drawing.Point(17, 140);
            this.Portrait.Name = "Portrait";
            this.Portrait.Size = new System.Drawing.Size(114, 94);
            this.Portrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Portrait.TabIndex = 3;
            this.Portrait.TabStop = false;
            // 
            // card
            // 
            this.card.Image = ((System.Drawing.Image)(resources.GetObject("card.Image")));
            this.card.InitialImage = null;
            this.card.Location = new System.Drawing.Point(12, 108);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(125, 190);
            this.card.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card.TabIndex = 2;
            this.card.TabStop = false;
            // 
            // BrowseBackground
            // 
            this.BrowseBackground.Location = new System.Drawing.Point(343, 13);
            this.BrowseBackground.Name = "BrowseBackground";
            this.BrowseBackground.Size = new System.Drawing.Size(28, 23);
            this.BrowseBackground.TabIndex = 4;
            this.BrowseBackground.Text = "...";
            this.BrowseBackground.UseVisualStyleBackColor = true;
            this.BrowseBackground.Click += new System.EventHandler(this.BrowseBackground_Click);
            // 
            // BrowsePortrait
            // 
            this.BrowsePortrait.Location = new System.Drawing.Point(343, 38);
            this.BrowsePortrait.Name = "BrowsePortrait";
            this.BrowsePortrait.Size = new System.Drawing.Size(28, 23);
            this.BrowsePortrait.TabIndex = 7;
            this.BrowsePortrait.Text = "...";
            this.BrowsePortrait.UseVisualStyleBackColor = true;
            this.BrowsePortrait.Click += new System.EventHandler(this.BrowsePortrait_Click);
            // 
            // ConvertFileButton
            // 
            this.ConvertFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertFileButton.Location = new System.Drawing.Point(510, 96);
            this.ConvertFileButton.Name = "ConvertFileButton";
            this.ConvertFileButton.Size = new System.Drawing.Size(278, 43);
            this.ConvertFileButton.TabIndex = 9;
            this.ConvertFileButton.Text = "Convert File";
            this.ConvertFileButton.UseVisualStyleBackColor = true;
            this.ConvertFileButton.Click += new System.EventHandler(this.ConvertFileButton_Click);
            // 
            // BackgroundPath
            // 
            this.BackgroundPath.Location = new System.Drawing.Point(93, 15);
            this.BackgroundPath.Name = "BackgroundPath";
            this.BackgroundPath.Size = new System.Drawing.Size(244, 20);
            this.BackgroundPath.TabIndex = 10;
            this.BackgroundPath.TextChanged += new System.EventHandler(this.BackgroundPath_TextChanged);
            // 
            // PortraitText
            // 
            this.PortraitText.Location = new System.Drawing.Point(93, 38);
            this.PortraitText.Name = "PortraitText";
            this.PortraitText.Size = new System.Drawing.Size(244, 20);
            this.PortraitText.TabIndex = 11;
            this.PortraitText.TextChanged += new System.EventHandler(this.PortraitText_TextChanged);
            // 
            // SigilText
            // 
            this.SigilText.Location = new System.Drawing.Point(93, 64);
            this.SigilText.Name = "SigilText";
            this.SigilText.Size = new System.Drawing.Size(244, 20);
            this.SigilText.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Background";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Portrait";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(429, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Output Folder";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutputDirectory
            // 
            this.OutputDirectory.Location = new System.Drawing.Point(510, 14);
            this.OutputDirectory.Name = "OutputDirectory";
            this.OutputDirectory.Size = new System.Drawing.Size(244, 20);
            this.OutputDirectory.TabIndex = 15;
            // 
            // OutputBrowse
            // 
            this.OutputBrowse.Location = new System.Drawing.Point(760, 12);
            this.OutputBrowse.Name = "OutputBrowse";
            this.OutputBrowse.Size = new System.Drawing.Size(28, 23);
            this.OutputBrowse.TabIndex = 14;
            this.OutputBrowse.Text = "...";
            this.OutputBrowse.UseVisualStyleBackColor = true;
            this.OutputBrowse.Click += new System.EventHandler(this.OutputBrowse_Click);
            // 
            // Sigil
            // 
            this.Sigil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Sigil.BackColor = System.Drawing.Color.Transparent;
            this.Sigil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Sigil.Image = ((System.Drawing.Image)(resources.GetObject("Sigil.Image")));
            this.Sigil.Location = new System.Drawing.Point(50, 240);
            this.Sigil.Name = "Sigil";
            this.Sigil.Size = new System.Drawing.Size(49, 49);
            this.Sigil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sigil.TabIndex = 17;
            this.Sigil.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Sigil";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SigilBrowse
            // 
            this.SigilBrowse.Location = new System.Drawing.Point(93, 67);
            this.SigilBrowse.Name = "SigilBrowse";
            this.SigilBrowse.Size = new System.Drawing.Size(244, 20);
            this.SigilBrowse.TabIndex = 22;
            this.SigilBrowse.TextChanged += new System.EventHandler(this.SigilBrowse_TextChanged);
            // 
            // SiglButton
            // 
            this.SiglButton.Location = new System.Drawing.Point(343, 67);
            this.SiglButton.Name = "SiglButton";
            this.SiglButton.Size = new System.Drawing.Size(28, 23);
            this.SiglButton.TabIndex = 21;
            this.SiglButton.Text = "...";
            this.SiglButton.UseVisualStyleBackColor = true;
            this.SiglButton.Click += new System.EventHandler(this.SiglButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(429, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 31);
            this.label5.TabIndex = 23;
            this.label5.Text = "Transparent Color";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TransparentColorButton
            // 
            this.TransparentColorButton.BackColor = System.Drawing.SystemColors.Window;
            this.TransparentColorButton.Location = new System.Drawing.Point(510, 163);
            this.TransparentColorButton.Name = "TransparentColorButton";
            this.TransparentColorButton.Size = new System.Drawing.Size(168, 23);
            this.TransparentColorButton.TabIndex = 24;
            this.TransparentColorButton.Text = "Change";
            this.TransparentColorButton.UseVisualStyleBackColor = false;
            this.TransparentColorButton.Click += new System.EventHandler(this.TransparentColorButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(684, 162);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "Transparent";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RemoveBackgroundButton
            // 
            this.RemoveBackgroundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveBackgroundButton.Location = new System.Drawing.Point(429, 193);
            this.RemoveBackgroundButton.Name = "RemoveBackgroundButton";
            this.RemoveBackgroundButton.Size = new System.Drawing.Size(359, 23);
            this.RemoveBackgroundButton.TabIndex = 26;
            this.RemoveBackgroundButton.Text = "Remove Background";
            this.RemoveBackgroundButton.UseVisualStyleBackColor = true;
            this.RemoveBackgroundButton.Click += new System.EventHandler(this.RemoveBackgroundButton_Click);
            // 
            // convertFolderButton
            // 
            this.convertFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.convertFolderButton.Location = new System.Drawing.Point(429, 96);
            this.convertFolderButton.Name = "convertFolderButton";
            this.convertFolderButton.Size = new System.Drawing.Size(75, 43);
            this.convertFolderButton.TabIndex = 27;
            this.convertFolderButton.Text = "Convert Folder";
            this.convertFolderButton.UseVisualStyleBackColor = true;
            this.convertFolderButton.Click += new System.EventHandler(this.convertFolderButton_Click);
            // 
            // keepColorCheckbox
            // 
            this.keepColorCheckbox.Location = new System.Drawing.Point(429, 67);
            this.keepColorCheckbox.Name = "keepColorCheckbox";
            this.keepColorCheckbox.Size = new System.Drawing.Size(104, 24);
            this.keepColorCheckbox.TabIndex = 28;
            this.keepColorCheckbox.Text = "Keep Color";
            this.keepColorCheckbox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.keepColorCheckbox);
            this.Controls.Add(this.convertFolderButton);
            this.Controls.Add(this.RemoveBackgroundButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.TransparentColorButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SigilBrowse);
            this.Controls.Add(this.SiglButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SigilText);
            this.Controls.Add(this.Sigil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OutputDirectory);
            this.Controls.Add(this.OutputBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortraitText);
            this.Controls.Add(this.BackgroundPath);
            this.Controls.Add(this.ConvertFileButton);
            this.Controls.Add(this.BrowsePortrait);
            this.Controls.Add(this.BrowseBackground);
            this.Controls.Add(this.Portrait);
            this.Controls.Add(this.card);
            this.Name = "Form1";
            this.Text = "Inscryption Texture converter";
            ((System.ComponentModel.ISupportInitialize)(this.Portrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sigil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox keepColorCheckbox;

        private System.Windows.Forms.Button convertFolderButton;

        private System.Windows.Forms.Button RemoveBackgroundButton;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.Button TransparentColorButton;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SigilBrowse;
        private System.Windows.Forms.Button SiglButton;

        private System.Windows.Forms.Label SigilText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;

        public System.Windows.Forms.PictureBox Sigil;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OutputDirectory;
        private System.Windows.Forms.Button OutputBrowse;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox PortraitText;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button ConvertFileButton;
        public System.Windows.Forms.PictureBox Portrait;
        private System.Windows.Forms.Button BrowseBackground;
        private System.Windows.Forms.Button BrowsePortrait;
        private System.Windows.Forms.PictureBox card;
        private System.Windows.Forms.TextBox BackgroundPath;

        #endregion
    }
}
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace InscryptionTextureConverter
{
    public partial class Form1 : Form
    {
        private float portraitWidth = 114;
        private float portraitHeight = 94;
        private float sigilWidth = 49;
        private float sigilHeight = 49;
        
        private string lastConvertedPortrait = null;
        private string lastConvertedSigil = null;
        private string selectedCardBackgroundPath;
        private string seletedCardPortraitPath;
        private string seletedCardSigilPath;
        private string seletedOutputPath;
        private Color selectedTransparentColor = Color.FromArgb(255, 0, 0, 0);
        
        public Form1()
        {
            InitializeComponent();
            Portrait.Size = Size.Empty;
            Sigil.Size = Size.Empty;
            selectedCardBackgroundPath = Path.Combine(Directory.GetCurrentDirectory(), "Backgrounds/card_empty.png");
            BackgroundPath.Text = selectedCardBackgroundPath; 
            
            seletedCardPortraitPath = Path.Combine(Directory.GetCurrentDirectory(), "Output/surfingseagul_converted.png");
            PortraitText.Text = seletedCardPortraitPath;
            
            seletedCardSigilPath = Path.Combine(Directory.GetCurrentDirectory(), "Output/sigil_converted.png");
            SigilBrowse.Text = seletedCardSigilPath;
            
            seletedOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            OutputDirectory.Text = seletedOutputPath; 

            TransparentColorButton.BackColor = selectedTransparentColor;
            checkBox1.Checked = selectedTransparentColor == Color.Transparent;
            
            RefreshCard();
        }

        private int ConvertAllImagesInFolder(string path)
        {
            int totalConverted = 0;
            foreach (string filePath in Directory.EnumerateFiles(path))
            {
                if (!filePath.ToLower().EndsWith(".png") && !filePath.ToLower().EndsWith(".jpg"))
                {
                    continue;
                }

                string newPath = Convert(filePath);
                if(!string.IsNullOrEmpty(newPath))
                {
                    totalConverted++;
                }
            }
            return totalConverted;
        }

        public string Convert(string path)
        {
            Console.WriteLine("\tConverting: " + path);
            Color emptyPixel = Color.FromArgb(255, 0, 0, 0);

            int ignored = 0;
            int empty = 0;
            int converted = 0;

            Bitmap img = LoadBitMap(path);
            img.MakeTransparent();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color originalColor = img.GetPixel(i, j);
                    if (originalColor.A == 0)
                    {
                        ignored++;
                        continue;
                    }

                    Color color = RemoveColor(originalColor);
                    if (color.A == 0)
                    {
                        img.SetPixel(i, j, emptyPixel);
                        empty++;
                        continue;
                    }
                    converted++;
                    
                    
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    int alpha = 255 -  (r + g + b) / 3;
                    if (!keepColorCheckbox.Checked)
                    {
                        r = 0;
                        g = 0;
                        b = 0;
                    }
                    Color newColor = Color.FromArgb(alpha, r, g, b);
                    img.SetPixel(i, j, newColor);
                }
            }

            string fileName = Path.GetFileName(path);
            string newDirectory = seletedOutputPath; 
            string newPath = Path.Combine(newDirectory, fileName);
            Console.WriteLine("\tOutput: {0} {1} {2}, {3}", newPath, ignored, empty, converted);
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            try
            {
                img.Save(newPath, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show("Could not saved converted file '" + fileName + "'. Is it open somewhere?\nTry restarting this program", "oops");
                return null;
            }

            if (img.Width < portraitWidth && img.Height < portraitHeight)
            {
                lastConvertedSigil = newPath;
                Console.WriteLine("Detected Sigil: {0}w {1}h", img.Width, img.Height);
            }
            else
            {
                lastConvertedPortrait = newPath;
                Console.WriteLine("Detected Portrait: {0}w {1}h", img.Width, img.Height);
            }

            return newPath;
        }
        
        public string RemoveBackground(string path)
        {
            Console.WriteLine("\tRemoving Background: " + path);

            int ignored = 0;
            int empty = 0;
            int converted = 0;

            Bitmap img = LoadBitMap(path);
            img.MakeTransparent();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color originalColor = img.GetPixel(i, j);
                    if (originalColor.A == 0)
                    {
                        ignored++;
                        continue;
                    }

                    Color color = RemoveColor(originalColor);
                    img.SetPixel(i, j, color);
                }
            }

            string fileName = Path.GetFileName(path);
            string newDirectory = seletedOutputPath; 
            string newPath = Path.Combine(newDirectory, fileName);
            Console.WriteLine("\tOutput: {0} {1} {2}, {3}", newPath, ignored, empty, converted);
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            try
            {
                img.Save(newPath, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show("Could not saved file with no background '" + fileName + "'. Is it open somewhere?\nTry restarting this program", "oops");
            }

            if (img.Width < portraitWidth && img.Height < portraitHeight)
            {
                lastConvertedSigil = newPath;
                Console.WriteLine("Detected Sigil: {0}w {1}h", img.Width, img.Height);
            }
            else
            {
                lastConvertedPortrait = newPath;
                Console.WriteLine("Detected Portrait: {0}w {1}h", img.Width, img.Height);
            }

            return newPath;
        }

        private Color RemoveColor(Color color)
        {
            int r = Math.Max(0, color.R - selectedTransparentColor.R); 
            int g = Math.Max(0, color.G - selectedTransparentColor.G); 
            int b = Math.Max(0, color.B - selectedTransparentColor.B);
            int a = Math.Max(r, Math.Max(g, b));

            Color argb = Color.FromArgb(a, r, g, b);
            return argb;
        }

        private void RefreshCard()
        {
            if (string.IsNullOrEmpty(selectedCardBackgroundPath) || !File.Exists(selectedCardBackgroundPath))
                return;
            
            Console.WriteLine("background: " + selectedCardBackgroundPath);
            Console.WriteLine("portrait: " + seletedCardPortraitPath);
            Console.WriteLine("sigil: " + seletedCardSigilPath);

            Bitmap background = LoadBitMap(selectedCardBackgroundPath);
            Bitmap portrait = LoadInscryptionImage(seletedCardPortraitPath);
            Bitmap sigil = LoadInscryptionImage(seletedCardSigilPath);
            Bitmap combined = CombineAndResizeTwoImages(background, portrait, sigil,card.Margin.Left, card.Margin.Top);
            card.Image = combined;
            card.BackColor = Color.Transparent;
        }

        private Bitmap LoadInscryptionImage(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            Bitmap image = LoadBitMap(path);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color oc = image.GetPixel(i, j);
                    
                    // Set color to black
                    // Use the same alpha
                    Color nc = Color.FromArgb(oc.A, 0, 0, 0);
                    image.SetPixel(i, j, nc);
                }
            }

            return image;
        }
        
        public Bitmap CombineAndResizeTwoImages(Image background, Image portrait, Image sigil, float xOffset, float yOffset)
        {
            //a holder for the result
            Bitmap result = new Bitmap(background.Width, background.Height);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                
                //draw the images into the target bitmap
                graphics.DrawImage(background, 0, 0, result.Width, result.Height);

                if (portrait != null)
                {
                    graphics.DrawImage(portrait, xOffset + 2, yOffset + 31, portraitWidth, portraitHeight);
                }
                
                if (sigil != null)
                {
                    graphics.DrawImage(sigil, xOffset + 35, yOffset + 130, sigilWidth, sigilHeight);
                }
            }

            //return the resulting bitmap
            return result;
        }

        private void BrowsePortrait_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = GetPath(seletedCardPortraitPath);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    seletedCardPortraitPath = openFileDialog.FileName;
                    BackgroundPath.Text = seletedCardPortraitPath;
                }
            }

            RefreshCard();
        }

        private void BrowseBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = GetPath(selectedCardBackgroundPath);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    selectedCardBackgroundPath = openFileDialog.FileName;
                    BackgroundPath.Text = selectedCardBackgroundPath;
                }
            }
            RefreshCard();
        }

        private void ConvertFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = GetPath(seletedCardPortraitPath);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string newPath = Convert(openFileDialog.FileName);
                    if (!string.IsNullOrEmpty(newPath))
                    {
                        seletedCardSigilPath = lastConvertedSigil ?? lastConvertedSigil;
                        seletedCardPortraitPath = lastConvertedPortrait ?? lastConvertedPortrait;
                        RefreshCard();
                        MessageBox.Show($@"Successfully {openFileDialog.FileName}!", "Convert file!");
                    }
                }
            }
        }

        private void OutputBrowse_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = GetPath(seletedOutputPath);
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    seletedOutputPath = folderBrowserDialog.SelectedPath;
                    OutputDirectory.Text = selectedCardBackgroundPath;
                }
            }
        }

        private void SiglButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = GetPath(seletedCardSigilPath);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    seletedCardSigilPath = openFileDialog.FileName;
                    RefreshCard();
                }
            }
        }

        private void BackgroundPath_TextChanged(object sender, EventArgs e)
        {
            RefreshCard();
        }

        private void PortraitText_TextChanged(object sender, EventArgs e)
        {
            RefreshCard();
        }

        private void SigilBrowse_TextChanged(object sender, EventArgs e)
        {
            RefreshCard();
        }

        private string GetPath(string s)
        {
            if (string.IsNullOrEmpty(s) || !Directory.Exists(s))
            {
                return Directory.GetCurrentDirectory();
            }

            return Path.GetFullPath(s);
        }

        private void TransparentColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialogue = new ColorDialog();
            if (colorDialogue.ShowDialog() == DialogResult.OK)
            {
                selectedTransparentColor = colorDialogue.Color;
                TransparentColorButton.BackColor = selectedTransparentColor;
                checkBox1.Checked = selectedTransparentColor == Color.Transparent;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            selectedTransparentColor = Color.Transparent;
            TransparentColorButton.BackColor = selectedTransparentColor;
        }

        public Bitmap LoadBitMap(string path)
        {
            // This prevents locking the file
            Bitmap img = null;
            using (Bitmap bmpTemp = new Bitmap(path))
            {
                img = new Bitmap(bmpTemp);
            }

            return img;
        }

        private void RemoveBackgroundButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = GetPath(seletedCardPortraitPath);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string newPath = RemoveBackground(openFileDialog.FileName);
                    if (!string.IsNullOrEmpty(newPath))
                    {
                        seletedCardSigilPath = lastConvertedSigil ?? lastConvertedSigil;
                        seletedCardPortraitPath = lastConvertedPortrait ?? lastConvertedPortrait;
                        RefreshCard();
                        
                        MessageBox.Show($@"Successfully converted {openFileDialog.FileName} files!    Exported to {newPath}", "Remove background!");
                    }
                }
            }
        }

        private void convertFolderButton_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = GetPath(seletedCardPortraitPath);
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    int totalConverted = ConvertAllImagesInFolder(folderBrowserDialog.SelectedPath);
                    if (totalConverted > 0)
                    {
                        seletedCardSigilPath = lastConvertedSigil ?? lastConvertedSigil;
                        seletedCardPortraitPath = lastConvertedPortrait ?? lastConvertedPortrait;
                        RefreshCard();
                        MessageBox.Show($@"Successfully converted {totalConverted} files!    Exported to {OutputDirectory}", "Convert Folder!");
                        Console.WriteLine("Converted {0} files", totalConverted);
                    }
                }
            }
        }
    }
}
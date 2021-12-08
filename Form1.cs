using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace InscryptionTextureConverter
{
    public partial class Form1 : Form
    {
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

            SetTransparentColor(selectedTransparentColor);
            
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

                if(Convert(filePath))
                {
                    totalConverted++;
                }
            }
            return totalConverted;
        }

        private void RefreshCard()
        {
            if (string.IsNullOrEmpty(selectedCardBackgroundPath) || !File.Exists(selectedCardBackgroundPath))
                return;
            
            Bitmap background = Utils.LoadBitMap(selectedCardBackgroundPath);
            Bitmap portrait = Converting.LoadInscryptionImage(seletedCardPortraitPath);
            Bitmap sigil = Converting.LoadInscryptionImage(seletedCardSigilPath);
            Bitmap combined = Converting.CombineAndResizeTwoImages(background, portrait, sigil,card.Margin.Left, card.Margin.Top);
            card.Image = combined;
            card.BackColor = Color.Transparent;
        }
        
        private void BrowsePortrait_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Utils.GetPath(seletedCardPortraitPath);
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
                openFileDialog.InitialDirectory = Utils.GetPath(selectedCardBackgroundPath);
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
                openFileDialog.InitialDirectory = Utils.GetPath(seletedCardPortraitPath);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Convert(openFileDialog.FileName))
                    {
                        MessageBox.Show($@"Successfully {openFileDialog.FileName}!", "Convert file!");
                    }
                }
            }
        }

        private bool Convert(string path)
        {
            Console.WriteLine("Converting: " + path);
            Bitmap loadBitMap = Utils.LoadBitMap(path);
            Bitmap img = Converting.Convert(loadBitMap, keepColorCheckbox.Checked);
            
            string fileName = Path.GetFileName(path);
            string newDirectory = seletedOutputPath; 
            string newPath = Path.Combine(newDirectory, fileName);
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            Utils.SaveToFile(img, newPath);

            if (Utils.IsSigil(img))
            {
                lastConvertedSigil = newPath;
                seletedCardSigilPath = lastConvertedSigil;
            }
            else
            {
                lastConvertedPortrait = newPath;
                seletedCardPortraitPath = lastConvertedPortrait;
            }
            RefreshCard();

            return true;
        }

        private void OutputBrowse_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = Utils.GetPath(seletedOutputPath);
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
                openFileDialog.InitialDirectory = Utils.GetPath(seletedCardSigilPath);
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

        private void TransparentColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialogue = new ColorDialog();
            if (colorDialogue.ShowDialog() == DialogResult.OK)
            {
                SetTransparentColor(colorDialogue.Color);
            }
        }

        public void SetTransparentColor(Color color)
        {
            selectedTransparentColor = color;
            TransparentColorButton.BackColor = selectedTransparentColor;
            checkBox1.Checked = selectedTransparentColor == Color.Transparent;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetTransparentColor(Color.Transparent);
        }

        private void RemoveBackgroundButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Utils.GetPath(seletedCardPortraitPath);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    Bitmap originalImage = Utils.LoadBitMap(openFileDialog.FileName);
                    Bitmap img = Converting.RemoveColor(originalImage, selectedTransparentColor);
                    
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    string newDirectory = seletedOutputPath; 
                    string newPath = Path.Combine(newDirectory, fileName);
                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }
                    
                    Utils.SaveToFile(img, newPath);
            
                    if (Utils.IsSigil(img))
                    {
                        lastConvertedSigil = newPath;
                        seletedCardSigilPath = lastConvertedSigil ?? lastConvertedSigil;
                    }
                    else
                    {
                        lastConvertedPortrait = newPath;
                        seletedCardPortraitPath = lastConvertedPortrait ?? lastConvertedPortrait;
                    }
                    
                    RefreshCard();
                    MessageBox.Show($@"Successfully converted {openFileDialog.FileName} files!    Exported to {newPath}", "Remove background!");
                }
            }
        }

        private void convertFolderButton_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = Utils.GetPath(seletedCardPortraitPath);
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    int totalConverted = ConvertAllImagesInFolder(folderBrowserDialog.SelectedPath);
                    if (totalConverted > 0)
                    {
                        MessageBox.Show($@"Successfully converted {totalConverted} files!    Exported to {OutputDirectory}", "Convert Folder!");
                    }
                }
            }
        }
    }
}
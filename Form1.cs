using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using InscryptionTextureConverter.Helpers;

namespace InscryptionTextureConverter
{
    public partial class Form1 : Form
    {
        public static string VERSION = "1.0.0";
        
        private string lastConvertedPortrait = null;
        private string lastConvertedSigil = null;
        
        private CustomText selectedCardBackgroundPath;
        private CustomText seletedCardPortraitPath;
        private CustomText seletedCardSigilPath;
        private CustomText seletedOutputPath;
        
        private string seletedFileToConvertPath;
        private string seletedFolderToConvertPath;
        
        private Color selectedTransparentColor = Color.FromArgb(255, 0, 0, 0);
        private bool initialized = false;
        
        public Form1()
        {
            InitializeComponent();
            this.Text += " - v" + VERSION; // Window Header
            PlayerPrefs.Load();
            
            Portrait.Size = Size.Empty;
            Sigil.Size = Size.Empty;
                
            selectedCardBackgroundPath = new CustomText(BackgroundPath, "BackgroundPath", Path.Combine(Directory.GetCurrentDirectory(), "Art/Backgrounds/card_empty.png"));
            seletedCardPortraitPath = new CustomText(PortraitText, "PortraitPath", Path.Combine(Directory.GetCurrentDirectory(), "Art/Output/billy_bones.png"));
            seletedCardSigilPath = new CustomText(SigilBrowse, "SigilPath", Path.Combine(Directory.GetCurrentDirectory(), "Art/Output/Blink2.png"));
            seletedOutputPath = new CustomText(OutputDirectory, "OutputPath", Path.Combine(Directory.GetCurrentDirectory(), "Output"));
 
            seletedFileToConvertPath = PlayerPrefs.GetString("SelectedFileToConvertPath", Path.Combine(Directory.GetCurrentDirectory()));
            seletedFolderToConvertPath = PlayerPrefs.GetString("SelectedFolderToConvertPath", Path.Combine(Directory.GetCurrentDirectory()));

            initialized = true;
            
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
            if (!initialized || string.IsNullOrEmpty(selectedCardBackgroundPath.Text) || !File.Exists(selectedCardBackgroundPath.Text))
                return;
            
            Bitmap background = Utils.LoadBitMap(selectedCardBackgroundPath.Text);
            Bitmap portrait = Converting.LoadInscryptionImage(seletedCardPortraitPath.Text);
            Bitmap sigil = Converting.LoadInscryptionImage(seletedCardSigilPath.Text);
            Bitmap combined = Converting.CombineAndResizeTwoImages(background, portrait, sigil,card.Margin.Left, card.Margin.Top);
            card.Image = combined;
            card.BackColor = Color.Transparent;
        }
        
        private void BrowsePortrait_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Utils.GetPath(seletedCardPortraitPath.Text);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;

                Console.WriteLine("[BrowsePortrait_Click] Starting in " + openFileDialog.InitialDirectory);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    seletedCardPortraitPath.Text = openFileDialog.FileName;
                }
            }

            RefreshCard();
        }

        private void BrowseBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Utils.GetPath(selectedCardBackgroundPath.Text);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    selectedCardBackgroundPath.Text = openFileDialog.FileName;
                }
            }
            RefreshCard();
        }

        private void ConvertFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Utils.GetPath(seletedFileToConvertPath);
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    seletedFileToConvertPath = Path.GetDirectoryName(openFileDialog.FileName);
                    PlayerPrefs.SetString("SelectedFileToConvertPath", seletedFileToConvertPath);
                    
                    ConvertTextureForm otherForm = new ConvertTextureForm(openFileDialog.FileName, ExportBitmap);
                    otherForm.Show();
                    
                    /*if (Convert(openFileDialog.FileName))
                    {
                        MessageBox.Show($@"Successfully converted {openFileDialog.FileName}! Saved to {seletedOutputPath}", "Convert file!");
                    }*/
                }
            }
        }

        private void ExportBitmap(Bitmap bitmap, string originalPath)
        {
            string fileName = Path.GetFileName(originalPath);
            string newDirectory = seletedOutputPath.Text; 
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            string newPath = Path.Combine(newDirectory, fileName);
            if (File.Exists(newPath) && !AllowOverwrite.Checked)
            {
                MessageBox.Show($@"File at {originalPath} already exists! Cannot overwrite file!", "Convert file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Utils.SaveToFile(bitmap, newPath);
            
            lastConvertedPortrait = newPath;
            seletedCardPortraitPath.Text = lastConvertedPortrait;
            RefreshCard();
            
            MessageBox.Show($@"Successfully converted {originalPath}! Saved to {newPath}", "Convert file");
        }

        private bool Convert(string path)
        {
            Console.WriteLine("Converting: " + path);
            Bitmap loadBitMap = Utils.LoadBitMap(path);
            Bitmap img = Converting.Convert(loadBitMap, Converting.ConvertType.None, keepColorCheckbox.Checked);
            
            string fileName = Path.GetFileName(path);
            string newDirectory = seletedOutputPath.Text; 
            string newPath = Path.Combine(newDirectory, fileName);
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            Utils.SaveToFile(img, newPath);

            if (Utils.IsSigil(img))
            {
                lastConvertedSigil = newPath;
                seletedCardSigilPath.Text = lastConvertedSigil;
            }
            else
            {
                lastConvertedPortrait = newPath;
                seletedCardPortraitPath.Text = lastConvertedPortrait;
            }
            RefreshCard();

            return true;
        }

        private void OutputBrowse_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = seletedOutputPath.Directory;
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    seletedOutputPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void SiglButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = seletedCardSigilPath.Directory;
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    seletedCardSigilPath.Text = openFileDialog.FileName;
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
                openFileDialog.InitialDirectory = seletedCardPortraitPath.Directory;
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    Bitmap originalImage = Utils.LoadBitMap(openFileDialog.FileName);
                    Bitmap img = Converting.RemoveColor(originalImage, selectedTransparentColor);
                    
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    string newDirectory = seletedOutputPath.Text; 
                    string newPath = Path.Combine(newDirectory, fileName);
                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }
                    
                    Utils.SaveToFile(img, newPath);
            
                    if (Utils.IsSigil(img))
                    {
                        lastConvertedSigil = newPath;
                        seletedCardSigilPath.Text = lastConvertedSigil ?? lastConvertedSigil;
                    }
                    else
                    {
                        lastConvertedPortrait = newPath;
                        seletedCardPortraitPath.Text = lastConvertedPortrait ?? lastConvertedPortrait;
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
                folderBrowserDialog.SelectedPath = seletedFolderToConvertPath;
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    seletedFolderToConvertPath = folderBrowserDialog.SelectedPath;
                    PlayerPrefs.SetString("SelectedFolderToConvertPath", seletedFolderToConvertPath);
                    
                    int totalConverted = ConvertAllImagesInFolder(folderBrowserDialog.SelectedPath);
                    if (totalConverted > 0)
                    {
                        MessageBox.Show($@"Successfully converted {totalConverted} files!    Exported to {OutputDirectory}", "Convert Folder!");
                    }
                }
            }
        }

        private void OutputOpen_Click(object sender, EventArgs e)
        {
            Utils.OpenFolder(seletedOutputPath.Directory);
        }

        private void AllowOverwrite_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
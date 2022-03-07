using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using InscryptionTextureConverter.Helpers;

namespace InscryptionTextureConverter
{
    public partial class ConvertTextureForm : Form
    {
        private ConvertSelectUI original;
        private ConvertSelectUI simple;
        private ConvertSelectUI min;
        private ConvertSelectUI max;
        private ConvertSelectUI average;
        private ConvertSelectUI median;
        private List<ConvertSelectUI> allUIList;

        private string filePath;
        private Bitmap raw;
        private Action<Bitmap, string> onSelectedCallback;

        public ConvertTextureForm(string filePath, Action<Bitmap, string> OnSelectedCallback)
        {
            InitializeComponent();
            this.onSelectedCallback = OnSelectedCallback;
            
            original = new ConvertSelectUI(Converting.ConvertType.None, 
                originalBackground, 
                originalPortrait, 
                originalSelect, 
                originalInvertButton, 
                trackBar1,
                TrackPanelColor,
                OnUISelected);

            Point offset = new Point(originalBackground.Size.Width, 0);
            simple = original.Clone(Converting.ConvertType.Simple, offset, this);
            min = original.Clone(Converting.ConvertType.Min, offset.Scale(2), this);
            max = original.Clone(Converting.ConvertType.Max, offset.Scale(3), this);
            average = original.Clone(Converting.ConvertType.Average, offset.Scale(4), this);
            median = original.Clone(Converting.ConvertType.Median, offset.Scale(5), this);

            allUIList = new List<ConvertSelectUI>()
            {
                original,simple,min,max,average,median
            };
            
            this.filePath = filePath;
            this.raw = Utils.LoadBitMap(filePath);
            templateImage.Image = raw;

            for (int i = 0; i < allUIList.Count; i++)
            {
                allUIList[i].Show(Utils.CloneBitmap(this.raw));
            }

            TextBox textBox = new TextBox();
            Controls.Add(textBox);
        }

        private void OnUISelected(ConvertSelectUI ui)
        {
            onSelectedCallback.Invoke(ui.DisplayedPortrait, filePath);
            Close();
        }

        private void templateImage_Click(object sender, EventArgs e)
        {
            
        }

        private void ConvertTextureForm_Load(object sender, EventArgs e)
        {
            
        }

        private void originalSelectButton_Click(object sender, EventArgs e)
        {
            original.OnPressed();
        }

        private void minSelectButton_Click(object sender, EventArgs e)
        {
            min.OnPressed();
        }

        private void maxSelectButton_Click(object sender, EventArgs e)
        {
            max.OnPressed();
        }

        private void averageSelectButton_Click(object sender, EventArgs e)
        {
            average.OnPressed();
        }

        private void medianSelectButton_Click(object sender, EventArgs e)
        {
            median.OnPressed();
        }

        private void originalPortrait_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
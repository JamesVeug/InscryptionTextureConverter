using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InscryptionTextureConverter
{
    public partial class ConvertTextureForm : Form
    {
        private ConvertSelectUI original;
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
            
            original = new ConvertSelectUI(originalBackground, originalPortrait, Converting.ConvertType.None, OnUISelected);
            min = new ConvertSelectUI(minBackground, minPortrait, Converting.ConvertType.Min, OnUISelected);
            max = new ConvertSelectUI(maxBackground, maxPortrait, Converting.ConvertType.Max, OnUISelected);
            average = new ConvertSelectUI(averageBackground, averagePortrait, Converting.ConvertType.Average, OnUISelected);
            median = new ConvertSelectUI(medianBackground, medianPortrait, Converting.ConvertType.Median, OnUISelected);

            allUIList = new List<ConvertSelectUI>()
            {
                original,min,max,average,median
            };
            
            this.filePath = filePath;
            this.raw = Utils.LoadBitMap(filePath);
            templateImage.Image = raw;

            for (int i = 0; i < allUIList.Count; i++)
            {
                allUIList[i].Show(Utils.CloneBitmap(this.raw));
            }
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
    }
}
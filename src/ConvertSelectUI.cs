using System;
using System.Drawing;
using System.Windows.Forms;

namespace InscryptionTextureConverter
{
    public class ConvertSelectUI
    {
        public Bitmap DisplayedPortrait => displayedBitmap;
        
        private PictureBox Portrait;
        private PictureBox Background;
        private Action<ConvertSelectUI> callback;
        private Converting.ConvertType convertType;

        private Bitmap convertedBitmap;
        private Bitmap displayedBitmap;
        
        public ConvertSelectUI(PictureBox Background, PictureBox Portrait, Converting.ConvertType convertType, Action<ConvertSelectUI> callback)
        {
            this.Background = Background;
            
            Point location = new Point(Portrait.Location.X -  Background.Location.X, Portrait.Location.Y -  Background.Location.Y);
            this.Portrait = Portrait;
            this.Portrait.Parent = Background; // Makes it transparent to the background
            this.Portrait.BackColor = Color.Transparent;
            this.Portrait.Location = location; // Local position to the Background
            
            this.callback = callback;
            this.convertType = convertType;
        }

        public void Show(Bitmap bitmap)
        {
            convertedBitmap = Converting.Convert(bitmap, convertType, false);
            
            displayedBitmap = Converting.ConvertToInscryptionImage(convertedBitmap);
            Portrait.Image = displayedBitmap;
        }

        public void OnPressed()
        {
            this.callback(this);
        }
    }
}
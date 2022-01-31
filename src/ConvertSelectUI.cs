using System;
using System.Drawing;
using System.Windows.Forms;

namespace InscryptionTextureConverter
{
    public class ConvertSelectUI
    {
        private PictureBox Portrait;
        private PictureBox Background;
        private Action<ConvertSelectUI> callback;
        private Converting.ConvertType convertType;

        private Bitmap convertedBitmap;
        
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
            Portrait.Image = Converting.ConvertToInscryptionImage(convertedBitmap);
            
        }
        
        

        public void OnPressed()
        {
            this.callback(this);
        }
    }
}
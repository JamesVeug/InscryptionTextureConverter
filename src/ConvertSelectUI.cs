using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InscryptionTextureConverter
{
    public class ConvertSelectUI
    {
        public Bitmap DisplayedPortrait => displayedBitmap;
        
        private PictureBox Portrait;
        private PictureBox Background;
        private Button SelectButton;
        private Button InvertButton;
        private TrackBar TrackBarClone;
        private Panel TrackBarImagePanel;
        private Action<ConvertSelectUI> callback;
        private Converting.ConvertType convertType;

        private List<TrackBar> TrackBars = new List<TrackBar>();
        private List<Panel> TrackBarsPanels = new List<Panel>();

        private ConvertedImage convertedBitmap;
        private Bitmap displayedBitmap;

        public ConvertSelectUI(Converting.ConvertType convertType,
            PictureBox Background, 
            PictureBox Portrait, 
            Button SelectButton, 
            Button InvertButton, 
            TrackBar TrackBarTemplate,
            Panel TrackBarImagePanel,
            Action<ConvertSelectUI> callback)
        {
            this.Background = Background;
            this.SelectButton = SelectButton;
            this.InvertButton = InvertButton;
            this.TrackBarClone = Utils.Clone(TrackBarTemplate, Point.Empty);
            this.TrackBarImagePanel = Utils.Clone(TrackBarImagePanel, Point.Empty);
            
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
            displayedBitmap = Converting.ConvertToInscryptionImage(convertedBitmap.ToBitmap());
            Portrait.Image = displayedBitmap;

            Form form = Background.FindForm();
            List<Color> Colors = convertedBitmap.Colors;
            for (int i = 0; i < Colors.Count; i++)
            {
                int height = TrackBarClone.Bounds.Height * i;
                Point barOffset = new Point(0, height);
                TrackBar clonedTrackbar = Utils.Clone(TrackBarClone, barOffset);
                clonedTrackbar.Minimum = 0;
                clonedTrackbar.Maximum = Colors.Count - 1;
                clonedTrackbar.Value = 0;
                clonedTrackbar.Refresh();

                int colorIndex = i;
                clonedTrackbar.ValueChanged += (a, b) => { TrackBarChanged(clonedTrackbar, colorIndex); };
                form.Controls.Add(clonedTrackbar);
                TrackBars.Add(clonedTrackbar);
                
                
                Panel clonedColor = Utils.Clone(TrackBarImagePanel, barOffset);
                Color color = Colors[i];
                clonedColor.BackColor = Color.FromArgb(color.A, color.R, color.G, color.B);
                form.Controls.Add(clonedColor);
                TrackBarsPanels.Add(clonedColor);
            }
        }

        private void TrackBarChanged(TrackBar trackBar, int colorIndex)
        {
            convertedBitmap.ColorsMappings[colorIndex].Color = convertedBitmap.Colors[trackBar.Value];
            displayedBitmap = Converting.ConvertToInscryptionImage(convertedBitmap.ToBitmap());
            Portrait.Image = displayedBitmap;
            
            List<Color> Colors = convertedBitmap.Colors;
            for (int i = 0; i < Colors.Count; i++)
            {
                Panel clonedColor = TrackBarsPanels[i];
                Color color = Colors[i];
                clonedColor.BackColor = Color.FromArgb(color.A, color.R, color.G, color.B);
            }
        }

        public void OnPressed()
        {
            this.callback(this);
        }

        public ConvertSelectUI Clone(Converting.ConvertType type, Point offset, Form form)
        {
            var background = Utils.Clone(this.Background, Point.Empty);
            var portrait = Utils.Clone(this.Portrait, Point.Empty);
            var selectButton = Utils.Clone(this.SelectButton, Point.Empty);
            var TrackBarClone = Utils.Clone(this.TrackBarClone, offset);
            var PanelClone = Utils.Clone(TrackBarImagePanel, offset);
            
            background.Name += "_" + type;
            background.Left = Background.Left + offset.X;
            background.Top = Background.Top + offset.Y;
            form.Controls.Add(background);

            Point portraitLocation = new Point(Portrait.Left + offset.X, background.Top + Portrait.Top + offset.Y);
            portrait.Parent = background;
            portrait.Name += "_" + type;
            portrait.Location = portraitLocation;
            form.Controls.Add(portrait);
            
            Point selectButtonLocation = new Point(SelectButton.Left + offset.X, SelectButton.Top + offset.Y);
            selectButton.Name += "_" + type;
            selectButton.Location = selectButtonLocation;
            form.Controls.Add(selectButton);
            
            ConvertSelectUI clone = new ConvertSelectUI(type, 
                background,
                portrait,
                selectButton,
                null,
                TrackBarClone,
                PanelClone,
                this.callback
                );
            
            
            return clone;
        }
    }
}
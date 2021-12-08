using System;
using System.Drawing;
using System.IO;

namespace InscryptionTextureConverter
{
    public class Converting
    {
        public static Bitmap LoadInscryptionImage(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            Bitmap image = Utils.LoadBitMap(path);
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
        
        public static Bitmap CombineAndResizeTwoImages(Image background, Image portrait, Image sigil, float xOffset, float yOffset)
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
                    graphics.DrawImage(portrait, xOffset + 2, yOffset + 31, Constants.PortraitWidth, Constants.PortraitHeight);
                }
                
                if (sigil != null)
                {
                    graphics.DrawImage(sigil, xOffset + 35, yOffset + 130, Constants.SigilWidth, Constants.SigilHeight);
                }
            }

            //return the resulting bitmap
            return result;
        }

        public static Color RemoveColor(Color color, Color color2)
        {
            int r = Math.Max(0, color.R - color2.R); 
            int g = Math.Max(0, color.G - color2.G); 
            int b = Math.Max(0, color.B - color2.B);
            int a = Math.Max(r, Math.Max(g, b));

            Color argb = Color.FromArgb(a, r, g, b);
            return argb;
        }
        
        public static Bitmap RemoveColor(Bitmap img, Color colorToRemove)
        {
            // images that are not already transparent (jpg) need this to allow transparent pixels
            img.MakeTransparent();
            
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color originalColor = img.GetPixel(i, j);
                    if (originalColor.A == 0)
                    {
                        continue;
                    }

                    Color color = RemoveColor(originalColor, colorToRemove);
                    img.SetPixel(i, j, color);
                }
            }

            return img;
        }
        
        public static Bitmap Convert(Bitmap img, bool keepColorCheckbox)
        {
            img.MakeTransparent();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color originalColor = img.GetPixel(i, j);
                    if (originalColor.A == 0)
                    {
                        continue;
                    }

                    int r = originalColor.R;
                    int g = originalColor.G;
                    int b = originalColor.B;

                    int alpha = 255 -  (r + g + b) / 3;
                    if (!keepColorCheckbox)
                    {
                        r = 0;
                        g = 0;
                        b = 0;
                    }
                    Color newColor = Color.FromArgb(alpha, r, g, b);
                    img.SetPixel(i, j, newColor);
                }
            }

            return img;
        }
    }
}
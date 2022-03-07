using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace InscryptionTextureConverter
{
    public class ImageColorMap
    {
        public Color Color;
        public List<Point> Positions = new List<Point>();
    }
    
    public class ConvertedImage
    {
        public List<ImageColorMap> ColorsMappings = new List<ImageColorMap>();
        public List<Color> Colors = new List<Color>();
        private readonly int ImageWidth;
        private readonly int ImageHeight;

        public ConvertedImage(int width, int height)
        {
            this.ImageWidth = width;
            this.ImageHeight = height;
        }

        public void AddPixel(int x, int y, Color newColor)
        {
            Point point = new Point(x,y);
            for (int i = 0; i < ColorsMappings.Count; i++)
            {
                int a = ColorsMappings[i].Color.ToArgb();
                int b = newColor.ToArgb();
                if (a == b)
                {
                    ColorsMappings[i].Positions.Add(point);
                    return;
                }
            }

            ImageColorMap map = new ImageColorMap();
            map.Color = newColor;
            map.Positions.Add(point);
            ColorsMappings.Add(map);

            Colors.Add(newColor);
        }

        public Bitmap ToBitmap()
        {
            Bitmap bitmap = new Bitmap(ImageWidth, ImageHeight);
            bitmap.MakeTransparent();

            for (int i = 0; i < ColorsMappings.Count; i++)
            {
                ImageColorMap map = ColorsMappings[i];
                for (int j = 0; j < map.Positions.Count; j++)
                {
                    Point point = map.Positions[j];
                    bitmap.SetPixel(point.X, point.Y, map.Color);
                }
            }

            return bitmap;
        }
    }
    
    public class Converting
    {
        public static Bitmap LoadInscryptionImage(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            Bitmap image = Utils.LoadBitMap(path);
            Bitmap blackAndWhite = ConvertToInscryptionImage(image);
            return blackAndWhite;
        }
        
        public static Bitmap ConvertToInscryptionImage(Bitmap image)
        {
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
        
        public enum ConvertType
        {
            None,
            Max,
            Min,
            Average,
            Median
        }
        
        public static ConvertedImage Convert(Bitmap img, ConvertType convertType, bool keepColorCheckbox)
        {
            img.MakeTransparent();

            Dictionary<int, int> record = new Dictionary<int, int>();
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

                    // Record how many times used
                    int v = 0;
                    record.TryGetValue(alpha, out v);
                    record[alpha] = v + 1;
                }
            }

            ConvertedImage convertedImage = new ConvertedImage(img.Width, img.Height);
            if (convertType != ConvertType.None)
            {
                // Use values: 5%, 20%, 50%, 70%, 85%, 100%

                // Print spread
                List<int> keys = new List<int>(record.Keys);
                keys.Sort();

                List<float> percents = new List<float>();
                percents.Add(0.05f);
                percents.Add(0.2f);
                percents.Add(0.5f);
                percents.Add(0.7f);
                percents.Add(0.85f);
                percents.Add(1f);

                List<int> colors = new List<int>();
                int previousIndex = 0;
                for (int i = 0; i < percents.Count; i++)
                {
                    float percent = percents[i];
                    int maxIndex = (int)((keys.Count - 1) * percent);

                    switch (convertType)
                    {
                        case ConvertType.Max:
                            int highestValue = keys[maxIndex];
                            colors.Add(highestValue);
                            break;
                        case ConvertType.Min:
                            int lowestValue = keys[previousIndex];
                            colors.Add(lowestValue);
                            break;
                        case ConvertType.Average:
                            int sum = 0;
                            for (int j = previousIndex; j <= maxIndex; j++)
                            {
                                sum += keys[j];
                            }

                            sum /= (maxIndex - previousIndex);
                            colors.Add(sum);
                            break;
                        case ConvertType.Median:
                            int medianIndex = previousIndex + (maxIndex - previousIndex + 1) / 2;
                            colors.Add(medianIndex);
                            break;
                    }


                    previousIndex = maxIndex;
                }

                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color originalColor = img.GetPixel(i, j);
                        if (originalColor.A == 0)
                        {
                            continue;
                        }

                        bool replaced = false;
                        int a = originalColor.A;
                        for (int k = 0; k < colors.Count; k++)
                        {
                            if (a < colors[k] || (k + 1 >= colors.Count))
                            {
                                a = (int)(colors[k]);
                                replaced = true;
                                break;
                            }
                        }

                        if (!replaced)
                        {
                            continue;
                        }

                        int r = originalColor.R;
                        int g = originalColor.G;
                        int b = originalColor.B;

                        Color newColor = Color.FromArgb(a, r, g, b);
                        convertedImage.AddPixel(i, j, newColor);
                    }
                }
            }
            else
            {
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color originalColor = img.GetPixel(i, j);
                        convertedImage.AddPixel(i, j, originalColor);
                    }
                }
            }

            return convertedImage;
        }
    }
}
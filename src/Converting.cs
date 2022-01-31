using System;
using System.Collections.Generic;
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
        
        public static Bitmap Convert(Bitmap img, ConvertType convertType, bool keepColorCheckbox)
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

            if (convertType != ConvertType.None)
            {
                // Use values: 5%, 20%, 50%, 70%, 85%, 100%

                // Print spread
                List<int> keys = new List<int>(record.Keys);
                keys.Sort();

                Console.WriteLine("Total colours: " + keys.Count);
                for (int i = 0; i < keys.Count; i++)
                {
                    Console.WriteLine($"\tColour: {keys[i]} = {record[keys[i]]}");
                }

                List<float> percents = new List<float>();
                percents.Add(0.05f);
                percents.Add(0.2f);
                percents.Add(0.5f);
                percents.Add(0.7f);
                percents.Add(0.85f);
                percents.Add(1f);
                Console.WriteLine("Total Percents: " + percents.Count);

                List<int> alphaBuckets = new List<int>();
                int previousIndex = 0;
                for (int i = 0; i < percents.Count; i++)
                {
                    float percent = percents[i];
                    int maxIndex = (int)((keys.Count - 1) * percent);

                    switch (convertType)
                    {
                        case ConvertType.Max:
                            int highestValue = keys[maxIndex];
                            alphaBuckets.Add(highestValue);
                            Console.WriteLine("\t Highest Value: " + highestValue);
                            break;
                        case ConvertType.Min:
                            int lowestValue = keys[previousIndex];
                            alphaBuckets.Add(lowestValue);
                            Console.WriteLine("\t Lowest Value Value: " + lowestValue);
                            break;
                        case ConvertType.Average:
                            int sum = 0;
                            for (int j = previousIndex; j <= maxIndex; j++)
                            {
                                sum += keys[j];
                            }

                            sum /= (maxIndex - previousIndex);
                            alphaBuckets.Add(sum);
                            Console.WriteLine("\t Sum Value: " + sum);
                            break;
                        case ConvertType.Median:
                            int medianIndex = previousIndex + (maxIndex - previousIndex + 1) / 2;
                            alphaBuckets.Add(medianIndex);
                            Console.WriteLine("\t Median Value: " + medianIndex);
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
                        for (int k = 0; k < alphaBuckets.Count; k++)
                        {
                            if (a < alphaBuckets[k] || (k + 1 >= alphaBuckets.Count))
                            {
                                a = (int)(percents[k] * 255f);
                                replaced = true;
                                break;
                            }
                        }

                        if (!replaced)
                        {
                            Console.WriteLine("Ignored: " + a);
                            continue;
                        }

                        int r = originalColor.R;
                        int g = originalColor.G;
                        int b = originalColor.B;

                        Color newColor = Color.FromArgb(a, r, g, b);
                        img.SetPixel(i, j, newColor);
                    }
                }
            }

            return img;
        }
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace InscryptionTextureConverter
{
    public class Constants
    {
        public const string VERSION = "1.0.1"; 
        
        public const float PortraitWidth = 114;
        public const float PortraitHeight = 94;
        public const float SigilWidth = 49;
        public const float SigilHeight = 49;
        
        public static float[] AlphaRatios = new float[]
        {
            0.00f,
            0.05f,
            0.2f,
            0.5f,
            0.7f,
            0.85f,
            1f,
        };
        
        public static int[] Alpha255Ratios = new int[]
        {
            (int)(0.00f * 255f),
            (int)(0.05f * 255f),
            (int)(0.2f * 255f),
            (int)(0.5f * 255f),
            (int)(0.7f * 255f),
            (int)(0.85f * 255f),
            (int)(1f * 255f),
        };
        
        public static Color[] Colors = new Color[]
        {
            Color.FromArgb(Alpha255Ratios[0], 0, 0, 0),
            Color.FromArgb(Alpha255Ratios[1], 0, 0, 0),
            Color.FromArgb(Alpha255Ratios[2], 0, 0, 0),
            Color.FromArgb(Alpha255Ratios[3], 0, 0, 0),
            Color.FromArgb(Alpha255Ratios[4], 0, 0, 0),
            Color.FromArgb(Alpha255Ratios[5], 0, 0, 0),
            Color.FromArgb(Alpha255Ratios[6], 0, 0, 0),
        };
    }

    public class Utils
    {
        public static void SaveToFile(Bitmap img, string path)
        {
            try
            {
                Console.WriteLine("Saving file to " + path);
                img.Save(path, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                string fileName = Path.GetFileName(path);
                MessageBox.Show("Could not saved file with no background '" + fileName + "'. Is it open somewhere?\nTry restarting this program", "SaveToFile");
            }
        }

        public static bool IsSigil(Bitmap img)
        {
            return img.Width < Constants.PortraitWidth && img.Height < Constants.PortraitHeight;
        }
        
        public static Bitmap LoadBitMap(string path)
        {
            // This prevents locking the file
            Bitmap img = null;
            using (Bitmap bmpTemp = new Bitmap(path))
            {
                img = new Bitmap(bmpTemp);
            }

            return img;
        }

        public static Bitmap CloneBitmap(Bitmap img)
        {
            return new Bitmap(img);
        }

        /// <summary>
        /// 99% sure this doesn't even work
        /// Meant to stop the dialogfolderbrowser and filebrowser from starting in the wrong folder 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetPath(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return Directory.GetCurrentDirectory();
            }

            if (!File.Exists(s) && !Directory.Exists(s))
            {
                return Directory.GetCurrentDirectory();
            }
            
            FileAttributes attr = File.GetAttributes(s);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return s;
            
            return Path.GetDirectoryName(s);
        }
        
        public static void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath));
            }
        }

        public static T Clone<T>(T controlToClone, Point offset) where T : Control
        {
            T instance = Activator.CreateInstance<T>();
            instance.Size = new Size(controlToClone.Size.Width, controlToClone.Size.Height);
            instance.BackColor = controlToClone.BackColor;
            instance.ForeColor = controlToClone.ForeColor;
            instance.Text = controlToClone.Text;

            if (typeof(T) == typeof(PictureBox))
            {
                PictureBox template = (PictureBox)(object)controlToClone;
                PictureBox clone = (PictureBox)(object)instance;
                clone.Image = template.Image;
                clone.SizeMode = template.SizeMode;
            }
            else if (typeof(T) == typeof(Button))
            {
                Button template = (Button)(object)controlToClone;
                Button clone = (Button)(object)instance;
                clone.Image = template.Image;
                clone.Text = template.Text;
                clone.TextAlign = template.TextAlign;
            }
            else if (typeof(T) == typeof(Panel))
            {
                Panel template = (Panel)(object)controlToClone;
                Panel clone = (Panel)(object)instance;
                clone.AutoSize = template.AutoSize;
            }
            else if (typeof(T) == typeof(TrackBar))
            {
                TrackBar template = (TrackBar)(object)controlToClone;
                TrackBar clone = (TrackBar)(object)instance;
                clone.Minimum = template.Minimum;
                clone.Maximum = template.Maximum;
                clone.Value = template.Value;
            }
            else if (typeof(T) == typeof(Label))
            {
                Label template = (Label)(object)controlToClone;
                Label clone = (Label)(object)instance;
                clone.TextAlign = template.TextAlign;
                clone.Font = template.Font;
            }

            Point newLocation = new Point(controlToClone.Left + offset.X, controlToClone.Top + offset.Y);
            instance.Location = newLocation;
            
            
            /*foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if(propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                }
            }*/

            return instance;
        }

        public static Point Add(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
    }
}
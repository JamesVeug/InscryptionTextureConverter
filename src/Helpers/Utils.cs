﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace InscryptionTextureConverter
{
    public class Constants
    {
        public const float PortraitWidth = 114;
        public const float PortraitHeight = 94;
        public const float SigilWidth = 49;
        public const float SigilHeight = 49;
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
    }
}
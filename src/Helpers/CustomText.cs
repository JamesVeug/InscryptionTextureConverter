using System.IO;

namespace InscryptionTextureConverter.Helpers
{
    public class CustomText
    {
        public string Text
        {
            get
            {
                return textBox.Text;
            }

            set
            {
                textBox.Text = value;
                PlayerPrefs.SetString(saveKey, value);
            }
        }
        
        public string Directory
        {
            get
            {
                return Utils.GetPath(textBox.Text);
            }
        }
        
        private System.Windows.Forms.TextBox textBox;
        private string saveKey;
        
        public CustomText(System.Windows.Forms.TextBox textBox, string key, string defaultText)
        {
            this.textBox = textBox;
            this.saveKey = key;
            
            textBox.Text = PlayerPrefs.GetString(key, defaultText);
        }
    }
}
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonSelectFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFiles.Lines = openFileDialog.FileNames;
                }
            }
        }

        private async void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            string[] files = textBoxFiles.Lines;
        
            if (comboBoxEncryptionMethod.SelectedItem == null)
            {
                MessageBox.Show("Wybierz metodę szyfrowania.");
                return;
            }
        
            string method = comboBoxEncryptionMethod.SelectedItem.ToString();
        
            progressBar.Maximum = files.Length;
            progressBar.Value = 0;
        
            foreach (var file in files)
            {
                try
                {
                    await Task.Run(() => EncryptOrDecryptFile(file, method, true));
                    progressBar.Value++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas szyfrowania pliku {file}: {ex.Message}");
                }
            }
        
            MessageBox.Show("Szyfrowanie zakończone!");
        }

        private async void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            string[] files = textBoxFiles.Lines;
            string method = comboBoxEncryptionMethod.SelectedItem.ToString();

            progressBar.Maximum = files.Length;
            progressBar.Value = 0;

            foreach (var file in files)
            {
                await Task.Run(() => EncryptOrDecryptFile(file, method, false)); // Decrypting
                progressBar.Value++;
            }

            MessageBox.Show("Deszyfrowanie skończone!");
        }

        private void EncryptOrDecryptFile(string file, string method, bool encrypt)
        {
            string text = File.ReadAllText(file);
            string processedText = string.Empty;

            if (encrypt)
            {
                switch (method)
                {
                    case "AES":
                        processedText = EncryptWithAES(text);
                        break;
                    case "DES":
                        processedText = EncryptWithDES(text);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (method)
                {
                    case "AES":
                        processedText = DecryptWithAES(text);
                        break;
                    case "DES":
                        processedText = DecryptWithDES(text);
                        break;
                    default:
                        break;
                }
            }

            File.WriteAllText(file, processedText);
        }

        private string EncryptWithAES(string text)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = GenerateRandomBytes(32); // 256-bit key
                aes.IV = GenerateRandomBytes(16);  // 128-bit IV

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(text);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string DecryptWithAES(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = GenerateRandomBytes(32); // 256-bit key
                aes.IV = GenerateRandomBytes(16);  // 128-bit IV

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(encryptedBytes))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        private string EncryptWithDES(string text)
        {
            using (DES des = DES.Create())
            {
                des.Key = GenerateRandomBytes(8); // 64-bit key
                des.IV = GenerateRandomBytes(8);  // 64-bit IV

                ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(text);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string DecryptWithDES(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (DES des = DES.Create())
            {
                des.Key = GenerateRandomBytes(8); // 64-bit key
                des.IV = GenerateRandomBytes(8);  // 64-bit IV

                ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV);

                using (MemoryStream ms = new MemoryStream(encryptedBytes))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        private byte[] GenerateRandomBytes(int length)
        {
            byte[] bytes = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return bytes;
        }

        private async void UploadFiles(string[] files)
        {
            foreach (var file in files)
            {
                await Task.Run(() => UploadFile(file));
            }

            MessageBox.Show("Wysyłanie zakończone!");
        }

        private void UploadFile(string file)
            {
                try
                {
                    string serverUrl = "archaicznypomysl";

                    using (WebClient client = new WebClient())
                    {
                        client.UploadFile(serverUrl, "POST", file);
                        MessageBox.Show("Plik został pomyślnie przesłany na serwer.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas przesyłania pliku: {ex.Message}");
                }
            }

        [Serializable]
        public class EncryptionConfig
        {
            public string Method { get; set; }
            public string Key { get; set; }
            public string IV { get; set; }
        }

        public static class ConfigManager
        {
            public static void SaveConfig(EncryptionConfig config, string filePath)
            {
                string json = JsonSerializer.Serialize(config);
                File.WriteAllText(filePath, json);
            }

            public static EncryptionConfig LoadConfig(string filePath)
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<EncryptionConfig>(json);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Forms;

namespace samune
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            comboBox.Items.Add(filePath);

            comboBox.Items.Add(DocumentsPath);

            comboBox.Items.Add(PicturesPath);

            comboBox.Items.Add(VideosPath);

            comboBox.Items.Add(MusicPath);

            textbox_path.Text = (string)comboBox.Items[0];
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.Description = "フォルダを選択してください。";

            folderBrowserDialog.SelectedPath = @"C:";

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textbox_path.Text = folderBrowserDialog.SelectedPath;

            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = textbox_url.Text;

            string id = url.Replace("https://www.youtube.com/watch?v=", "");

            string thumbnail = "https://img.youtube.com/vi/" + id + "/maxresdefault.jpg";

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile(thumbnail, textbox_path.Text + @"\" + id + ".jpg");

            if (textbox_url.Text.Length <= 17)
            {
                textbox_check.Text = "だめー";
            }
        }

        string filePath = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

        string DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string PicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        string VideosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

        string MusicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);


        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textbox_path.Text = (string)comboBox.Items[comboBox.SelectedIndex];
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string url = textbox_url.Text;

            string id = url.Replace("https://www.youtube.com/watch?v=", "");

            string thumbnail = "https://img.youtube.com/vi/" + id + "/maxresdefault.jpg";

            Image image = new Image();

            BitmapImage imageSource = new BitmapImage(new Uri(thumbnail));

            image_url.Source = imageSource;

            //string text = textbox_url.Text;

            //int textLen = text.Length;

            if (textbox_url.Text.Length <= 17)
            {
                textbox_check.Text = "だめー";
            }
        }












        //https://img.youtube.com/vi/ID/maxresdefault.jpg
        //https://www.youtube.com/watch?v=hYATsDKvcgY
    }
}

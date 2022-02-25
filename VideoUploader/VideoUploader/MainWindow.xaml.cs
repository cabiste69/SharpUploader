using Microsoft.Win32;
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
using RestSharp;

namespace VideoUploader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string xx { get; set; } = "#FF272C34";
        public string[] path { get; set; }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void ImportVideos(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "video files (*.mp4;*.flv;*.mkv;*.avi;*.3gp;*.wmv;*.webm)|*.mp4;*.flv;*.mkv;*.avi;*.3gp;*.wmv;*.webm";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileNames;
                for (int i = 0; i < path.Length; i++)
                {
                    VideosToUpload.Content += path[i] + "\n";
                }
            }
        }

        private async void UploadVideos(object sender, RoutedEventArgs e)
        {
            //if (path == null)
            //{
            //    MessageBox.Show("no videos selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            var client = new RestClient("https://catbox.moe/user/api.php");
            var request = new RestRequest().AddQueryParameter("reqtype", "urlupload").AddQueryParameter("userhash", "b73c304cdef45857d566a1e26").AddQueryParameter("url", "http://i.imgur.com/aksF5Gk.jpg").AddHeader("Content-Type", "");
            var response = await client.PostAsync(request);
        }
    }
}

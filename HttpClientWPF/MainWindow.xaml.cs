using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace HttpClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int numCount { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            CountTB.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            numCount += 1;
            CountTB.Text = numCount.ToString();
            if (numCount >= 99)
                numCount = 0;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts/1/comments");

                HttpResponseMessage response = await client.GetAsync("posts");

                var content = await response.Content.ReadAsStringAsync();

                var posts = JsonConvert.DeserializeObject<List<Post>>(content);

                string json = JsonConvert.SerializeObject(posts);

                jsonTB.Text = json;
            }
        }
    }
}

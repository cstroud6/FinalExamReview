//Chrissy Stroud - Final Exam//
using Newtonsoft.Json;
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

namespace Problem1_JSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClearAll();
        }

        private void BtnGetStats_Click(object sender, RoutedEventArgs e)
        {
            List<Movie> MoviesNumberUsersVoted = new List<Movie>();
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var movies = JsonConvert.DeserializeObject<List<Movie>>(content);
            }

        }
        private void ClearAll()
        {
            txtIMDBscore.Inlines.Clear();
            txtDirector.Inlines.Clear();
            txtActor1.Inlines.Clear();
            lstMovieGenre.Items.Clear();
            lstVotedUsers.Items.Clear();


        }
        

    }
}

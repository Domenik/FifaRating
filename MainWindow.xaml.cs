using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using MahApps.Metro.Controls;
using Path = System.IO.Path;

namespace FifaRating
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ViewModel _viewModel = new ViewModel();

        public MainWindow()
        {
           // GetClubs();
           // LoadData();
            DataContext = _viewModel;
            InitializeComponent();
        }


        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            var thread = new Thread(SaveData);
            //thread.Start();
        }

        private void SaveData()
        {
            var serializer = new XmlSerializer(typeof(ObservableCollection<Club>));
            var autoSaveFileName = @"\\ZyZZok-PC\Users\Public\Utilites\AppData\FifaRatingV2\ClubSave.xml";
            Directory.CreateDirectory(Path.GetDirectoryName(autoSaveFileName));
            Stream stream;
            using (stream = File.Create(autoSaveFileName))
            {
                serializer.Serialize(stream, _viewModel.ListOfClubs);
            }

            serializer = new XmlSerializer(typeof(ObservableCollection<User>));
            autoSaveFileName = @"\\ZyZZok-PC\Users\Public\Utilites\AppData\FifaRatingV2\UserSave.xml";
            Directory.CreateDirectory(Path.GetDirectoryName(autoSaveFileName));
            using (stream = File.Create(autoSaveFileName))
            {
                serializer.Serialize(stream, _viewModel.ListOfUsers);
            }
        }

        private void LoadData()
        {
            var autoSaveFileName = @"\\ZyZZok-PC\Users\Public\Utilites\AppData\FifaRatingV2\ClubSave.xml";
            var serializer = new XmlSerializer(typeof(ObservableCollection<Club>));
            try
            {
                using (var rd = new StreamReader(autoSaveFileName))
                {
                    _viewModel.ListOfClubs =
                        new ObservableCollection<Club>(serializer.Deserialize(rd) as ObservableCollection<Club>);
                }

            }
            catch (Exception)
            {
            }

             autoSaveFileName = @"\\ZyZZok-PC\Users\Public\Utilites\AppData\FifaRatingV2\UserSave.xml";
            serializer = new XmlSerializer(typeof(ObservableCollection<User>));
            try
            {
                using (var rd = new StreamReader(autoSaveFileName))
                {
                    _viewModel.ListOfUsers =
                        new ObservableCollection<User>(serializer.Deserialize(rd) as ObservableCollection<User>);
                }

            }
            catch (Exception)
            {
            }

        }

        #region GetAllClubsAndPlayers
        
        private void GetClubs()
        {
            ObservableCollection<Club> listOfClubs = new ObservableCollection<Club>();
            for (int i = 1; i <= 24; i++)
            {
                string uri = "http://www.futhead.com/15/clubs/?page=" + i;
                string a = getResponse(uri);
                const string quote = "\"";
                const string stUri = "<a href=" + quote + "/15/clubs/";
                const string st = "<span class=" + quote + "name" + quote + ">";
                const string stPlayer = "data-player-full-name=" + quote;
                int kol = 0;
                while (kol != 3)
                {
                    kol++;
                    int j = a.IndexOf(stUri);
                    a = a.Remove(0, j + stUri.Length);
                }

                while (a.IndexOf(stUri) != -1)
                {
                    //Получаем ссылку на команду
                    int j = a.IndexOf(stUri);
                    a = a.Remove(0, j + stUri.Length);
                    string urlTeam = "http://www.futhead.com/15/clubs/" + a.Substring(0, a.IndexOf(quote));

                    //Получаем название команды
                    j = a.IndexOf(st);
                    a = a.Remove(0, j + st.Length);
                    string TeamName = a.Substring(0, a.IndexOf("</span>"));
                    Console.WriteLine(TeamName);
                    var club = new Club();
                    club.Name = TeamName;
                    //Получаем игроков команды
                    string c = getResponse(urlTeam);
                    while (c.IndexOf(stPlayer) != -1)
                    {
                        j = c.IndexOf(stPlayer);
                        c = c.Remove(0, j + stPlayer.Length);
                        string PlayerName = c.Substring(0, c.IndexOf(quote));
                        if (club.ListOfPlayers.Count(player => player.Name == PlayerName) == 0)
                        {
                            var newPlayer = new Player(PlayerName);
                            club.ListOfPlayers.Add(newPlayer);
                        }
                    }
                    listOfClubs.Add(club);
                }
            }
            _viewModel.ListOfClubs = listOfClubs;
        }

        static string getResponse(string uri)
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                byte[] buf = new byte[8192];
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                Stream resStream = response.GetResponseStream();
                int count = 0;
                do
                {
                    count = resStream.Read(buf, 0, buf.Length);
                    if (count != 0)
                    {
                        sb.Append(Encoding.Default.GetString(buf, 0, count));
                    }
                } while (count > 0);
                return sb.ToString();
            }
            catch (Exception)
            {
                return "";
                
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FifaRating
{
    class ViewModel : ViewModelBase
    {

        #region Property

        private ObservableCollection<Player> _listOfPlayers = new ObservableCollection<Player>();

        public ObservableCollection<Player> ListOfPlayers
        {
            get { return _listOfPlayers; }
            set
            {
                _listOfPlayers = value;
                OnPropertyChanged("ListOfPlayers");
            }
        }

        private ObservableCollection<Club> _listOfClubs = new ObservableCollection<Club>();

        public ObservableCollection<Club> ListOfClubs
        {
            get { return _listOfClubs; }
            set
            {
                _listOfClubs = value;
                OnPropertyChanged("ListOfClubs");
            }
        }

        private ObservableCollection<Match> _listOfMatches = new ObservableCollection<Match>();

        public ObservableCollection<Match> ListOfMatches
        {
            get { return _listOfMatches; }
            set
            {
                _listOfMatches = value;
                OnPropertyChanged("ListOfMatches");
            }
        }


        #endregion

        #region DelegateCommand

        private DelegateCommand _addPlayerCommand;

        public ICommand AddPlayerCommand
        {
            get
            {
                return _addPlayerCommand ?? (_addPlayerCommand = new DelegateCommand(AddPlayer));
            }
        }

        private DelegateCommand _addMatchCommand;

        public ICommand AddMatchCommand
        {
            get
            {
                return _addMatchCommand ?? (_addMatchCommand = new DelegateCommand(AddMatch));
            }
        }


        private DelegateCommand _addClubCommand;

        public ICommand AddClubCommand
        {
            get
            {
                return _addClubCommand ?? (_addClubCommand = new DelegateCommand(AddClub));
            }
        }


        #endregion

        #region Methods

        private void AddMatch()
        {
            var viewModel = new AddMatchViewModel()
            {
                ListOfClubs = this.ListOfClubs,
                ListOfPlayers = this.ListOfPlayers
            };
            var windowDialog = new AddMatchWindow()
            {
                DataContext = viewModel
            };
            windowDialog.ShowDialog();
            if (windowDialog.DialogResult == true)
            {
                var newMatch = new Match(viewModel.FirstPlayer, viewModel.FirstClub, viewModel.SecondPlayer, viewModel.SecondClub, viewModel.Score, viewModel.TypeMatch);
                ListOfMatches.Add(newMatch);
                RefreshPtsPlayer(newMatch);
                RefreshPtsClub(newMatch);
            }
        }

        private void AddPlayer()
        {
            var viewModel = new AddPlayerViewModel();
            var windowDialog = new AddPlayerWindow()
            {
                DataContext = viewModel
            };
            windowDialog.ShowDialog();
            if (windowDialog.DialogResult == true)
            {
                ListOfPlayers.Add(new Player(viewModel.Surname, viewModel.Name, viewModel.Nickname, ListOfMatches));
            }
        }

        private void AddClub()
        {
            var viewModel = new AddClubViewModel();
            var windowDialog = new AddClubWindow()
            {
                DataContext = viewModel
            };
            windowDialog.ShowDialog();
            if (windowDialog.DialogResult == true)
            {
                ListOfClubs.Add(new Club(viewModel.Name, ListOfMatches));
            }
        }

        private void RefreshPtsPlayer(Match match)
        {
            double dPtsFirstPlayer = match.K() * match.Score.G() * (match.Score.W(1) - match.We(1));
            double dPtsSecondPlayer = match.K() * match.Score.G() * (match.Score.W(2) - match.We(2));
            match.FirstPlayer.Points = dPtsFirstPlayer;
            match.SecondPlayer.Points = dPtsSecondPlayer;
        }

        private void RefreshPtsClub(Match match)
        {

        }

        #endregion
    }
}

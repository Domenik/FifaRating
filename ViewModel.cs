using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Input;
using Kontur.Scc.ImitatorBase;

namespace FifaRating
{
    class ViewModel : ViewModelBase
    {
        #region Constructor

        public ViewModel()
        {
            _listOfUsers = new ObservableCollection<User>();
            _listOfUsers.Add(new User("AllUsers"));
            _listOfTournaments = new ObservableCollection<Tournament>();
            _listOfClubs = new ObservableCollection<Club>();
            _listOfClubs.Add(new Club("AllCLubs"));
        }

        #endregion

        private ObservableCollection<User> _listOfUsers;
        private ObservableCollection<Club> _listOfClubs;
        private ObservableCollection<Tournament> _listOfTournaments;
        private ObservableCollection<Match> _listOfMatches;
        private User _user;
        private User _rivalUser;
        private Club _myClub;
        private Club _rivalClub;
        private Club _selectedClub;
        private int _freeId;

        #region Property

        public ObservableCollection<User> ListOfUsers
        {
            get { return _listOfUsers; }
            set
            {
                _listOfUsers = value;
                OnPropertyChanged("ListOfUsers");
            }
        }

        public ObservableCollection<Club> ListOfClubs
        {
            get { return _listOfClubs; }
            set
            {
                _listOfClubs = value;
                OnPropertyChanged("ListOfClubs");
            }
        }

        public ObservableCollection<Tournament> ListOfTournaments
        {
            get { return _listOfTournaments; }
            set
            {
                _listOfTournaments = value;
                OnPropertyChanged("ListOfTournaments");
            }
        }

        public ObservableCollection<Match> ListOfMatches
        {
            get { return _listOfMatches; }
            set
            {
                _listOfMatches = value;
                OnPropertyChanged("ListOfMatches");
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public User RivalUser
        {
            get { return _rivalUser ?? ListOfUsers.First(); }
            set
            {
                _rivalUser = value;
                OnPropertyChanged("RivalUser");
            }
        }

        public Club MyClub
        {
            get { return _myClub ?? ListOfClubs.First(); }
            set
            {
                _myClub = value;
                OnPropertyChanged("MyClub");
            }
        }

        public Club RivalClub
        {
            get { return _rivalClub ?? ListOfClubs.First(); }
            set
            {
                _rivalClub = value;
                OnPropertyChanged("RivalClub");
            }
        }

        public Club SelectedClub
        {
            get { return _selectedClub; }
            set
            {
                _selectedClub = value;
                OnPropertyChanged("SelectedClub");
            }
        }

        public int FreeId
        {
            get { return _freeId; }
            set
            {
                _freeId = value;
                OnPropertyChanged("FreeId");
            }
        }


        #endregion

        #region DelegateCommand


        private DelegateCommand _addNewUserCommand;

        public ICommand AddNewUserCommand
        {
            get
            {
                return _addNewUserCommand ?? (_addNewUserCommand = new DelegateCommand(AddNewUser));
            }
        }


        private DelegateCommand _addNewMatchCommand;

        public ICommand AddNewMatchCommand
        {
            get
            {
                return _addNewMatchCommand ?? (_addNewMatchCommand = new DelegateCommand(AddNewMatch));
            }
        }



        #endregion

        #region Methods

        private void Refresh()
        {
            //TODO: Выборка нужных матчей
            //
            //
            //
            //
            //
            //Обновление полей пользователя для которого смотрим стату
            User.RefreshAllData();
        }

        private void AddNewUser()
        {
            var newUser = new User();
            var addNewUserWindow = new AddNewUserWindow { DataContext = newUser };
            addNewUserWindow.ShowDialog();
            if (addNewUserWindow.DialogResult == true)
            {
                ListOfUsers.Add(newUser);
            }
        }

        private void AddNewMatch()
        {
            var viewModelAddNewMatch = new ViewModelAddNewMatch { ListOfUsers = ListOfUsers, ListOfClubs = ListOfClubs };
            var addNewMatchWindow = new AddNewMatchWindow(viewModelAddNewMatch);
            viewModelAddNewMatch.ListOfTypeMatches.Add(new TypeMatch());
            foreach (var tournament in ListOfTournaments)
            {
                viewModelAddNewMatch.ListOfTypeMatches.Add(new TypeMatch(tournament.Name, tournament.Factor));
                if (tournament.IsWorldCup)
                    viewModelAddNewMatch.ListOfTypeMatches.Add(new TypeMatch(tournament.Name + " - Финал", tournament.Factor));
            }
            addNewMatchWindow.ShowDialog();
            if (addNewMatchWindow.DialogResult == true)
            {
                var lFirst = new ObservableCollection<int>();
                foreach (var player in viewModelAddNewMatch.ListOfGoalsFirstUser)
                {
                    lFirst.Add(player.Id);
                } 
                var lSecond = new ObservableCollection<int>();
                foreach (var player in viewModelAddNewMatch.ListOfGoalsSecondUser)
                {
                    lFirst.Add(player.Id);
                }
                var newMatch = new Match
                {
                    Date = viewModelAddNewMatch.Date,
                    TypeMatch = viewModelAddNewMatch.TypeMatch,
                    FirstPlayerId = viewModelAddNewMatch.FirstUser.Id,
                    FirstClubId = viewModelAddNewMatch.FirstClub.Id,
                    FirstPlayerGoal = viewModelAddNewMatch.FirstUserGoals,
                    ListOfScoredFirstPlayerId = lFirst,
                    SecondPlayerId = viewModelAddNewMatch.SecondUser.Id,
                    SecondClubId = viewModelAddNewMatch.SecondClub.Id,
                    SecondPlayerGoal = viewModelAddNewMatch.SecondUserGoals,
                    ListOfScoredSecondPlayerId = lSecond
                };
                ListOfMatches.Add(newMatch);
            }
        }

        #endregion

        private DelegateCommand _refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new DelegateCommand(Refresh));
            }
        }
    }
}

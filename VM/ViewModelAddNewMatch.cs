using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Input;
using System.Xml.Serialization;
using Kontur.Scc.ImitatorBase;

namespace FifaRating
{
    public class ViewModelAddNewMatch : ViewModelBase
    {
        #region Construct

        public ViewModelAddNewMatch()
        {
            ListOfGoalsFirstUser = new ObservableCollection<Player>();
            ListOfGoalsSecondUser = new ObservableCollection<Player>();
            ListOfTypeMatches = new ObservableCollection<TypeMatch>();
            Date = DateTime.Now;
        }

        #endregion

        private User _firstUser;
        private User _secondUser;
        private Club _firstClub;
        private Club _secondClub;
        private int _firstUserGoals;
        private int _secondUserGoals;
        private ObservableCollection<Player> _listOfGoalsFirstUser;
        private ObservableCollection<Player> _listOfGoalsSecondtUser;
        private DateTime _date;
        private ObservableCollection<User> _listOfUsers;
        private ObservableCollection<Club> _listOfClubs;
        private ObservableCollection<TypeMatch> _listOfTypeMatches;
        private TypeMatch _typeMatch;

        #region Property

        public User FirstUser
        {
            get { return _firstUser; }
            set
            {
                _firstUser = value;
                OnPropertyChanged("FirstUser");
            }
        }

        public User SecondUser
        {
            get { return _secondUser; }
            set
            {
                _secondUser = value;
                OnPropertyChanged("SecondUser");
            }
        }

        public Club FirstClub
        {
            get { return _firstClub; }
            set
            {
                _firstClub = value;
                OnPropertyChanged("FirstClub");
            }
        }

        public Club SecondClub
        {
            get { return _secondClub; }
            set
            {
                _secondClub = value;
                OnPropertyChanged("SecondClub");
            }
        }

        public int FirstUserGoals
        {
            get { return _firstUserGoals; }
            set
            {
                _firstUserGoals = value;
                OnPropertyChanged("FirstUserGoals");
            }
        }

        public int SecondUserGoals
        {
            get { return _secondUserGoals; }
            set
            {
                _secondUserGoals = value;
                OnPropertyChanged("SecondUserGoals");
            }
        }

        public ObservableCollection<Player> ListOfGoalsFirstUser
        {
            get { return _listOfGoalsFirstUser; }
            set
            {
                _listOfGoalsFirstUser = value;
                OnPropertyChanged("ListOfGoalsFirstUser");
            }
        }

        public ObservableCollection<Player> ListOfGoalsSecondUser
        {
            get { return _listOfGoalsSecondtUser; }
            set
            {
                _listOfGoalsSecondtUser = value;
                OnPropertyChanged("ListOfGoalsSecondUser");
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }


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

        public ObservableCollection<TypeMatch> ListOfTypeMatches
        {
            get { return _listOfTypeMatches; }
            set
            {
                _listOfTypeMatches = value;
                OnPropertyChanged("ListOfTypeMatches");
            }
        }

        public TypeMatch TypeMatch {
            get { return _typeMatch; }
            set
            {
                _typeMatch = value;
                OnPropertyChanged("TypeMatch");
            }
        }

        #endregion

        #region DelegateCommand

        private DelegateCommand _firstPlayerGoalCommand;

        public ICommand FirstPlayerGoalCommand
        {
            get
            {
                return _firstPlayerGoalCommand ?? (_firstPlayerGoalCommand = new DelegateCommand(FirstPlayerGoal));
            }
        }

        private DelegateCommand _secondPlayerGoalCommand;

        public ICommand SecondPlayerGoalCommand
        {
            get
            {
                return _secondPlayerGoalCommand ?? (_secondPlayerGoalCommand = new DelegateCommand(SecondPlayerGoal));
            }
        }

        #endregion

        #region Methods

        private void FirstPlayerGoal()
        {
            FirstUserGoals++;
            ListOfGoalsFirstUser.Add(new Player(FirstClub));
        }
        private void SecondPlayerGoal()
        {
            SecondUserGoals++;
            ListOfGoalsSecondUser.Add(new Player(SecondClub));
        }

        #endregion
    }
}

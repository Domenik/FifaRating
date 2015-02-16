using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FifaRating
{
    class AddMatchViewModel : ViewModelBase
    {
        #region Property

        private Score _score;

        public Score Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged("Score");
            }
        }

        private Player _firstPlayer;

        public Player FirstPlayer
        {
            get { return _firstPlayer; }
            set
            {
                _firstPlayer = value; 
                OnPropertyChanged("FirstPlayer");
            }
        }

        private Player _secondPlayer;

        public Player SecondPlayer
        {
            get { return _secondPlayer; }
            set
            {
                _secondPlayer = value; 
                OnPropertyChanged("SecondPlayer");
            }
        }

        private Club _firstClub;

        public Club FirstClub
        {
            get { return _firstClub; }
            set
            {
                _firstClub = value;
                OnPropertyChanged("FirstClub");
            }
        }

        private Club _secondClub;

        public Club SecondClub
        {
            get { return _secondClub; }
            set
            {
                _secondClub = value; 
                OnPropertyChanged("SecondClub");
            }
        }

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

        private TypeMatch _typeMatch;

        public TypeMatch TypeMatch
        {
            get { return _typeMatch; }
            set
            {
                _typeMatch = value; 
                OnPropertyChanged("TypeMatch");
            }
        }

        private ObservableCollection<TypeMatch> _listOfTypeMatches;

        public ObservableCollection<TypeMatch> ListOfTypeMatches
        {
            get { return _listOfTypeMatches; }
            set
            {
                _listOfTypeMatches = value; 
                OnPropertyChanged("ListOfTypeMatches");
            }
        }
        

        #endregion

        #region Methods

        

        #endregion
    }
}

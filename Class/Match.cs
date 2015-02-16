using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FifaRating
{
    public class Match : ViewModelBase
    {
        #region Constructor

        public Match()
        {
            ListOfScoredFirstPlayerId = new ObservableCollection<int>();
            ListOfScoredSecondPlayerId = new ObservableCollection<int>();
            TypeMatch = new TypeMatch();
            Date = new DateTime();
            Date = DateTime.Now;
        }

        #endregion

        private TypeMatch _typeMatch;
        private DateTime _date;
        private ObservableCollection<int> _listOfScoredFirstPlayerId;
        private ObservableCollection<int> _listOfScoredSecondPlayerId;

        private int _firstPlayerId;
        private int _secondPlayerId;
        private int _firstClubId;
        private int _secondClubId;
        private int _firstPlayerGoal;
        private int _secondPlayerGoal;
        private int _extraPoint;

        #region Property

        public TypeMatch TypeMatch
        {
            get { return _typeMatch; }
            set
            {
                _typeMatch = value;
                OnPropertyChanged("TypeMatch");
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

        public ObservableCollection<int> ListOfScoredFirstPlayerId
        {
            get { return _listOfScoredFirstPlayerId; }
            set
            {
                _listOfScoredFirstPlayerId = value;
                OnPropertyChanged("ListOfScoredFirstPlayerId");
            }
        }

        public ObservableCollection<int> ListOfScoredSecondPlayerId
        {
            get { return _listOfScoredSecondPlayerId; }
            set
            {
                _listOfScoredSecondPlayerId = value;
                OnPropertyChanged("ListOfScoredSecondPlayerId");
            }
        }

        public int FirstPlayerId
        {
            get { return _firstPlayerId; }
            set
            {
                _firstPlayerId = value;
                OnPropertyChanged("FirstPlayerId");
            }
        }

        public int SecondPlayerId
        {
            get { return _secondPlayerId; }
            set
            {
                _secondPlayerId = value;
                OnPropertyChanged("SecondPlayerId");
            }
        }

        public int FirstClubId
        {
            get { return _firstClubId; }
            set
            {
                _firstClubId = value;
                OnPropertyChanged("FirstClubId");
            }
        }

        public int SecondClubId
        {
            get { return _secondClubId; }
            set
            {
                _secondClubId = value;
                OnPropertyChanged("SecondClubId");
            }
        }

        public int FirstPlayerGoal
        {
            get { return _firstPlayerGoal; }
            set
            {
                _firstPlayerGoal = value;
                OnPropertyChanged("FirstPlayerGoal");
            }
        }

        public int SecondPlayerGoal
        {
            get { return _secondPlayerGoal; }
            set
            {
                _secondPlayerGoal = value;
                OnPropertyChanged("SecondPlayerGoal");
            }

        }

        public int ExtraPoint
        {
            get { return _extraPoint; }
            set
            {
                _extraPoint = value;
                OnPropertyChanged("ExtraPoint");
            }

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return FirstPlayerGoal + " : " + SecondPlayerGoal;
        }

        #endregion

    }
}

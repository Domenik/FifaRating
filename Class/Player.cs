using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace FifaRating
{
    public class Player : ViewModelBase
    {

        #region Consructor

        public Player()
        {
          
        }

        public Player(Club club)
        {
            Club = club;
        }

        public Player(string name)
        {
            Name = name;
        }

        public Player(string name, int countGoals)
        {
            Name = name;
            CountOfGoals = countGoals;
        }

        #endregion

        private string _name;
        private int _countOfHatTrick;
        private int _countOfTake;
        private int _countOfGoals;
        private int _countOfPoker;
        private int _countOfMore;
        private int _id;
        private Club _club;

        #region Property

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; 
                OnPropertyChanged("Name");
            }
        }
        

        public int CountOfHatTrick
        {
            get { return _countOfHatTrick; }
            set
            {
                _countOfHatTrick = value;
                OnPropertyChanged("CountOfHatTrick");
            }
        }

        public int CountOfTake
        {
            get { return _countOfTake; }
            set
            {
                _countOfTake = value;
                OnPropertyChanged("CountOfTake");
            }
        }

        public int CountOfGoals
        {
            get { return _countOfGoals; }
            set
            {
                _countOfGoals = value;
                OnPropertyChanged("CountOfGoals");
            }
        }

        public int CountOfPoker
        {
            get { return _countOfPoker; }
            set
            {
                _countOfPoker = value;
                OnPropertyChanged("CountOfPoker");
            }
        }

        public int CountOfMore
        {
            get { return _countOfMore; }
            set
            {
                _countOfMore = value;
                OnPropertyChanged("CountOfMore");
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        [XmlIgnore]
        public Club Club {
            get { return _club; }
            set
            {
                _club = value;
                OnPropertyChanged("Club");
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}

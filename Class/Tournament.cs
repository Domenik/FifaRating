using System.Collections.Generic;
using System.Windows.Documents;

namespace FifaRating
{
    class Tournament : ViewModelBase
    {
        #region Constructor

        public Tournament()
        {
            Prize = new Prize();
            ListOfClubsUsers = new List<KeyValuePair<string, string>>();
        }

        #endregion

        private string _name;
        private List<KeyValuePair<string, string>> _listOfClubsUsers;
        private Prize _prize;
        private int _extraPoint;
        private int _factor;
        private bool _isWorldCup;

        #region Property

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name;");
            }
        }

        public List<KeyValuePair<string, string>> ListOfClubsUsers
        {
            get { return _listOfClubsUsers; }
            set
            {
                _listOfClubsUsers = value;
                OnPropertyChanged("ListOfClubsUsers");
            }
        }

        public Prize Prize
        {
            get { return _prize; }
            set
            {
                _prize = value;
                OnPropertyChanged("Prize");
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

        public int Factor
        {
            get { return _factor; }
            set
            {
                _factor = value;
                OnPropertyChanged("Factor");
            }
        }
        
        public bool IsWorldCup
        {
            get { return _isWorldCup; }
            set
            {
                _isWorldCup = value;
                OnPropertyChanged("IsWorldCup");
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

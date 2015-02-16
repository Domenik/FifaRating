using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MahApps.Metro;

namespace FifaRating
{
    public class Club : ViewModelBase
    {
        #region Constructor

        public Club()
        {
            ListOfPlayers = new List<Player>();
        }

        public Club(string name)
        {
            Name = name;
            ListOfPlayers = new List<Player>();
        }

        #endregion

        private string _name;
        private int _id;
        private List<Player> _listOfPlayers;

        #region Property

        public List<Player> ListOfPlayers
        {
            get { return _listOfPlayers; }
            set
            {
                _listOfPlayers = value;
                OnPropertyChanged("ListOfPlayers");
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

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
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

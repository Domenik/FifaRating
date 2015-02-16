using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FifaRating
{
    class AddPlayerViewModel : ViewModelBase
    {
        #region Property

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string _nickname;

        public string Nickname
        {
            get { return _nickname; }
            set
            {
                _nickname = value;
                OnPropertyChanged("Nickname");
            }
        }

        #endregion

    }
}

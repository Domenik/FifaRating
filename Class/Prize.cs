using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FifaRating
{
    class Prize : ViewModelBase
    {

        #region Constructor

        public Prize()
        {

        }

        #endregion

        private string _name;

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

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}

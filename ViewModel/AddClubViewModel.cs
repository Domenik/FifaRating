using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FifaRating
{
    class AddClubViewModel : ViewModelBase
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
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FifaRating
{
    public class TypeMatch : ViewModelBase
    {

        #region Constructor
        
        public TypeMatch()
        {
            Name = "Товарещиский матч";
            Factor = 20;
        }

        public TypeMatch(string name, int factor)
        {
            Name = name;
            Factor = factor;
        }

        #endregion

        private string _name;
        private int _factor;

        #region Property
        
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
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

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}

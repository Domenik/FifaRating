using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FifaRating
{
    class Score : ViewModelBase
    {
        #region Property

        private byte _firstPlayerGoals;

        public byte FirstPlayerGoals
        {
            get { return _firstPlayerGoals; }
            set
            {
                _firstPlayerGoals = value;
                OnPropertyChanged("FirstPlayerGoals");
            }
        }

        private byte _secondPlayerGoals;

        public byte SecondPlayerGoals
        {
            get { return _secondPlayerGoals; }
            set
            {
                _secondPlayerGoals = value;
                OnPropertyChanged("SecondPlayerGoals");
            }
        }

        public string ToString()
        {
            return FirstPlayerGoals + "-" + SecondPlayerGoals;
        }

        #endregion

        #region Constructors

        public Score()
        {

        }

        public Score(byte firstPlayerGoals, byte secondPlayerGoals)
        {
            FirstPlayerGoals = firstPlayerGoals;
            SecondPlayerGoals = secondPlayerGoals;
        }

        #endregion

        #region Methods

        public double G()
        {
            var diff = Math.Abs(SecondPlayerGoals - FirstPlayerGoals);
            if (diff == 1) return 1.0;
            if (diff == 2) return 1.5;
            return (11.0 + diff) / 8.0;
        }

        public double W(int player)
        {
            if (SecondPlayerGoals == FirstPlayerGoals)
                return 0.5;
            if (player == 1)
            {
                return FirstPlayerGoals > SecondPlayerGoals ? 1.0 : 0.0;
            }
            return SecondPlayerGoals > FirstPlayerGoals ? 1.0 : 0.0;
        }


        #endregion
    }
}

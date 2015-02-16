using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FifaRating
{
    public class User : ViewModelBase
    {
        #region Constructor

        public User()
        {
            Name = "";
        }

        public User(string name)
        {
            Name = name;
        }

        #endregion

        private int _id;
        private string _name;

        #region Property

        
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        /*
                [XmlIgnore]
                public int CountOfGames
                {
                    get { return ListOfMatches.Count(); }
                }
                [XmlIgnore]
                public int CountOfWin
                {
                    get { return ListOfMatches.Count(match => match.MyGoals > match.RivalGoals); }
                }
                [XmlIgnore]
                public int CountOfLost
                {
                    get { return ListOfMatches.Count(match => match.MyGoals < match.RivalGoals); }
                }
                [XmlIgnore]
                public double Point
                {
                    get { return 0; }
                }
                [XmlIgnore]
                public int CountOfDraw
                {
                    get { return ListOfMatches.Count(match => match.MyGoals == match.RivalGoals); }
                }
                [XmlIgnore]
                public int CountOfGoals
                {
                    get { return ListOfMatches.Sum(match => match.MyGoals); }
                }
                [XmlIgnore]
                public int CountOfMissingBalls
                {
                    get { return ListOfMatches.Sum(match => match.RivalGoals); }
                }
                [XmlIgnore]
                public int CountOfClearVictory
                {
                    get { return ListOfMatches.Count(match => match.RivalGoals == 0); }
                }
                [XmlIgnore]
                public int MaximumSeriesOfVictories
                {
                    get
                    ;
                    set
                        ;
                }
                [XmlIgnore]
                public int MaximumSeriesOfLosts
                {
                    get
                    ;
                    set
                        ;
                }
                [XmlIgnore]
                public int MaximumSeriesOfDraws
                {
                    get
                    ;
                    set
                        ;
                }
                */
        #endregion

        #region Methods

        public void RefreshAllData()
        {
            OnPropertyChanged("MaximumSeriesOfDraws");
            OnPropertyChanged("MaximumSeriesOfLosts");
            OnPropertyChanged("MaximumSeriesOfVictories");
            OnPropertyChanged("CountOfClearVictory");
            OnPropertyChanged("CountOfMissingBalls");
            OnPropertyChanged("CountOfGoals");
            OnPropertyChanged("CountOfDraw");
            OnPropertyChanged("Point");
            OnPropertyChanged("CountOfLost");
            OnPropertyChanged("CountOfWin");
            OnPropertyChanged("CountOfGames");
            OnPropertyChanged("ListOfMatches");
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}

using System;
using System.ComponentModel;
using System.Windows.Input;
using FifaRating.Annotations;


namespace FifaRating
{
    internal class ViewModelBase : INotifyPropertyChanged, ICommand
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)

        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion



        bool ICommand.CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        void ICommand.Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }

}

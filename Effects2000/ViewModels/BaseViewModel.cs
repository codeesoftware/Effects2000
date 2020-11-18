using System;
using System.ComponentModel;

namespace Effects2000.ViewModels
{
     abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public BaseViewModel()
        {
            Initlialize();
        }

        protected virtual void Initlialize()
        {
            
        }
    }
}

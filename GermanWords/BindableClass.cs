using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace GermanWords
{
    public class BindableClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}

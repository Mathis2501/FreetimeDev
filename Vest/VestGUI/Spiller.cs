using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VestGUI
{
    public class Spiller : INotifyPropertyChanged
    {
        public string Navn { get; set; }
        public int Point { get; set; }

        public Spiller(string navn)
        {
            Navn = navn;
            Point = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

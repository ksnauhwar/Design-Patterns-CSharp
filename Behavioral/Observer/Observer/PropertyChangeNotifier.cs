using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Observer
{
    public class PropertyChangeNotifier
    {
        public class Market : INotifyPropertyChanged
        {
            private int _volitality;

            public event PropertyChangedEventHandler PropertyChanged;

            public int Volitality
            {
                get => _volitality;

                set
                {
                    _volitality = value;
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Volitality")); //aisa bhi chalta hain
                    OnPropertyChanged();
                }
            }

            public int MarketIndex
            {
                get => 5;

                set
                {
                    OnPropertyChanged();
                }
            }

            //not compulsary to have this as virtual
            //what if I need the value of the property that has changed as well?
            public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class MarketVolitalityObserver
        {
            public MarketVolitalityObserver(Market market)
            {
                market.PropertyChanged += Market_VolitalityChanged;
            }

            private void Market_VolitalityChanged(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine($"{e.PropertyName} has changed");
            }
        }
    }
}

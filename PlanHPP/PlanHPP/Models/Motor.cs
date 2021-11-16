using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PlanHPP.Models
{
    public class Motor : INotifyPropertyChanged
    {
        public string _Name;
        public string _Switch;
        public int _ID;
        public int _Indicator;
        public double _X;
        public double _Y;

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Motor.Name));
            }
        }
        public string Switch
        {
            get
            {
                return _Switch;
            }

            set
            {
                _Switch = value;
                OnPropertyChanged(nameof(Motor.Switch));
            }
        }
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
                OnPropertyChanged(nameof(Motor.ID));
            }
        }
        public int Indicator
        {
            get
            {
                return _Indicator;
            }

            set
            {
                _Indicator = value;
                OnPropertyChanged(nameof(Motor.Indicator));
            }
        }
        public double X
        {
            get
            {
                return _X;
            }

            set
            {
                _X = value;
                OnPropertyChanged(nameof(Motor.X));
            }
        }
        public double Y
        {
            get
            {
                return _Y;
            }

            set
            {
                _Y = value;
                OnPropertyChanged(nameof(Motor.Y));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}


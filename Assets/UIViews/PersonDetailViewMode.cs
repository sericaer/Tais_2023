using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tais.Views
{
    public class PersonDetailViewMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string roleName { get; private set; }

        public int rolePrestige
        {
            get
            {
                return _rolePrestige;
            }
            set
            {
                if (_rolePrestige == value)
                {
                    return;
                }

                _rolePrestige = value;
                NotifyPropertyChanged();
            }
        }

        public int roleHeath { get; private set; }

        public int rolePress { get; private set; }


        private int _rolePrestige;

        public PersonDetailViewMode()
        {
            rolePrestige = 12;
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

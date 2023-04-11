using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tais.Views
{
    [AddINotifyPropertyChangedInterface]
    public class PersonDetailViewMode
    {
        public string roleName { get; private set; }

        public int rolePrestige { get; private set; }

        public int roleHeath { get; private set; }

        public int rolePress { get; private set; }

        public PersonDetailViewMode()
        {
            rolePrestige = 12;
        }
    }
}

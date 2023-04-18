using System.ComponentModel;

namespace Tais.Models
{
    public class PopInit
    {
        public string type { get; set; }
        public decimal count { get; set; }
    }

    public class Pop : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; }

        public decimal count { get; }

        public Pop(PopInit init)
        {
            this.name = init.type;
            this.count = init.count;
        }

    }
}

using System.ComponentModel;
using Tais.Models.Messages;

namespace Tais.Models
{
    public class PopInit
    {
        public string type { get; set; }
        public decimal count { get; set; }
    }

    public class Pop : Entity, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; }

        public decimal count { get; private set; }

        public Pop(PopInit init)
        {
            this.name = init.type;
            this.count = init.count;
        }

        [MessageProcesser]
        void OnMessage(MESSAG_DAY_INC msg)
        {
            count++;
        }
    }
}

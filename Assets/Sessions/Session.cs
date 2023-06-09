using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Tais.Sessions
{
    public class Session
    {
        public BindingList<Province> provinces;

        public Session()
        {
            provinces = new BindingList<Province>();

            provinces.Add(new Province("P01", 1000));
            provinces.Add(new Province("P02", 2000));
        }
    }

    public class Province : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }
        public int popCount { get; set; }

        public Province(string name, int popCount)
        {
            this.name = name;
            this.popCount = popCount;
        }
    }

    public class Person
    {
        public string name;
    }
}

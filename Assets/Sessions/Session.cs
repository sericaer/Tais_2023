using PropertyChanged;
using System.Collections.ObjectModel;

namespace Tais.Sessions
{
    public class Session
    {
        public ObservableCollection<Province> provinces;

        public Session()
        {
            provinces = new ObservableCollection<Province>();

            provinces.Add(new Province("P01", 1000));
            provinces.Add(new Province("P02", 2000));
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class Province
    {
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

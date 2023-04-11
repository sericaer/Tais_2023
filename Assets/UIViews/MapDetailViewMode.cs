using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Tais.Sessions;
using System.Linq;
using System.ComponentModel;

namespace Tais.Views
{
    public class MapDetailViewMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<INotifyPropertyChanged> provinceViewModes { get; }

        private BindingList<Province> provinces;

        public MapDetailViewMode(BindingList<Province> provinces)
        {
            provinceViewModes = new ObservableCollection<INotifyPropertyChanged>();

            this.provinces = provinces;
            provinces.ListChanged += Provinces_CollectionChanged;

            foreach (var province in provinces)
            {
                provinceViewModes.Add(new ProvinceViewMode(province));
            }
        }

        private void Provinces_CollectionChanged(object sender, ListChangedEventArgs e)
        {
            switch(e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    provinceViewModes.Add(new ProvinceViewMode(provinces[e.NewIndex]));
                    break;
                case ListChangedType.ItemDeleted:
                    var viewMode = provinceViewModes.SingleOrDefault(x => ((ProvinceViewMode)x).mode == provinces[e.OldIndex]);
                    provinceViewModes.Remove(viewMode);
                    break;
                default:
                    break;
            }
        }
    }

    public class ProvinceViewMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }
        public int popCount { get; set; }

        public Province mode => _mode;

        private Province _mode;

        public ProvinceViewMode(Province province)
        {
            this._mode = province;
        }
    }
}

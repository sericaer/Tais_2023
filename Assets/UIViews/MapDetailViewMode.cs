using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Tais.Sessions;
using System.Linq;
using System.ComponentModel;

namespace Tais.Views
{
    [AddINotifyPropertyChangedInterface]
    public class MapDetailViewMode
    {
        public ObservableCollection<INotifyPropertyChanged> provinceViewModes { get; }

        private ObservableCollection<Province> provinces;

        public MapDetailViewMode(ObservableCollection<Province> provinces)
        {
            provinceViewModes = new ObservableCollection<INotifyPropertyChanged>();

            this.provinces = provinces;
            provinces.CollectionChanged += Provinces_CollectionChanged;

            foreach (var province in provinces)
            {
                provinceViewModes.Add(new ProvinceViewMode(province as Province) as INotifyPropertyChanged);
            }
        }

        private void Provinces_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(var province in e.NewItems)
                    {
                        provinceViewModes.Add(new ProvinceViewMode(province as Province) as INotifyPropertyChanged);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var province in e.OldItems)
                    {
                        var viewMode = provinceViewModes.SingleOrDefault(x => ((ProvinceViewMode) x).mode == province);
                        provinceViewModes.Remove(viewMode);
                    }
                    break;
                default:
                    throw new Exception();
            }
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class ProvinceViewMode
    {
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

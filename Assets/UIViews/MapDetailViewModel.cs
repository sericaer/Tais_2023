using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Tais.Sessions;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

namespace Tais.Views
{
    public class MapDetailViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<INotifyPropertyChanged> provinceViewModes { get; }

        private BindingList<Province> provinces;

        public MapDetailViewModel(object model)
        {
            provinceViewModes = new ObservableCollection<INotifyPropertyChanged>();

            this.provinces = model as BindingList<Province>;
            provinces.ListChanged += Provinces_CollectionChanged;

            foreach (var province in provinces)
            {
                provinceViewModes.Add(new ProvinceDetailViewMode(province));
            }
        }

        private void Provinces_CollectionChanged(object sender, ListChangedEventArgs e)
        {
            switch(e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    provinceViewModes.Add(new ProvinceDetailViewMode(provinces[e.NewIndex]));
                    break;
                case ListChangedType.ItemDeleted:
                    var viewMode = provinceViewModes.OfType<ProvinceDetailViewMode>().SingleOrDefault(x => x.mode == provinces[e.OldIndex]);
                    provinceViewModes.Remove(viewMode);
                    viewMode.Dispose();
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            provinces.ListChanged -= Provinces_CollectionChanged;

            foreach(var viewModel in provinceViewModes.OfType<ProvinceDetailViewMode>())
            {
                viewModel.Dispose();
            }
        }
    }

    public class ProvinceDetailViewMode : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }
        public int popCount { get; set; }

        public readonly Province mode;


        public ProvinceDetailViewMode(Province province)
        {
            this.mode = province;
            mode.PropertyChanged += OnModelPropertyChanged;

            foreach(var propertyName in mode.GetType().GetProperties().Select(x=>x.Name))
            {
                OnModelPropertyChanged(mode, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Dispose()
        {
            mode.PropertyChanged -= OnModelPropertyChanged;
        }

        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(Province.name):
                    name = sender.GetPropertyValue<string>(e.PropertyName);
                    break;
                case nameof(Province.popCount):
                    popCount = sender.GetPropertyValue<int>(e.PropertyName);
                    break;
            }
        }
    }


    public static class ReflectionExtensions
    {
        public static Dictionary<Type, Dictionary<string, PropertyInfo>> dict = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        public static T GetPropertyValue<T>(this object source, string propertyName)
        {
            var type = source.GetType();
            if (!dict.ContainsKey(type))
            {
                dict.Add(type, new Dictionary<string, PropertyInfo>());
            }

            if(!dict[type].ContainsKey(propertyName))
            {
                var property = type.GetProperty(propertyName);
                if(!typeof(T).IsAssignableFrom(property.PropertyType))
                {
                    throw new Exception();
                }

                dict[type].Add(propertyName, property);
            }

            return (T)dict[type][propertyName].GetValue(source);
        }
    }
}

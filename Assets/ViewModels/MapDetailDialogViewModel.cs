using DynamicData;
using Loxodon.Framework.ViewModels;
using System.Collections.ObjectModel;
using Tais.Models;
using Tais.ViewModels.Interfaces;
using System.Linq;
using System.Reactive.Disposables;
using System;

namespace Tais.Scenes
{
    internal class MapDetailDialogViewModel : ViewModelBase, IMapDetailDialogViewModel
    {
        public ReadOnlyObservableCollection<IProvinceItemViewModel> provinceList { get; }

        private ObservableCollection<IProvinceItemViewModel> _provinceList;

        private CompositeDisposable disposables;

        public MapDetailDialogViewModel(SourceList<Province> provinces)
        {
            disposables = new CompositeDisposable();

            _provinceList = new ObservableCollection<IProvinceItemViewModel>();
            provinceList = new ReadOnlyObservableCollection<IProvinceItemViewModel>(_provinceList);


            disposables.Add(provinces.Connect().OnItemAdded(x =>
            {
                _provinceList.Add(new ProvinceItemViewModel(x));
            }).Subscribe());

            disposables.Add(provinces.Connect().OnItemAdded(x => 
            {
                var needRemove = _provinceList.SingleOrDefault(x => ((ProvinceItemViewModel)x).model == x);
                if(needRemove != null)
                {
                    _provinceList.Remove(needRemove);
                }

            }).Subscribe());
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposables.Dispose();
        }
    }
}
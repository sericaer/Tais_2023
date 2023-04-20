using DynamicData;
using Loxodon.Framework.ViewModels;
using System.Collections.ObjectModel;
using Tais.Models;
using Tais.ViewModels.Interfaces;
using System.Linq;
using System.Reactive.Disposables;
using System;
using Tais.Extensions;

namespace Tais.Scenes
{
    internal class MapDetailDialogViewModel : ViewModelBase, IMapDetailDialogViewModel
    {
        public ReadOnlyObservableCollection<IProvinceItemViewModel> provinceList => _provinceList;

        private ReadOnlyObservableCollection<IProvinceItemViewModel> _provinceList;

        private CompositeDisposable disposables = new CompositeDisposable();

        public MapDetailDialogViewModel(SourceList<Province> provinces)
        {
            disposables = new CompositeDisposable();

            provinces.Connect().Transform(p => new ProvinceItemViewModel(p) as IProvinceItemViewModel).Bind(out _provinceList)
                .DisposeMany()
                .Subscribe()
                .AddTo(disposables);
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposables.Dispose();
        }
    }
}
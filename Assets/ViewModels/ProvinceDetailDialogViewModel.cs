using DynamicData;
using Loxodon.Framework.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Tais.Extensions;
using Tais.Models;
using Tais.ViewModels.Interfaces;

namespace Tais.Scenes
{
    internal class ProvinceDetailDialogViewModel : AbstractViewModel<Province>, IProvinceDetailDialogViewModel
    {
        public string name { get; private set; }

        public string popNum { get; private set; }

        public ReadOnlyObservableCollection<IPopItemViewModel> popItems => _popItems;
        private ReadOnlyObservableCollection<IPopItemViewModel> _popItems;

        public ProvinceDetailDialogViewModel(Province province) : base(province)
        {
            model.pops.Connect().Transform(p => new PopItemViewModel(p) as IPopItemViewModel).Bind(out _popItems)
                .DisposeMany()
                .Subscribe()
                .AddTo(disposables);
        }
    }
}
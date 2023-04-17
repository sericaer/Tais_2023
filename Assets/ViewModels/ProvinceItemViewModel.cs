using Loxodon.Framework.ViewModels;
using ReactiveMarbles.PropertyChanged;
using Tais.Models;
using Tais.ViewModels.Interfaces;
using System;
using System.Reactive.Disposables;

namespace Tais.Scenes
{
    public class ProvinceItemViewModel : ViewModelBase, IProvinceItemViewModel
    {
        public Province model { get; }

        public string name { get; private set; }

        public int popCount { get; private set; }

        private CompositeDisposable disposables;

        public ProvinceItemViewModel(Province model)
        {
            disposables = new CompositeDisposable();

            disposables.Add(model.WhenChanged(x => x.name).Subscribe(n => name = n));
            disposables.Add(model.WhenChanged(x => x.popCount).Subscribe(n => popCount = n));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposables.Dispose();
        }
    }
}
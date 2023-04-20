using DynamicData.Binding;
using Loxodon.Framework.ViewModels;
using System;
using System.Globalization;
using System.Reactive.Disposables;
using Tais.Extensions;
using Tais.Models;
using Tais.ViewModels.Interfaces;

namespace Tais.Scenes
{
    internal class PopDetailDialogViewModel : ViewModelBase, IPopDetailDialogViewModel
    {

        public string type { get; private set; }
        public string num { get; private set; }
        public string living { get; private set; }
        public string numInc { get; private set; }

        private Pop model;

        private CompositeDisposable disposables = new CompositeDisposable();

        public PopDetailDialogViewModel(Pop model)
        {
            this.model = model;

            model.WhenValueChanged(x => x.count).Subscribe(n => num = ((int)n).ToString()).AddTo(disposables);
            model.WhenValueChanged(x => x.name).Subscribe(n => type = n).AddTo(disposables);
            model.WhenValueChanged(x => x.living.currValue).Subscribe(n => living = n.ToString()).AddTo(disposables);
            model.WhenValueChanged(x => x.numInc.currValue).Subscribe(n => numInc = n.ToString("+0.00%;-0.00%")).AddTo(disposables);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposables.Dispose();
        }
    }
}
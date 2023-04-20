using Loxodon.Framework.ViewModels;
using ReactiveMarbles.PropertyChanged;
using Tais.Models;
using Tais.ViewModels.Interfaces;
using System;
using System.Reactive.Disposables;
using Loxodon.Framework.Commands;

namespace Tais.Scenes
{
    public class ProvinceItemViewModel : AbstractViewModel<Province>, IProvinceItemViewModel
    {
        public string name { get; private set; }

        public int popCount { get; private set; }

        public ICommand OpenProvinceDetailDialog { get; private set; }

        public ProvinceItemViewModel(Province province) : base(province)
        {
            disposables.Add(model.WhenChanged(x => x.name).Subscribe(n => name = n));
            disposables.Add(model.WhenChanged(x => x.popCount).Subscribe(n => popCount = n));

            OpenProvinceDetailDialog = new SimpleCommand(() => 
            {
                Messenger.Publish(new MESSAGE_SHOW_DIALOG()
                {
                    dialogName = "provinceDetailDialog",
                    viewModel = new ProvinceDetailDialogViewModel(model)
                });
            });
        }
    }
}
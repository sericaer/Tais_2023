using DynamicData;
using DynamicData.Binding;
using Loxodon.Framework.Commands;
using System;
using System.Linq;
using System.Reactive.Linq;
using Tais.Extensions;
using Tais.Models;
using Tais.ViewModels.Interfaces;

namespace Tais.Scenes
{
    public class MainViewModel : AbstractViewModel<Session>, IMainViewModel
    {
        public string roleName { get; set; }

        public int totalPopCount { get; private set; }

        public SimpleCommand OpenMapDetailDialog { get; }

        public string year { get; private set; }

        public string month { get; private set; }

        public string day { get; private set; }

        public MainViewModel(Session model) : base(model)
        {
            model.provinces.Sum(x => x.popCount).Subscribe(sum => totalPopCount = sum).AddTo(disposables);
            model.date.WhenPropertyChanged(x => x.year).Subscribe(y => year = y.Value.ToString("00")).AddTo(disposables);
            model.date.WhenPropertyChanged(x => x.month).Subscribe(m => month = m.Value.ToString("00")).AddTo(disposables);
            model.date.WhenPropertyChanged(x => x.day).Subscribe(d => day = d.Value.ToString("00")).AddTo(disposables);

            OpenMapDetailDialog = new SimpleCommand(() =>
            {
                Messenger.Publish(new MESSAGE_SHOW_DIALOG() 
                { 
                    dialogName = "mapDetailDialog", 
                    viewModel = new MapDetailDialogViewModel(model.provinces) 
                });
            });
        }
    }
}

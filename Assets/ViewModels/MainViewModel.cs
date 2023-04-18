using DynamicData;
using DynamicData.Binding;
using Loxodon.Framework.Commands;
using Loxodon.Framework.ViewModels;
using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Tais.Extensions;
using Tais.Models;
using Tais.ViewModels.Interfaces;

namespace Tais.Scenes
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public string roleName { get; set; }

        public int totalPopCount { get; private set; }

        public SimpleCommand OpenMapDetailDialog { get; }

        public string year { get; private set; }

        public string month { get; private set; }

        public string day { get; private set; }

        public readonly Session model;

        private CompositeDisposable disposables;

        public MainViewModel(Session model) : base(Loxodon.Framework.Messaging.Messenger.Default)
        {
            this.model = model;
            this.disposables = new CompositeDisposable();

            disposables.Add(model.provinces.Sum(x => x.popCount).Subscribe(sum => totalPopCount = sum));

            disposables.Add(model.date.WhenPropertyChanged(x => x.year).Subscribe(y => year = y.Value.ToString("00")));
            disposables.Add(model.date.WhenPropertyChanged(x => x.month).Subscribe(m => month = m.Value.ToString("00")));
            disposables.Add(model.date.WhenPropertyChanged(x => x.day).Subscribe(d => day = d.Value.ToString("00")));

            OpenMapDetailDialog = new SimpleCommand(() =>
            {
                Messenger.Publish(new MESSAGE_SHOW_DIALOG() 
                { 
                    dialogName = "mapDetailDialog", 
                    viewModel = new MapDetailDialogViewModel(model.provinces) 
                });;
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposables.Dispose();
        }


        private void UpdateTotalPopCount()
        {
            totalPopCount = model.provinces.Items.Sum(x => x.popCount);
        }
    }
}

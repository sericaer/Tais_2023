using DynamicData;
using Loxodon.Framework.Commands;
using Loxodon.Framework.ViewModels;
using System;
using System.Linq;
using System.Reactive.Linq;
using Tais.Models;
using Tais.ViewModels.Interfaces;

namespace Tais.Scenes
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public string roleName { get; set; }

        public int totalPopCount { get; private set; }

        public SimpleCommand OpenMapDetailDialog { get; }

        public readonly Session model;

        public MainViewModel(Session model) : base(Loxodon.Framework.Messaging.Messenger.Default)
        {
            this.model = model;

            model.provinces.Connect().OnItemRemoved(_ => { }).Subscribe(prov =>
            {
                UpdateTotalPopCount();
            });

            model.provinces.Connect().OnItemAdded(_ => { }).Subscribe(prov =>
            {
                UpdateTotalPopCount();
            });

            model.provinces.Connect().WhenPropertyChanged(x => x.popCount).Subscribe(_ =>
            {
                UpdateTotalPopCount();
            });

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
            if (disposing)
            {

            }
        }


        private void UpdateTotalPopCount()
        {
            totalPopCount = model.provinces.Items.Sum(x => x.popCount);
        }
    }
}

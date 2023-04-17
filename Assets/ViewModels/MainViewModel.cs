﻿using DynamicData;
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

        public readonly Session model;

        private CompositeDisposable disposables;

        public MainViewModel(Session model) : base(Loxodon.Framework.Messaging.Messenger.Default)
        {
            this.model = model;
            this.disposables = new CompositeDisposable();

            disposables.Add(model.provinces.AsObservableList().Sum(x => x.popCount).Subscribe(sum => totalPopCount = sum));

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

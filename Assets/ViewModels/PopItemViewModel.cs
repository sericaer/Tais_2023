using DynamicData.Binding;
using Loxodon.Framework.ViewModels;
using Tais.Models;
using Tais.ViewModels.Interfaces;
using System;
using Tais.Extensions;
using System.Reactive.Disposables;
using Loxodon.Framework.Commands;

namespace Tais.Scenes
{
    public class PopItemViewModel : ViewModelBase, IPopItemViewModel
    {
        public string type { get; private set; }

        public string num { get; private set; }

        public ICommand OpenPopDetailDialog { get; }

        private CompositeDisposable disposables = new CompositeDisposable();
        private Pop model;

        public PopItemViewModel(Pop model) : base(Loxodon.Framework.Messaging.Messenger.Default)
        {
            this.model = model;

            model.WhenValueChanged(x => x.name).Subscribe(n => type = n).AddTo(disposables);
            model.WhenValueChanged(x => x.count).Subscribe(n => num = ((int)n).ToString()).AddTo(disposables);

            OpenPopDetailDialog = new SimpleCommand(() =>
            {
                Messenger.Publish(new MESSAGE_SHOW_DIALOG()
                {
                    dialogName = "popDetailDialog",
                    viewModel = new PopDetailDialogViewModel(model)
                });
            });
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposables.Dispose();
        }
    }
}
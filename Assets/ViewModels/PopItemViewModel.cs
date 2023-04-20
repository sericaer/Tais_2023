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
    public class PopItemViewModel : AbstractViewModel<Pop>, IPopItemViewModel
    {
        public string type { get; private set; }

        public string num { get; private set; }

        public ICommand OpenPopDetailDialog { get; }


        public PopItemViewModel(Pop pop) : base(pop)
        {
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
    }
}
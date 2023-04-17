//using Aya.DataBinding;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.ViewModels;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.Variables;
using System;
using System.Reactive.Disposables;

namespace Tais.Views
{
    public abstract class ViewBase : UIView
    {
        public abstract IViewModel viewModel { get; set; }
    }

    public abstract class UIView<TViewModel> : ViewBase
        where TViewModel : class, IViewModel
    {
        public VariableArray variables;

        public override IViewModel viewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                if(_viewModel != null)
                {
                    throw new Exception();
                }

                if(!(value is TViewModel))
                {
                    throw new Exception();
                }

                if(_viewModel != value)
                {
                    _viewModel = value as TViewModel;
                    this.BindingContext().DataContext = _viewModel;
                }
            }
        }

        private TViewModel _viewModel;
        private CompositeDisposable disposables { get; } = new CompositeDisposable();
        protected IMessenger messenger { get; } = Messenger.Default;

        protected void SubscribeMessage<T>(Action<T> processer)
        {
            disposables.Add(messenger.Subscribe<T>(processer));
        }

        protected override void OnDestroy()
        {
            disposables.Dispose();
            _viewModel?.Dispose();
        }
    }
}
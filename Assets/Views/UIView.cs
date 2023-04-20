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
    public abstract class BaseView : UIView
    {
        public static IMessenger messenger { get; set; }

        public abstract IViewModel viewModel { get; set; }
    }

    public abstract class UIView<TViewModel> : BaseView
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
        protected CompositeDisposable disposables { get; } = new CompositeDisposable();

        protected override void OnDestroy()
        {
            disposables.Dispose();
            _viewModel?.Dispose();
        }
    } 

    public static class UIViewExtensions
    {
        public static void AddTo<T>(this ISubscription<T> disposable, CompositeDisposable disposables)
        {
            disposables.Add(disposable);
        }
    }
}
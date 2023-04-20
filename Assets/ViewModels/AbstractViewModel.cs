using Loxodon.Framework.ViewModels;
using System.Reactive.Disposables;

namespace Tais.Scenes
{
    public abstract class AbstractViewModel<TModel> : ViewModelBase
    {
        protected readonly TModel model;

        protected CompositeDisposable disposables = new CompositeDisposable();

        public AbstractViewModel(TModel model) : base(Loxodon.Framework.Messaging.Messenger.Default)
        {
            this.model = model;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposables.Dispose();
        }
    }
}

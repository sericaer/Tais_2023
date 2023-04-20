using Loxodon.Framework.Messaging;
using System.Reactive.Disposables;

namespace Tais.Scenes
{
    public abstract class AbstractViewModel<TModel> : BaseViewModel
    {
        protected readonly TModel model;

        protected CompositeDisposable disposables = new CompositeDisposable();

        public AbstractViewModel(TModel model)
        {
            this.model = model;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposables.Dispose();
        }
    }

    public class BaseViewModel : Loxodon.Framework.ViewModels.ViewModelBase
    {
        public static Messenger messenger
        {
            get
            {
                return _messenger;
            }
            set
            {
                _messenger = value;
            }
        }

        private static Messenger _messenger;

        public BaseViewModel()
        {
            if (_messenger == null)
            {
                throw new System.Exception();
            }

            this.Messenger = _messenger;
        }
    }
}

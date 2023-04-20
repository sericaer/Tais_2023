using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Messaging;
using Tais.Models;
using Tais.Views;
using UnityEngine;

namespace Tais.Scenes
{
    class MainScene : MonoBehaviour
    {
        public MainView mainView;

        private Session session;


        public void OnTimeInc()
        {
            session.date.day++;
        }

        void Awake()
        {
            var context = Context.GetApplicationContext();
            var bindingService = new BindingServiceBundle(context.GetContainer());
            bindingService.Start();

            var UIMessager = new Messenger();
            BaseViewModel.messenger = UIMessager;
            BaseView.messenger = UIMessager;
        }

        void Start()
        {
            session = new Session();
            mainView.viewModel = new MainViewModel(session);
        }
    }
}

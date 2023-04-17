using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Tais.Models;
using Tais.Views;
using UnityEngine;

namespace Tais.Scenes
{
    class MainScene : MonoBehaviour
    {
        public MainView mainView;

        private Session session;

        private void Awake()
        {
            var context = Context.GetApplicationContext();
            var bindingService = new BindingServiceBundle(context.GetContainer());
            bindingService.Start();
        }

        void Start()
        {
            session = new Session();

            mainView.viewModel = new MainViewModel(session);
        }

        void Update()
        {
            foreach (var prov in session.provinces.Items)
            {
                prov.popCount++;
            }
        }
    }
}

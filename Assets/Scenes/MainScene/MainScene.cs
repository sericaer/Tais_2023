using Tais.Models;
using UnityEngine;

namespace Tais.Scenes
{
    class MainScene : MonoBehaviour
    {
        public MainView mainView;

        private Session session;

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

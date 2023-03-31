using Aya.DataBinding;
using Aya.Events;
using System;
using Tais.UIViews.Messages;
using UnityEngine;

namespace Tais.Views
{
    public class MainSceneView
    {
        [BindValueSource("roleName")]
        public string roleName;

        [BindValueSource("rolePrestige")]
        public int rolePrestige;

        [BindValueSource("roleHeath")]
        public int roleHeath;

        [BindValueSource("rolePress")]
        public int rolePress;

        [BindValueSource("popNum")]
        public int popNum;

        [BindValueSource("cmdShowPlayer")]
        public ICommand ShowPlayer = new Command()
        {
            funcExecute = () => { UEvent.Dispatch(new MESSAGE_SHOW_PERSON_DETAIL()); }
        };
    }

    public class Command : ICommand
    {
        public Func<bool> funcCanExecute;
        public Action funcExecute;

        public bool CanExecute()
        {
            return funcCanExecute == null ? true : funcCanExecute.Invoke();
        }

        public void Execute()
        {
            funcExecute?.Invoke();
        }
    }

    [EventEnum]
    public enum GameEventType
    {
        GameStart,
        GameFinish,
    }
}

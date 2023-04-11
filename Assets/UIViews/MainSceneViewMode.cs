using Aya.Events;
using PropertyChanged;
using Sericaer.UIBind.Runtime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tais.Sessions;
using Tais.UIViews.Messages;

namespace Tais.Views
{
    [AddINotifyPropertyChangedInterface]
    public class MainSceneViewMode
    {
        public string roleName { get; private set; }

        public int rolePrestige { get; private set; }

        public int roleHeath { get; private set; }

        public int rolePress { get; private set; }

        public int popNum { get; set; }

        public ICommand ShowPlayer { get; } = new Command()
        {
            execAction = () => { UEvent.Dispatch(new MESSAGE_SHOW_PERSON_DETAIL()); }
        };

        public ICommand CommandShowMap { get; } 

        private Session session;

        public MainSceneViewMode()
        {
            session = new Session();

            CommandShowMap = new Command()
            {
                execAction = () => { UEvent.Dispatch(new MESSAGE_SHOW_MAP_DETAIL(session.provinces)); }
            };
        }
    }

    public class Command : ICommand
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Action execAction;

        public bool isEnable => true;

        public void Exec()
        {
            execAction?.Invoke();
        }
    }
}

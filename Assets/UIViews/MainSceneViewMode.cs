using Aya.Events;
using Sericaer.UIBind.Runtime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tais.UIViews.Messages;

namespace Tais.Views
{
    public class MainSceneViewMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string roleName { get; private set; }

        public int rolePrestige { get; private set; }

        public int roleHeath { get; private set; }

        public int rolePress { get; private set; }

        public int popNum
        {
            get
            {
                return _popNum;
            }
            set
            {
                if(_popNum == value)
                {
                    return;
                }

                _popNum = value;
                NotifyPropertyChanged();
            }
        }



        private int _popNum;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand ShowPlayer { get; } = new Command()
        {
            execAction = () => { UEvent.Dispatch(new MESSAGE_SHOW_PERSON_DETAIL()); }
        };
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

    [EventEnum]
    public enum GameEventType
    {
        GameStart,
        GameFinish,
    }
}

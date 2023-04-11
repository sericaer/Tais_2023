using Aya.Events;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        //[BindValueSource("cmdShowPlayer")]
        //public ICommand ShowPlayer = new Command()
        //{
        //    funcExecute = () => { UEvent.Dispatch(new MESSAGE_SHOW_PERSON_DETAIL()); }
        //};
    }

    //public class Command : ICommand
    //{
    //    public Func<bool> funcCanExecute;
    //    public Action funcExecute;

    //    public bool CanExecute()
    //    {
    //        return funcCanExecute == null ? true : funcCanExecute.Invoke();
    //    }

    //    public void Execute()
    //    {
    //        funcExecute?.Invoke();
    //    }
    //}

    [EventEnum]
    public enum GameEventType
    {
        GameStart,
        GameFinish,
    }
}

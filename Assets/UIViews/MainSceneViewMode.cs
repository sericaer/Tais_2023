using Aya.Events;
using Sericaer.UIBind.Runtime;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Tais.Sessions;
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

        public int popNum { get; private set; }

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

            UpdatePopNum();

            session.provinces.ListChanged += ProvincesListChanged;
        }

        public void Update()
        {
            foreach(var province in session.provinces)
            {
                province.popCount++;
            }
        }

        private void ProvincesListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded 
                || e.ListChangedType == ListChangedType.ItemMoved)
            {
                UpdatePopNum();
            }
            if (IsPropertyChanged(e, nameof(Province.popCount)))
            {
                UpdatePopNum();
            }
        }

        private bool IsPropertyChanged(ListChangedEventArgs e, string propertyName)
        {
            return e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor.Name == propertyName;
        }

        private void UpdatePopNum()
        {
            popNum = session.provinces.Sum(x => x.popCount);
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

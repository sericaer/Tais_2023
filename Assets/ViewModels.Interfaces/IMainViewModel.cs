using Loxodon.Framework.Commands;
using Loxodon.Framework.ViewModels;
using System.ComponentModel;

namespace Tais.ViewModels.Interfaces
{
    public interface IMainViewModel : IViewModel, INotifyPropertyChanged
    {
        string roleName { get;}

        int totalPopCount { get;}

        string year { get; }
        string month { get; }
        string day { get; }

        SimpleCommand OpenMapDetailDialog { get; }
    }
}

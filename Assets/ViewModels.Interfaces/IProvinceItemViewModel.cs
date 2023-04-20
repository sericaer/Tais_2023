using Loxodon.Framework.Commands;
using Loxodon.Framework.ViewModels;
using System.ComponentModel;

namespace Tais.ViewModels.Interfaces
{
    public interface IProvinceItemViewModel : IViewModel, INotifyPropertyChanged
    {
        string name { get; }
        int popCount { get; }

        ICommand OpenProvinceDetailDialog { get; }
    }
}

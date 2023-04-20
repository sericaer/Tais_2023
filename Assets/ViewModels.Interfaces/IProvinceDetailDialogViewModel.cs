using Loxodon.Framework.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Tais.ViewModels.Interfaces
{
    public interface IProvinceDetailDialogViewModel : IViewModel, INotifyPropertyChanged
    {
        string name { get; }
        string popNum { get; }

        ReadOnlyObservableCollection<IPopItemViewModel> popItems { get; }
    }
}

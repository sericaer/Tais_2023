using Loxodon.Framework.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Tais.ViewModels.Interfaces
{
    public interface IMapDetailDialogViewModel : IViewModel, INotifyPropertyChanged
    {
        ReadOnlyObservableCollection<IProvinceItemViewModel> provinceList {get;}
    }
}

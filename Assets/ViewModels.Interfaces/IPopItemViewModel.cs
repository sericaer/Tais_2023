using Loxodon.Framework.ViewModels;
using System.ComponentModel;

namespace Tais.ViewModels.Interfaces
{
    public interface IPopItemViewModel : IViewModel, INotifyPropertyChanged
    {
        string type { get; }
        string num { get; }
    }
}
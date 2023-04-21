using Loxodon.Framework.ViewModels;
using System.ComponentModel;

namespace Tais.ViewModels.Interfaces
{
    public interface IPopDetailDialogViewModel : IViewModel, INotifyPropertyChanged
    {
        string type { get;}
        string num { get;}
        string numInc { get;}
        string living { get; }
        string tax { get; }
    }
}

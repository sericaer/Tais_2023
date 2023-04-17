using Loxodon.Framework.ViewModels;
using Tais.Models;
using Tais.ViewModels.Interfaces;

namespace Tais.Scenes
{
    public class ProvinceItemViewModel : ViewModelBase, IProvinceItemViewModel
    {
        public Province model { get; }

        public ProvinceItemViewModel(Province model)
        {
        }
    }
}
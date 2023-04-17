//using Aya.DataBinding;
using System.ComponentModel;
using Tais.ViewModels.Interfaces;

namespace Tais.Views
{
    public class MapDetailDialogView : UIView<IMapDetailDialogViewModel>
    {
        public ProvinceItemListView provList;

        protected override void Start()
        {
            provList.itemViewModels = ((IMapDetailDialogViewModel)viewModel).provinceList;
        }
    }
}
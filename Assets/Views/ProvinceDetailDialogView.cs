//using Aya.DataBinding;
using Tais.ViewModels.Interfaces;

namespace Tais.Views
{
    public class ProvinceDetailDialogView : UIView<IProvinceDetailDialogViewModel>
    {
        public PopItemListView popViewList;

        protected override void Start()
        {
            popViewList.itemViewModels = ((IProvinceDetailDialogViewModel)viewModel).popItems;
        }
    }
}
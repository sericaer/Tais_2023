//using Aya.DataBinding;
using Tais.ViewModels.Interfaces;

namespace Tais.Scenes
{
    public class MapDetailDialogView : UIView<IMapDetailDialogView>
    {
        protected override void Start()
        {
            //var bindingSet = this.CreateBindingSet<MainView, IMainViewModel>();
            //bindingSet.Bind(variables.Get<Text>("roleName")).For(v => v.text).To(vm => vm.roleName).OneWay();
            //bindingSet.Bind(variables.Get<Text>("popCount")).For(v => v.text).To(vm => vm.totalPopCount).OneWay();
            //bindingSet.Bind(variables.Get<Button>("showMapDetail")).For(v => v.onClick).To(vm => vm.OpenMapDetailDialog);
            //bindingSet.Build();

            //SubscribeMessage<MESSAGE_SHOW_DIALOG>(OnMessageShowDialog);
        }
    }
}
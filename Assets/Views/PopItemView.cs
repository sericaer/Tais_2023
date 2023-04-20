using Loxodon.Framework.Binding;
using Tais.ViewModels.Interfaces;
using UnityEngine.UI;

namespace Tais.Views
{
    public class PopItemView : UIView<IPopItemViewModel>
    {
        protected override void Start()
        {
            var bindingSet = this.CreateBindingSet<PopItemView, IPopItemViewModel>();
            bindingSet.Bind(variables.Get<Text>("type")).For(v => v.text).To(vm => vm.type).OneWay();
            bindingSet.Bind(variables.Get<Text>("num")).For(v => v.text).To(vm => vm.num).OneWay();
            bindingSet.Bind(variables.Get<Button>("showPopDetail")).For(v => v.onClick).To(vm => vm.OpenPopDetailDialog);
            bindingSet.Build();
        }
    }
}
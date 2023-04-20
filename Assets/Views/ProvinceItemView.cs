using Loxodon.Framework.Binding;
using Tais.ViewModels.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Tais.Views
{
    public class ProvinceItemView : UIView<IProvinceItemViewModel>
    {
        protected override void Start()
        {
            var bindingSet = this.CreateBindingSet<ProvinceItemView, IProvinceItemViewModel>();
            bindingSet.Bind(variables.Get<Text>("name")).For(v => v.text).To(vm => vm.name).OneWay();
            bindingSet.Bind(variables.Get<Text>("popCount")).For(v => v.text).To(vm => vm.popCount).OneWay();
            bindingSet.Bind(variables.Get<Button>("showProvinceDetail")).For(v => v.onClick).To(vm => vm.OpenProvinceDetailDialog);
            bindingSet.Build();
        }
    }
}
//using Aya.DataBinding;
using Loxodon.Framework.Binding;
using System;
using Tais.ViewModels.Interfaces;
using UnityEngine.UI;

namespace Tais.Views
{
    public class PopDetailDialogView : UIView<IPopDetailDialogViewModel>
    {
        protected override void Start()
        {
            var bindingSet = this.CreateBindingSet<PopDetailDialogView, IPopDetailDialogViewModel>();
            bindingSet.Bind(variables.Get<Text>("type")).For(v => v.text).To(vm => vm.type).OneWay();
            bindingSet.Bind(variables.Get<Text>("num")).For(v => v.text).To(vm => vm.num).OneWay();
            bindingSet.Bind(variables.Get<Text>("living")).For(v => v.text).To(vm => vm.living).OneWay();
            bindingSet.Bind(variables.Get<Text>("numInc")).For(v => v.text).To(vm => vm.numInc).OneWay();
            bindingSet.Bind(variables.Get<Text>("tax")).For(v => v.text).To(vm => vm.tax).OneWay();
            bindingSet.Build();
        }
    }
}
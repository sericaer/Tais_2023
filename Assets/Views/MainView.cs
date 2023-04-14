//using Aya.DataBinding;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using UnityEngine.UI;
using UnityEngine;
using Tais.ViewModels.Interfaces;
using Loxodon.Framework.Views.Variables;

namespace Tais.Scenes
{
    public class MainView : UIView<IMainViewModel>
    {
        public Transform dialogContainer;

        protected override void Start()
        {
            var bindingSet = this.CreateBindingSet<MainView, IMainViewModel>();
            bindingSet.Bind(variables.Get<Text>("roleName")).For(v => v.text).To(vm => vm.roleName).OneWay();
            bindingSet.Bind(variables.Get<Text>("popCount")).For(v => v.text).To(vm => vm.totalPopCount).OneWay();
            bindingSet.Bind(variables.Get<Button>("showMapDetail")).For(v => v.onClick).To(vm => vm.OpenMapDetailDialog);
            bindingSet.Build();

            SubscribeMessage<MESSAGE_SHOW_DIALOG>(OnMessageShowDialog);
        }

        private void OnMessageShowDialog(MESSAGE_SHOW_DIALOG msg)
        {
            var dialogU = variables.Get(msg.dialogName);
            var dialog = Instantiate(dialogU as ViewBase, dialogContainer);
            dialog.viewModel = msg.viewModel;

            dialog.gameObject.SetActive(true);
        }
    }
}
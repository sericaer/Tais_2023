//using Aya.DataBinding;
using Loxodon.Framework.Binding;
using Tais.ViewModels.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Tais.Views
{
    public class MainView : UIView<IMainViewModel>
    {
        public Transform dialogContainer;

        protected override void Start()
        {
            var bindingSet = this.CreateBindingSet<MainView, IMainViewModel>();

            bindingSet.Bind(variables.Get<Text>("roleName")).For(v => v.text).To(vm => vm.roleName).OneWay();
            bindingSet.Bind(variables.Get<Text>("popCount")).For(v => v.text).To(vm => vm.totalPopCount).OneWay();

            bindingSet.Bind(variables.Get<Text>("year")).For(v => v.text).To(vm => vm.year).OneWay();
            bindingSet.Bind(variables.Get<Text>("month")).For(v => v.text).To(vm => vm.month).OneWay();
            bindingSet.Bind(variables.Get<Text>("day")).For(v => v.text).To(vm => vm.day).OneWay();

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
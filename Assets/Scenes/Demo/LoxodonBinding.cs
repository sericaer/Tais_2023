using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Binding.Contexts;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using Loxodon.Framework.Views;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Tais.Scenes
{ 
    public class LoxodonBinding : UIView
    {
        //class TestData : ObservableObject
        //{
        //    private int id;

        //    public int ID
        //    {
        //        get { return this.id; }
        //        set { this.Set<int>(ref this.id, value); }
        //    }
        //}

        class TestData : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private int id;

            public int ID
            {
                get { return this.id; }
                set { 

                    if(value == id)
                    {
                        return;
                    }

                    id = value;
                    NotifyPropertyChanged();
                }
            }

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        public Text description;

        private TestData testData;
        protected override void Awake()
        {
            ApplicationContext context = Context.GetApplicationContext();
            BindingServiceBundle bindingService = new BindingServiceBundle(context.GetContainer());
            bindingService.Start();
        }

        protected override void Start()
        {
            testData = new TestData() { ID = 11 };

            IBindingContext bindingContext = this.BindingContext();
            bindingContext.DataContext = testData;

            /* databinding */
            var bindingSet = this.CreateBindingSet<LoxodonBinding, TestData>();

            bindingSet.Bind(this.description).For(v => v.text).To(vm => vm.ID).OneWay();
            bindingSet.Build();

        }

        private void Update()
        {
            testData.ID++;
        }
    }
}

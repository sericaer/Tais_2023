using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Tais.Extensions;

namespace Tais.Models
{
    public class ProvinceInit
    {
        public string name { get; set; }
        public PopInit[] popInits { get; set; }
    }

    public class Province : Entity, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }
        public int popCount { get; set; }

        public SourceList<Pop> pops { get; }

        public PopTaxLevel popTaxLevel { get; }

        public Province(ProvinceInit provinceInit)
        {
            this.name = provinceInit.name;
            this.pops = new SourceList<Pop>();

            pops.Sum(x => x.count).Subscribe(sum =>
            {
                popCount = (int)sum;
            }).AddTo(disposables);

            pops.AddRange(provinceInit.popInits.Select(init => new Pop(init, popTaxLevel.ouputEffect)));


        }

        public class PopTaxLevel
        {
            public int levelCount { get; }
            public SourceList<IEffect> ouputEffect { get; } = new SourceList<IEffect>();
        }
    }

    interface ICache
    {
        protected object objValue { get; }
        bool isDirty { get; }
    }
}

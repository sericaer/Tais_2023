using DynamicData;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Tais.Extensions;

namespace Tais.Models
{
    public class ProvinceInit
    {
        public string name { get; set; }
        public PopInit[] popInits { get; set; }
    }

    public class Province : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }
        public int popCount { get; set; }

        public SourceList<Pop> pops { get; }

        private CompositeDisposable disposables;

        public Province(ProvinceInit provinceInit)
        {
            this.name = provinceInit.name;
            this.pops = new SourceList<Pop>();

            this.disposables = new CompositeDisposable();
            disposables.Add(pops.AsObservableList().Sum(x => x.count).Subscribe(sum => popCount = (int)sum));

            pops.AddRange(provinceInit.popInits.Select(init => new Pop(init)));

        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}

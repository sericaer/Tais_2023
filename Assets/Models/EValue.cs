using DynamicData;
using System.ComponentModel;
using System;
using System.Linq;
using Tais.Extensions;
using System.Reactive.Disposables;

namespace Tais.Models
{
    public interface IEValue : IDisposable
    {
        double baseValue { get; }
        double currValue { get; }
        string desc { get; }

        SourceList<IEffect> ouputEffect { get; }

        SourceList<IEffect> inputEffected { get; }

        Type recvEffectType { get; }
    }

    public class EValue<T> : IEValue, INotifyPropertyChanged, IDisposable
        where T : IEffect
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double baseValue { get; }
        public double currValue { get; private set; }
        public string desc { get; }

        public SourceList<IEffect> ouputEffect { get; } = new SourceList<IEffect>();

        public SourceList<IEffect> inputEffected { get; } = new SourceList<IEffect>();

        public Type recvEffectType { get; } = typeof(T);

        protected CompositeDisposable disposables = new CompositeDisposable();

        public EValue(double baseValue, EValueGroup group)
        {
            this.baseValue = baseValue;
            this.currValue = baseValue;

            inputEffected.Connect().QueryWhenChanged().Subscribe(_ => UpdateCurrentValue()).AddTo(disposables);

            group.Add(this);
        }

        void UpdateCurrentValue()
        {
            currValue = baseValue * (1 + inputEffected.Items.Sum(e=>e.value));
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}

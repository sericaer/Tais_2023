using DynamicData;
using System.ComponentModel;
using System;
using System.Linq;
using Tais.Extensions;

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

        private IDisposable disposable;

        public EValue(double baseValue, EValueGroup group)
        {
            this.baseValue = baseValue;
            this.currValue = baseValue;

            this.disposable = inputEffected.Connect().QueryWhenChanged().Subscribe(_ => UpdateCurrentValue());

            group.Add(this);
        }

        void UpdateCurrentValue()
        {
            currValue = baseValue * (1 + inputEffected.Items.Sum(e=>e.value));
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}

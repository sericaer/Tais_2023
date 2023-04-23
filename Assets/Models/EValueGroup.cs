using DynamicData;
using System.Collections.Generic;
using System;
using Tais.Extensions;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Tais.Models
{
    public class EValueGroup : IDisposable
    {
        private Dictionary<Type, IEValue> dict = new Dictionary<Type, IEValue>();

        private CompositeDisposable disposables = new CompositeDisposable();


        private SourceList<IEValue> sourceList = new SourceList<IEValue>();
        private IObservableList<IEffect> effectPool;

        public EValueGroup(SourceList<IEffect> extEffects)
        {
            effectPool = Observable.Merge(extEffects.Connect(), 
                sourceList.Connect().MergeMany(x => x.ouputEffect.Connect())).AsObservableList();
        }

        public void Add(IEValue eValue)
        {
            sourceList.Add(eValue);

            effectPool.Connect().OnItemAdded(item =>
            {
                dict[item.GetType()].inputEffected.Add(item);
            }).Subscribe().AddTo(disposables);

            effectPool.Connect().OnItemRemoved(item =>
            {
                dict[item.GetType()].inputEffected.Remove(item);
            }).Subscribe().AddTo(disposables);

            dict.Add(eValue.recvEffectType, eValue);
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}

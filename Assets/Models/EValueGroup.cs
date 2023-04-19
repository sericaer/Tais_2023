using DynamicData;
using System.Collections.Generic;
using System;
using Tais.Extensions;
using System.Reactive.Disposables;

namespace Tais.Models
{
    public class EValueGroup : IDisposable
    {
        private Dictionary<Type, IEValue> dict = new Dictionary<Type, IEValue>();

        private CompositeDisposable disposables = new CompositeDisposable();

        public void Add(IEValue eValue)
        {
            eValue.AddTo(disposables);

            eValue.ouputEffect.Connect().OnItemAdded(effect =>
            {
                if (dict.TryGetValue(effect.GetType(), out IEValue recv))
                {
                    recv.inputEffected.Remove(effect);
                }
            }).Subscribe().AddTo(disposables);

            eValue.ouputEffect.Connect().OnItemRemoved(effect =>
            {
                if (dict.TryGetValue(effect.GetType(), out IEValue recv))
                {
                    recv.inputEffected.Add(effect);
                }

            }).Subscribe().AddTo(disposables);

            dict.Add(eValue.recvEffectType, eValue);
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}

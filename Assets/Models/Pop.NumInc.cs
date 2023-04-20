using DynamicData.Binding;
using System;

namespace Tais.Models
{

    public partial class Pop
    {
        public class NumInc : EValue<PopCountIncEffect>
        {
            public NumInc(double baseValue, EValueGroup group) : base(baseValue, group)
            {
                this.WhenPropertyChanged(x => x.currValue).Subscribe(_ => UpdateOutpuEffects());
            }

            private void UpdateOutpuEffects()
            {

            }
        }
    }
}

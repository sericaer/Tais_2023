using DynamicData;
using System.ComponentModel;
using Tais.Models.Messages;
using System;
using Tais.Extensions;
using DynamicData.Binding;

namespace Tais.Models
{
    public class PopInit
    {
        public string type { get; set; }
        public double count { get; set; }
    }

    public partial class Pop : Entity, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; }

        public double count { get; private set; }

        public NumInc numInc { get; }
        public Living living { get; }
        public Tax tax { get; }
        
        private EValueGroup eValueGroup { get; }


        public Pop(PopInit init)
        {
            this.name = init.type;
            this.count = init.count;

            eValueGroup = new EValueGroup();
            eValueGroup.AddTo(disposables);

            numInc = new NumInc(0.001, eValueGroup);
            living = new Living(100, eValueGroup);
            tax = new Tax(CalcTaxBase(), eValueGroup);

            this.WhenValueChanged(x => x.count).Subscribe(_ => tax.baseValue = CalcTaxBase()).AddTo(disposables);
        }

        private double CalcTaxBase()
        {
            return count * 0.001;
        }

        [MessageProcesser]
        void OnMessage(MESSAG_DAY_INC msg)
        {
            count += count * numInc.currValue;
        }
    }

    public class Tax :EValue<PopTaxEffect>
    {
        public Tax(double baseValue, EValueGroup eValueGroup) : base(baseValue, eValueGroup)
        {

        }
    }

    public class PopTaxEffect : IEffect
    {
        public string desc => throw new NotImplementedException();

        public double value => throw new NotImplementedException();
    }
}

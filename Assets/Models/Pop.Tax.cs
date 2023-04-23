namespace Tais.Models
{

    public partial class Pop
    {
        public class Tax : EValue<PopTaxEffect>
        {
            public Tax(double baseValue, EValueGroup eValueGroup) : base(baseValue, eValueGroup)
            {

            }
        }

    }
}

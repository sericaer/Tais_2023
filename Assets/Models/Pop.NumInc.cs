namespace Tais.Models
{

    public partial class Pop
    {
        public class NumInc : EValue<PopCountIncEffect>
        {
            public NumInc(double baseValue, EValueGroup group) : base(baseValue, group)
            {

            }
        }
    }
}

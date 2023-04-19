namespace Tais.Models
{

    public partial class Pop
    {
        public class Living : EValue<PopLivingEffect>
        {
            public Living(double baseValue, EValueGroup group) : base(baseValue, group)
            {

            }
        }
    }
}

namespace Tais.Models
{
    public interface IEffect
    {
        string desc { get; }
        double value { get; }
    }

    public class PopCountIncEffect : IEffect
    {
        public string desc { get; }
        public double value { get; }
    }

    public class PopLivingEffect : IEffect
    {
        public string desc { get; }
        public double value { get; }
    }

    public class PopTaxEffect : IEffect
    {
        public string desc { get; }

        public double value { get; }
    }
}

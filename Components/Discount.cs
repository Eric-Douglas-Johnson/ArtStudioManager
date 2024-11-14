
namespace ArtStudioManager.Components
{
    public abstract class Discount
    {
        public abstract decimal GetAmount();
    }

    public class PercentageDiscount(decimal cost, decimal percentage) : Discount
    {
        public override decimal GetAmount()
        {
            return Math.Round(cost * (percentage / 100), 2);
        }
    }

    public class FlatRateDiscount(decimal flatRate) : Discount
    {
        public override decimal GetAmount()
        {
            return flatRate;
        }
    }
}

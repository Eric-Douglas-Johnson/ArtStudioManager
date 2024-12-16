
namespace ArtStudioManager.Components
{
    public class FlatRateDiscount : Discount
    {
        public decimal FlatRate { get; private set; }

        public FlatRateDiscount(decimal flatRate)
        {
            if (flatRate < 0) { throw new ArgumentException("Flat Rate must be greater than zero."); }

            FlatRate = flatRate;
        }

        public override decimal GetAmount()
        {
            return FlatRate;
        }
    }
}

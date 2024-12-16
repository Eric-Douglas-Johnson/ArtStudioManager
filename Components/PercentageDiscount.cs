
namespace ArtStudioManager.Components
{
    public class PercentageDiscount : Discount
    {   
        public decimal Cost { get; private set; }
        public decimal Percentage { get; private set; }

        /// <summary>
        /// Discount as a percentage of the cost.
        /// </summary>
        /// <param name="cost">Must be greater than zero</param>
        /// <param name="percentage">Must be between 0.0 and 1.0</param>
        /// <exception cref="ArgumentException">Thrown when cost or percentage are less than zero.</exception>
        public PercentageDiscount(decimal cost, decimal percentage)
        {
            if (cost < 0) { throw new ArgumentException("Cost must be greater than zero."); }
            if (percentage < 0 || percentage > 1.0M) { throw new ArgumentException("Percentage must be between 0.0 and 1.0."); }

            Cost = cost;
            Percentage = percentage;
        }

        public override decimal GetAmount()
        {
            return Math.Round(Cost * (Percentage / 100), 2);
        }
    }
}

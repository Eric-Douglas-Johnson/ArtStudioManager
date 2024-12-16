namespace ArtStudioManager.Components.Models
{
    public class Party
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhoneNumber { get; set; }
        public string? ContactEmail { get; set; }
        public int AttendeeCount { get; set; } = 0;
        public string? EmployeeName { get; set; }
        public ICollection<Material>? Materials { get; set; }
        public decimal? DollarAmountCharged { get; set; }

        public decimal GetTotalMaterialCost()
        {
            if (Materials == null) { throw new InvalidOperationException("Null Materials"); }

            decimal cost = 0;

            foreach (var material in Materials)
            {
                cost += material.Cost;
            }

            return cost;
        }
    }
}

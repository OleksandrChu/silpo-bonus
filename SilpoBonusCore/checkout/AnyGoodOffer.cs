namespace SilpoBonusCore.checkout
{
    public class AnyGoodOffer : Offer
    {
        private readonly int totalCost;
        private readonly int points;

        public AnyGoodOffer(int totalCost, int points)
        {
            this.totalCost = totalCost;
            this.points = points;
        }

        public override void Apply(Check check)
        {
            if (check.GetTotalCost() >= totalCost)
            {
                check.AddPoints(points);
            }
        }
    }
}
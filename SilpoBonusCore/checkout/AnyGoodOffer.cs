using System;

namespace SilpoBonusCore.checkout
{
    public class AnyGoodOffer : Offer
    {
        private readonly int totalCost;
        private readonly int points;
        public AnyGoodOffer(int totalCost, int points, DateTime expirationDate)
        {
            this.totalCost = totalCost;
            this.points = points;
            this.expirationDate = expirationDate;
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
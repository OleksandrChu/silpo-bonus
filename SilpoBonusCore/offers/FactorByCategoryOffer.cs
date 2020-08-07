using System;
using SilpoBonusCore.checkout;
using SilpoBonusCore.models;

namespace SilpoBonusCore.offers
{
    public class FactorByCategoryOffer : Offer
    {
        private readonly Category category;
        private int factor;
        private int cost;

        public FactorByCategoryOffer(Category category, int factor, DateTime expirationDate)
        {
            this.category = category;
            this.factor = factor;
            this.expirationDate = expirationDate;
        }

        public override void Apply(Check check)
        {
            check.AddPoints(check.GetCostByCategory(category) * (this.factor - 1));
        }

        public override bool IsSatisfyCondition(Check check)
        {
            cost = check.GetCostByCategory(category);
            return cost > 0;
        }
    }
}
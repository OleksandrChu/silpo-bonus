using System;
using SilpoBonusCore.checkout;
using SilpoBonusCore.models;

namespace SilpoBonusCore.offers
{
    public class DiscountOffer : Offer
    {
        private int percent;
        private Category category;
        private int cost;

        public DiscountOffer(int percent, Category category, DateTime expirationDate)
        {
            this.percent = percent;
            this.category = category;
            this.expirationDate = expirationDate;
        }

        public override void Apply(Check check)
        {
            check.AddDiscount(cost * percent / 100);
        }

        public override bool IsSatisfyCondition(Check check)
        {
            cost = check.GetCostByCategory(category);
            return cost > 0;
        }
    }
}
using System;

namespace SilpoBonusCore.checkout
{
    public class FactorByCategoryOffer : Offer
    {
        private readonly Category category;
        private int factor;

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
    }
}
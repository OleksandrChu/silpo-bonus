using System;
using SilpoBonusCore.checkout;
using SilpoBonusCore.condition;
using SilpoBonusCore.discount;
using SilpoBonusCore.models;
using SilpoBonusCore.rewards;

namespace SilpoBonusCore.offers
{
    public class DiscountOffer : Offer
    {
        private int percent;
        private Category category;
        private int cost;
        private IDiscountRule discountRule;

        public DiscountOffer(IDiscountRule discountRule, ICondition condition, DateTime expirationDate)
        {
            this.discountRule = discountRule;
            this.condition = condition;
            this.expirationDate = expirationDate;
        }

        public override void Apply(Check check)
        {
            check.AddDiscount(discountRule.CalcDiscount(check));
        }

        public override bool IsSatisfyCondition(Check check)
        {
            return condition.Check(check);
        }
    }
}
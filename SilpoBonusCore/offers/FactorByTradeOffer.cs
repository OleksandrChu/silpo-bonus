using System;
using SilpoBonusCore.checkout;
using SilpoBonusCore.models;

namespace SilpoBonusCore.offers
{
    public class FactorByTradeOffer : Offer
    {
        private Trade trade;
        private int factor;
        private int cost;

        public FactorByTradeOffer(Trade trade, int factor, DateTime expirationDate)
        {
            this.trade = trade;
            this.factor = factor;
            this.expirationDate = expirationDate;
        }

        public override void Apply(Check check)
        {
            check.AddPoints(cost * (this.factor - 1));
        }

        public override bool IsSatisfyCondition(Check check)
        {
            cost = check.GetCostByTrade(trade);
            return cost > 0;
        }
    }
}
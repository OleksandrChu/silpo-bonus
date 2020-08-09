using System;
using SilpoBonusCore.checkout;
using SilpoBonusCore.condition;
using SilpoBonusCore.rewards;

namespace SilpoBonusCore.offers
{
    public class BonusOffer : Offer
    {
        private IReward reward;

        public BonusOffer(IReward reward, ICondition condition, DateTime expirationDate)
        {
            this.reward = reward;
            this.condition = condition;
            this.expirationDate = expirationDate;
        }

        public override void Apply(Check check)
        {
            check.AddPoints(reward.CalcPoints(check));
        }

        public override bool IsSatisfyCondition(Check check)
        {
            return condition.Check(check);
        }
    }
}
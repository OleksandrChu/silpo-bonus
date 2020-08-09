using SilpoBonusCore.checkout;
using SilpoBonusCore.models;

namespace SilpoBonusCore.condition
{
    public class TradeCondition : ICondition
    {
        private Trade trade;

        public TradeCondition(Trade trade)
        {
            this.trade = trade;
        }

        public bool Check(Check check)
        {
            return check.GetCostByTrade(trade) > 0;
        }
    }
}
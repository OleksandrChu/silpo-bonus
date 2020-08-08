using SilpoBonusCore.checkout;
using SilpoBonusCore.models;

namespace SilpoBonusCore.rewards
{
    public class Factor : IReward
    {
        private Category category;
        private Trade trade;
        private int factor;
        public Factor(Trade trade, int factor)
        {
            this.trade = trade;
            this.factor = factor;
        }

        public Factor(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }

        public int CalcPoints(Check check)
        {
            return check.GetCostByCategory(category) * (this.factor - 1);
        }
    }
}
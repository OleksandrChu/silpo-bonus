using SilpoBonusCore.checkout;

namespace SilpoBonusCore.condition
{
    public class TotalCostCondition : ICondition
    {
        private int cost;

        public TotalCostCondition(int cost)
        {
            this.cost = cost;
        }

        public bool Check(Check check)
        {
            return check.GetTotalCost() >= cost;
        }
    }
}
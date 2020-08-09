using SilpoBonusCore.checkout;

namespace SilpoBonusCore.condition
{
    public class CountCondition : ICondition
    {
        private int number;

        public CountCondition(int number)
        {
            this.number = number;
        }

        public bool Check(Check check) => check.GetProductsCount() >= number;
    }
}
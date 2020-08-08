using SilpoBonusCore.checkout;
using SilpoBonusCore.models;

namespace SilpoBonusCore.discount
{
    public class PercentDiscount : Discount
    {
        private int percent;
        private Category category;

        public PercentDiscount(int percent, Category category)
        {
            this.percent = percent;
            this.category = category;
        }

        protected override void SetDiscount(Check check)
        {
           discount = check.GetCostByCategory(category) * percent / 100;
        }
    }
}
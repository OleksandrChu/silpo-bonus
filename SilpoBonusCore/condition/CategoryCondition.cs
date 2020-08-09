using SilpoBonusCore.checkout;
using SilpoBonusCore.models;

namespace SilpoBonusCore.condition
{
    public class CategoryCondition : ICondition
    {
        private int cost;
        private Category category;

        public CategoryCondition(Category category)
        {
            this.category = category;
        }

        public bool Check(Check check) => check.GetCostByCategory(category) > 0;
    }
}
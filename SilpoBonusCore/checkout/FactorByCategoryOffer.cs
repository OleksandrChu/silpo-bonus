namespace SilpoBonusCore.checkout
{
    public class FactorByCategoryOffer : Offer
    {
        internal readonly Category category;
        internal readonly int factor;

        public FactorByCategoryOffer(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }

        public override void Apply(Check check)
        {
            check.AddPoints(check.GetCostByCategory(category));
        }
    }
}
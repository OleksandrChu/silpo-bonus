namespace SilpoBonusCore.checkout
{
    public class FactorByCategoryOffer : Offer
    {
        private readonly Category category;
        private int factor;

        public FactorByCategoryOffer(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }

        public override void Apply(Check check)
        {
            check.AddPoints(check.GetCostByCategory(category) * (this.factor - 1));
        }
    }
}
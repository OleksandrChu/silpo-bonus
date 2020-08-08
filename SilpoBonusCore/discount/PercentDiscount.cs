using SilpoBonusCore.checkout;

namespace SilpoBonusCore.discount
{
    public class PercentDiscount : IDiscountRule
    {
        public Discount CalcDiscount(Check check)
        {
            return new Discount();
        }
    }
}
using SilpoBonusCore.checkout;

namespace SilpoBonusCore.discount
{
    public interface IDiscountRule
    {
        Discount CalcDiscount(Check check);
    }
}
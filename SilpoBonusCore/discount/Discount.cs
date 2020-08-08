using System;
using SilpoBonusCore.checkout;

namespace SilpoBonusCore.discount
{
    public abstract class Discount: IDiscountRule
    {
        protected int discount;
        public Discount CalcDiscount(Check check)
        {
            SetDiscount(check);
            return this;
        }

        protected abstract void SetDiscount(Check check);

        public int GetValue() => discount;
    }
}
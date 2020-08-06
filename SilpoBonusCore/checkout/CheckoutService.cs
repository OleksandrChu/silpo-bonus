using System;

namespace SilpoBonusCore.checkout
{
    public class CheckoutService
    {
        private Check check;
        public void OpenCheck()
        {
            check = new Check();
        }

        public void AddProduct(Product product)
        {
            if (check == null)
            {
                OpenCheck();
            }
            check.AddProduct(product);
        }

        public Check CloseCheck()
        {
            var closedCheck = check;
            check = null;
            return closedCheck;
        }

        public void UseOffer(AnyGoodOffer offer)
        {
            if (check.GetTotalCost() >= offer.totalCost)
            {
                check.AddPoints(offer.points);
            }

        }
    }
}
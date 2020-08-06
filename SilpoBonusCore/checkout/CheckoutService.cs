using System;

namespace SilpoBonusCore.checkout
{
    public class CheckoutService
    {
        private Check check;
        public void OpenCheck() => check = new Check();

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
            UseOffer();
            var closedCheck = check;
            check = null;
            return closedCheck;
        }

        private void UseOffer() => check.UseOffers();

        public void AddOffer(Offer offer) => check.AddOffer(offer);
    }
}
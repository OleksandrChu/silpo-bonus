using System;
using SilpoBonusCore.checkout;
using SilpoBonusCore.models;

namespace SilpoBonusCore.offers
{
    public class BonusOffer : Offer
    {
        int price;
        private Product product;

        public BonusOffer(int price, Product product, DateTime expirationDate)
        {
            this.expirationDate = expirationDate;
            this.price = price;
            this.product = product;
        }
        public override void Apply(Check check)
        {
            check.AddProduct(new Product(price, product.name));
        }

        public override bool IsSatisfyCondition(Check check)
        {
            int cost = check.GetCostByCategory(product.category);
            return cost > 0;
        }
    }
}
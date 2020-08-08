using SilpoBonusCore.checkout;

namespace SilpoBonusCore.discount
{
    public class Gift: Discount
    {
        private Product product;
        private int price;

        public Gift(Product product, int price)
        {
            this.product = product;
            this.price = price;
        }

        protected override void SetDiscount(Check check)
        {
            check.AddProduct(new Product(price, product.name));
        }
    }
}
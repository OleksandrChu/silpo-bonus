using SilpoBonusCore.checkout;
using Xunit;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {
        [Fact]
        public void Close_check_withOneProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk"));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(7, check.GetTotalCost());
        }

        [Fact]
        public void Close_check_withTwoProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk"));
            checkoutService.AddProduct(new Product(3, "Bread"));
            Check check = checkoutService.CloseCheck();
            Assert.Equal(10, check.GetTotalCost());
        }

        [Fact]
        public void Addproduct_whenCheckClosed_openNewCheck()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk"));
            Check milkCheck = checkoutService.CloseCheck();
            Assert.Equal(7, milkCheck.GetTotalCost());

            checkoutService.AddProduct(new Product(3, "Bread"));
            Check breadCheck = checkoutService.CloseCheck();
            Assert.Equal(3, breadCheck.GetTotalCost());
        }

        [Fact]
        public void CloseCheck_CalcTotalPoints()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk"));
            checkoutService.AddProduct(new Product(7, "Milk"));
            checkoutService.AddProduct(new Product(7, "Milk"));
            Check check = checkoutService.CloseCheck();
            // Assert.Equal(21, check.GetTotalPoints());
        }
        [Fact]
        public void UseOffer_AddOfferPoints()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk"));
            checkoutService.AddProduct(new Product(3, "Bread"));
            checkoutService.UseOffer(new AnyGoodOffer(7, 10));

            Check check = checkoutService.CloseCheck();
            Assert.Equal(20, check.GetTotalPoints());
        }

        [Fact]
        public void UseOffer_FactorByCategory()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(new Product(7, "Milk", Category.Milk));
            checkoutService.AddProduct(new Product(7, "Milk", Category.Milk));
            checkoutService.AddProduct(new Product(3, "Bread"));
            checkoutService.UseOffer(new FactorByCategoryOffer(Category.Milk, 3));

            Check check = checkoutService.CloseCheck();
            Assert.Equal(45, check.GetTotalPoints());
        }
    }
}
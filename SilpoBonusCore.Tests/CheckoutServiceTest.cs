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
            check.GetTotalCost();
    
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
    }
}
using System;
using SilpoBonusCore.checkout;
using Xunit;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {
        private DateTime expirationDate = new DateTime(2020, 8, 10);
        private CheckoutService checkoutService;
        private Check check;

        private Product milk;
        private Product bread;

        public CheckoutServiceTest()
        {
            checkoutService = new CheckoutService();
            milk = new Product(7, "Milk", Category.Milk);
            bread = new Product(3, "Bread");
        }

        [Fact]
        public void Close_check_withOneProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(7, check.GetTotalCost());
        }

        [Fact]
        public void Close_check_withTwoProduct()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            check = checkoutService.CloseCheck();
            Assert.Equal(10, check.GetTotalCost());
        }

        [Fact]
        public void Addproduct_whenCheckClosed_openNewCheck()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            Check milkCheck = checkoutService.CloseCheck();
            Assert.Equal(7, milkCheck.GetTotalCost());

            checkoutService.AddProduct(bread);
            Check breadCheck = checkoutService.CloseCheck();
            Assert.Equal(3, breadCheck.GetTotalCost());
        }

        [Fact]
        public void CloseCheck_CalcTotalPoints()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            Check check = checkoutService.CloseCheck();
            Assert.Equal(21, check.GetTotalPoints());
        }

        [Fact]
        public void UseOffer_AddOfferPoints()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            checkoutService.AddOffer(new AnyGoodOffer(7, 10, DateTime.Now));
            check = checkoutService.CloseCheck();
            Assert.Equal(20, check.GetTotalPoints());
        }

        [Fact]
        public void UseOffer_FactorByCategory()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            Check check = checkoutService.CloseCheck();
            Assert.Equal(17, check.GetTotalPoints());
        }

        [Fact]
        public void UseOffers_BeforeCheckWasClosed()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            checkoutService.AddOffer(new FactorByCategoryOffer(Category.Milk, 3, expirationDate));
            checkoutService.AddOffer(new AnyGoodOffer(40, 5, expirationDate));
            check = checkoutService.CloseCheck();
            Assert.Equal(45, check.GetTotalPoints());
        }
    }
}
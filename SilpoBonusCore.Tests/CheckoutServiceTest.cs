using System;
using SilpoBonusCore.checkout;
using SilpoBonusCore.models;
using SilpoBonusCore.offers;
using SilpoBonusCore.rewards;
using SilpoBonusCore.condition;
using Xunit;
using SilpoBonusCore.discount;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {
        private DateTime expirationDate = DateTime.Now.AddDays(10);
        private CheckoutService checkoutService;
        private Check check;
        private Product milk;
        private Product bread;

        public CheckoutServiceTest()
        {
            checkoutService = new CheckoutService();
            milk = new Product(7, "Milk", Category.Milk, Trade.VoloshkolePole);
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

        [Fact]
        public void UseOffer_ByTradeOrCategory()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            checkoutService.AddOffer(new FactorByTradeOffer(Trade.VoloshkolePole, 2, expirationDate));

            check = checkoutService.CloseCheck();
            Assert.Equal(31, check.GetTotalPoints());
        }

        [Fact]
        public void UseDiscountOffer_ByCategory()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            checkoutService.AddOffer(new DiscountOffer(new PercentDiscount(50, Category.Milk), new CategoryCondition(Category.Milk), expirationDate));
            check = checkoutService.CloseCheck();
            Assert.Equal(10, check.GetTotalCost());
        }

        [Fact]
        public void GiftForAPurchaseForOnePoint_ByCategory()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            checkoutService.AddOffer(new DiscountOffer(new Gift(bread, 1), new TotalCostCondition(0), expirationDate));
            check = checkoutService.CloseCheck();
            Assert.Equal(18, check.GetTotalCost());
        }

        [Fact]
        public void UseFlatBonusOffer_ByCategory()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            checkoutService.AddOffer(new BonusOffer(new Flat(20), new CategoryCondition(Category.Milk), expirationDate));
            check = checkoutService.CloseCheck();
            Assert.Equal(30, check.GetTotalPoints());
        }

        [Fact]
        public void UseFlatBonusOffer_WhenTotalCostGraterThen_20()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            checkoutService.AddOffer(new BonusOffer(new Flat(20), new TotalCostCondition(10), expirationDate));
            check = checkoutService.CloseCheck();
            Assert.Equal(30, check.GetTotalPoints());
        }

        [Fact]
        public void UseFactorAndFlatBonusOffer_ByCategory()
        {
            checkoutService.OpenCheck();
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            checkoutService.AddOffer(new BonusOffer(new Factor(Category.Milk, 2), new CategoryCondition(Category.Milk), expirationDate));
            checkoutService.AddOffer(new BonusOffer(new Flat(3), new TotalCostCondition(10), DateTime.Now));
            check = checkoutService.CloseCheck();
            Assert.Equal(20, check.GetTotalPoints());
        }

    }
}
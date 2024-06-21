using NUnit.Framework;
using SeleniumTests.PageObject.Amazon;
using SeleniumTests.EnumData.Amazon;
using SeleniumTests.Utilities;
using System;



namespace SeleniumTests.Tests.Amazon_TestCase
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TC08_CalculateProductPrice : TestBase
    {
        [PageObject]
        private AmazonMainPage mainPage = new AmazonMainPage();
        private AmazonTodayDeals todayDealsPage = new AmazonTodayDeals();
        private AmazonProductPage productPage = new AmazonProductPage();
        private AmazonCartPage cartPage = new AmazonCartPage();

        [Test]
        public void TC08()
        {
            int itemPos = 1;
            int prodQuantity = 3;

            Log.Info("Step 1.Go to amazon.com.au");
            Log.Info("Step 2.Go to Today’s Deals");
            todayDealsPage = mainPage.ClickMenuItem<AmazonTodayDeals>(MainMenuItems.TodayDeals).WaitForDealPageLoad();

            Log.Info("Step 3.Add a product to cart");
            productPage = todayDealsPage.SelectProdToAddCart(itemPos).AddProductToCart();

            Log.Info("Step 4.Go to cart");
            cartPage = mainPage.GoToCart().WaitForPageLoad();

            Log.Info("Step 5.Edit the product quantity");
            cartPage.SelectProductQuantityNumber(1, prodQuantity);

            //VP. Verify that the product has been added to cart
            string prodQty = cartPage.GetProductQuantity(1);
            string prodPriceTemp = cartPage.GetProductPrice(1);
            string prodPrice = prodPriceTemp.Replace("$", "");

            decimal prodQtyConverted = decimal.Parse(prodQty);
            decimal prodPriceConverted = decimal.Parse(prodPrice);
            decimal n = prodQtyConverted * prodPriceConverted;
            
            string comparePrice = n.ToString();
            string totalPrice = cartPage.GetTotalPrice();
            string compareTotalPrice = totalPrice.Replace(",", "");

            Assert.AreEqual(compareTotalPrice, "$" + comparePrice);
        }

    

    }
}
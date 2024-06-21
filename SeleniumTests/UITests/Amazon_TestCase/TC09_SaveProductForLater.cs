using NUnit.Framework;
using SeleniumTests.PageObject.Amazon;
using SeleniumTests.EnumData.Amazon;
using SeleniumTests.Utilities;
using System;
using NUnit.Framework.Interfaces;
using SeleniumCSharp.Core.ElementWrapper;


namespace SeleniumTests.Tests.Amazon_TestCase
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TC09_SaveProductForLater : TestBase
    {
        [PageObject]
        private AmazonMainPage mainPage = new AmazonMainPage();
        private AmazonTodayDeals todayDealsPage = new AmazonTodayDeals();
        private AmazonProductPage productPage = new AmazonProductPage();
        private AmazonCartPage cartPage = new AmazonCartPage();

        [Test]
        
        public void TC09()
        {
            int itemPos = 1;

            Log.Info("Step 1.Go to amazon.com.au");
            Log.Info("Step 2.Go to Today’s Deals");
            todayDealsPage = mainPage.ClickMenuItem<AmazonTodayDeals>(MainMenuItems.TodayDeals).WaitForDealPageLoad();

            Log.Info("Step 3.Add a product to cart");
            string prdName = todayDealsPage.GetProductName(itemPos);
            productPage = todayDealsPage.SelectProdToAddCart(itemPos).AddProductToCart();

            Log.Info("Step 4.Go to cart");
            cartPage = mainPage.GoToCart().WaitForPageLoad();

            Log.Info("Step 5.Save product for later");
            cartPage.SaveProductForLater(prdName);

            //VP. Verify that the product has been save for later
            Assert.IsTrue(cartPage.CheckProductIsSaved(prdName));
        }

    }
}
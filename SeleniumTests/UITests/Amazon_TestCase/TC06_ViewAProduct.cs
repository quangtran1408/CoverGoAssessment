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
    public class TC06_ViewAProduct : TestBase
    {
        [PageObject]
        private AmazonMainPage mainPage = new AmazonMainPage();
        private AmazonTodayDeals todayDealsPage = new AmazonTodayDeals();
        private AmazonProductPage productPage = new AmazonProductPage();


        [Test]
        
        public void TC06()
        {
            int itemPos = 1;

            Log.Info("Step 1.Go to amazon.com.au");
            Log.Info("Step 2.Go to Today’s Deals");
            todayDealsPage = mainPage.ClickMenuItem<AmazonTodayDeals>(MainMenuItems.TodayDeals).WaitForDealPageLoad();

            Log.Info("Step 3.Click on a product");
            string prdDeal = todayDealsPage.GetProductDeal(itemPos);
            string prdName = todayDealsPage.GetProductName(itemPos);

            productPage = todayDealsPage.SelectProdToAddCart(itemPos);

            //VP. Verify that the product has been viewed correctly
            string viewPrdName = productPage.GetViewedProductName().Trim();
            string viewPrdDeal = productPage.GetViewedProductDeal().Trim();
            Assert.AreEqual(prdName, viewPrdName);
            Assert.AreEqual(prdDeal, viewPrdDeal);
        }

    }
}
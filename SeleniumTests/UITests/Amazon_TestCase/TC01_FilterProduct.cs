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
    public class TC01_FilterProduct : TestBase
    {
        [PageObject]
        private AmazonMainPage mainPage = new AmazonMainPage();
        private AmazonTodayDeals todayDealsPage = new AmazonTodayDeals();


        [Test]
        
        public void TC01()
        {
            Log.Info("Step 1.Go to amazon.com.au");
            Log.Info("Step 2.Go to Today’s Deals");
            todayDealsPage = mainPage.ClickMenuItem<AmazonTodayDeals>(MainMenuItems.TodayDeals).WaitForDealPageLoad();

            Log.Info("Step 3.Filter the products by 'Discount'");
            todayDealsPage.SelectDiscountOption(DiscountOptions.Dis10PercentageMore).WaitForPageFiltered();

            //VP. Verify that the page is filtered
            Assert.IsTrue(todayDealsPage.CheckDealPageFiltered());
        }

    }
}
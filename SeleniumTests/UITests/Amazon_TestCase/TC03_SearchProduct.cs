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
    public class TC03_SearchProduct : TestBase
    {
        [PageObject]
        private AmazonMainPage mainPage = new AmazonMainPage();
        private AmazonSearchPage searchPage = new AmazonSearchPage();


        [Test]
        public void TC03()
        {
            string searchProdName = "AAA Batteries";

            Log.Info("Step 1.Go to amazon.com.au");
            Log.Info("Step 2.Search the product “AAA Batteries”");
            searchPage = mainPage.SearchProduct(searchProdName);

            //VP. Verify that the product has been searched correctly
            Assert.IsTrue(searchPage.CheckSearchProductName(searchProdName));
        }

    }
}
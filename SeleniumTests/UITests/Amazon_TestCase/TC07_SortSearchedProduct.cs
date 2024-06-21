using NUnit.Framework;
using SeleniumTests.PageObject.Amazon;
using SeleniumTests.EnumData.Amazon;
using SeleniumTests.Utilities;



namespace SeleniumTests.Tests.Amazon_TestCase
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TC07_SortSearchedProduct : TestBase
    {
        [PageObject]
        private AmazonMainPage mainPage = new AmazonMainPage();
        private AmazonSearchPage searchPage = new AmazonSearchPage();

        [Test]
        public void TC07()
        {
            string searchProdName = "AAA Batteries";

            Log.Info("Step 1.Go to amazon.com.au");
            Log.Info("Step 2.Search for “AAA Batteries”");
            searchPage = mainPage.SearchProduct(searchProdName);

            Log.Info("Step 3.Sort the items by “Price: High to low”");
            searchPage.SelectSortItem(SortItemInSearchPage.HighToLow);

            // VP. Verify the Product is sorted by "Price: High to low"
            Assert.IsTrue(searchPage.CheckSortItemSelected(SortItemInSearchPage.HighToLow));

        }

    }
}
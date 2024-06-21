using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumCSharp.Core.ElementWrapper;
using System;
using SeleniumTests.Utilities;
using SeleniumTests.EnumData.Amazon;
using System.Threading;


namespace SeleniumTests.PageObject.Amazon
{
    public class AmazonTodayDeals : AmazonMainPage
    {
        protected Link SeeMore => new Link("//button[@aria-labelledby='see-more-departments-label']/a[.='See more']");
        protected Label PageHeader => new Label("//h1[contains(.,'Today') and contains(.,'Deals')]");
        protected Label DiscountLabel => new Label("//span[.='Discount']/ancestor::div[1]//label//span/span[.='{0}']");
        private Link Product => new Link("//div[@data-index='0']//div[contains(@class,'GridRow-module')]/div[{0}]//a");
        private Label ProductDeal => new Label("//div[@data-index='0']//div[contains(@class,'GridRow-module')]/div[{0}]//a//span//div[contains(@class,'style_badgeLabel')]/span");
        private Label ProductName => new Label("//div[@data-index='0']//div[contains(@class,'GridRow-module')]/div[{0}]/div[contains(@class,'ProductCard-module__card')]");
        private Label FilterBy => new Label("//span[.='Filtered by']");
        private Link ClearFilter => new Link("//a[.='Clear Filters']");

        public AmazonTodayDeals SelectDiscountOption(DiscountOptions option)
        {
            string optTemp = Utils.GetDisplayName(option);
            var optName = DiscountLabel.Format(optTemp);

            optName.ScrollToView();
            optName.Click();
            return this;
        }

        public AmazonProductPage SelectProdToAddCart(int positionOfProd)
        {
            var prodTemp = Product.Format(positionOfProd);
            prodTemp.Click();

            return new AmazonProductPage();
        }


        public AmazonTodayDeals WaitForPageFiltered()
        {
            FilterBy.WaitForVisible();
            ClearFilter.WaitForVisible();
            return this;
        }

        public Boolean CheckDealPageFiltered()
        {
            if (FilterBy.IsDisplayed() & ClearFilter.IsDisplayed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public String GetProductDeal(int positionOfProd)
        {
            var prodDeal = ProductDeal.Format(positionOfProd);
            return prodDeal.GetText();
        }

        public String GetProductName(int positionOfProd)
        {
            var prodName = ProductName.Format(positionOfProd);
            return prodName.GetAttribute("aria-label");
        }

        public AmazonTodayDeals WaitForDealPageLoad()
        {
            PageHeader.WaitForVisible();
            return this;
        }



    }


}


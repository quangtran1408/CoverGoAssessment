using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumCSharp.Core.ElementWrapper;
using SeleniumTests.Utilities;
using SeleniumTests.EnumData.Amazon;
using System;
using System.Data;


namespace SeleniumTests.PageObject.Amazon
{
    public class AmazonSearchPage : AmazonProductPage
    {
        private ComboBox SortCbb => new ComboBox("//span[.='Sort by:']");
        private ComboBox SortItem => new ComboBox("//option[.='{0}']");
        private Link ProductName => new Link("//span[.='{0}']");
        private Label SearchResult => new Label("//div[@class='a-section a-spacing-small a-spacing-top-small']/span[contains(.,'result') and contains(.,'for')]");
        private Label SearchProductName => new Label("//div[@class='a-section a-spacing-small a-spacing-top-small']/span[@class='a-color-state a-text-bold']");
        private Label SearchSelectedSort => new Label("//span[@data-action='a-dropdown-button']/span[2]");

        public AmazonSearchPage SelectSortItem(SortItemInSearchPage sortItem)
        {
            string item = Utils.GetDisplayName(sortItem);
            var selectItem = SortItem.Format(item);
            SortCbb.WaitForVisible();
            SortCbb.Click();
            selectItem.Click();

            return this;
        }

        public Boolean CheckSortItemSelected(SortItemInSearchPage sortItem)
        {
            string item = Utils.GetDisplayName(sortItem);
            string sortItemTemp = SearchSelectedSort.GetText();

            if (sortItemTemp == item)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }


        public AmazonProductPage SelectProduct(string productName)
        {
            var prodPos = ProductName.Format(productName);
            prodPos.ScrollToView();
            prodPos.Click();

            return new AmazonProductPage();
        }

        public Boolean CheckSearchProductName(string searchProduct) 
        {
            SearchResult.WaitForVisible(); 
            string searchProdTemp = SearchProductName.GetText();
            if (searchProdTemp.Contains(searchProduct))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }


}


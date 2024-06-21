using SeleniumCSharp.Core.ElementWrapper;
using System;
using SeleniumTests.Utilities;
using SeleniumTests.EnumData.Amazon;
using System.Threading;


namespace SeleniumTests.PageObject.Amazon
{
    public class AmazonMainPage
    {
        protected Link HomeLink => new Link("//a[@id='nav-logo-sprites']");
        protected Link MainMnuItem => new Link("//a[@href='{0}']");
        protected Label SubMenuHeader => new Label("//h1[contains(.,'{0}')]");
        protected TextBox SearchTbx => new TextBox("//input[@aria-label='Search Amazon.com.au']");
        protected Button SearchBtn => new Button("//span[@aria-label='Go']");
        protected Link CartLink => new Link("//a[@id='nav-cart']");

        public T ClickMenuItem<T>(MainMenuItems menuName)
        {
            string mnuNameTemp = Utils.GetDisplayName(menuName);
            var itemName = MainMnuItem.Format(mnuNameTemp);

            itemName.Click();

            Thread.Sleep(5000);

            var page = typeof(T);
            return (T)Activator.CreateInstance(page);
        }


        public AmazonMainPage ReturnToMainPage()
        {
            HomeLink.Click();
            return this;
        }

        public AmazonSearchPage SearchProduct(string searchName)
        {
            SearchTbx.Click();
            SearchTbx.SendKeys(searchName);
            SearchBtn.Click();

            return new AmazonSearchPage();
        }

        public AmazonCartPage GoToCart()
        {
            CartLink.Click();

            return new AmazonCartPage();
        }


    }


}


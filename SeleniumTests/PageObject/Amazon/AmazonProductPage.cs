using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumCSharp.Core.ElementWrapper;
using System;
using SeleniumTests.DataObject;
using System.Threading;



namespace SeleniumTests.PageObject.Amazon
{
    public class AmazonProductPage
    {
        protected Button AddToCartBtn => new Button("//input[@value='Add to Cart']");
        protected Label AddedToCart => new Label("//h1[contains(.,'Added to Cart')]");
        protected ComboBox QuantityCbb => new ComboBox("//span[.='Quantity:']");
        protected ComboBox QuantityNumber => new ComboBox("//a[@id='quantity_{0}']");
        protected Label ViewedProductName => new Label("//div[@id='titleSection']//span");
        protected Label ViewedProductDeal => new Label("//span[contains(@class,'savingsPercentage')]");
        

        public AmazonProductPage SelectProductQuantity(int amountProduct)
        {
            Thread.Sleep(5000);
            QuantityCbb.Click();
            int quantity = amountProduct - 1;
            var amountProdTemp = QuantityNumber.Format(quantity);
            amountProdTemp.Click();

            return this;
        }

        public String GetViewedProductName()
        {
            return ViewedProductName.GetText();
        }

        public String GetViewedProductDeal()
        {
            string strTemp = ViewedProductDeal.GetText();
            if (strTemp.Contains("-"))
            {
                string str1 = strTemp.Replace("-", "");
                string str2 = str1 + " off";
                return str2;
            }
            else 
            {
                return ViewedProductDeal.GetText();
            }
            
        }

        public AmazonProductPage AddProductToCart()
        {
            AddToCartBtn.Click();
            AddedToCart.WaitForVisible();

            return this;
        }


    }


}


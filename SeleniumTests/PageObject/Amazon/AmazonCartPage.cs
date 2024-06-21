using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumCSharp.Core.ElementWrapper;
using SeleniumTests.Utilities;
using SeleniumTests.EnumData.Amazon;
using ReportPortal.Client.Filtering;
using System.Threading;
using System;


namespace SeleniumTests.PageObject.Amazon
{
    public class AmazonCartPage
    {
        protected Label CartHeader => new Label("//h1[contains(.,'Shopping Cart')]");
        private ComboBox CartPageQuantityCbb => new ComboBox("//div[@data-item-index='{0}']//span[@data-a-class='quantity']");
        private Link CartPageQuantityNumber => new Link("//div[@aria-hidden='false']//a[@id='quantity_{0}']");
        private Link DeleteLink => new Link("//input[@aria-label='Delete {0}']");
        private Link SaveLaterLink => new Link("//input[@aria-label='Save for later {0}']");
        private Label SavedProductName => new Label("//div[@id='sc-saved-cart-items']//div[@class='sc-list-item-content']//span[@class='a-truncate-full']");
        private Label SaveForLaterHeader => new Label("//h2/div[contains(.,'Saved for later')]");
        private Label NoItemSaveForLaterHeader => new Label("//h2/div[contains(.,'No items saved for later')]");
        private Label ProductPrice => new Label("//div[@data-item-index='{0}']//span[contains(@class,'sc-product-price')]");
        private Label ProductQuantity => new Label("//div[@data-item-index='{0}']//select[@name='quantity']//option[@selected]");
        private Button ProceedToCheckoutBtn => new Button("//input[@value='Proceed to checkout']");
        private Button MoveToCartBtn => new Button("//div[@class='a-row sc-action-links']//input[contains(@aria-label,'{0}') and @value='Move to cart']");
        private Label TotalPrice => new Label("//span[@id='sc-subtotal-amount-buybox']/span");
        private Label TotalQuantity => new Label("//span[@id='sc-subtotal-label-buybox']");
        private Label TotalProductQuantityInCart => new Label("//div[contains(@class,'sc-subtotal-activecart')]/span[contains(@class,'sc-number-of-items')]");
        private Label TotalProductPriceInCart => new Label("//span[@id='sc-subtotal-amount-activecart']/span");
        private Label CartProductDeal => new Label("//div[@class='sc-deals-badge-label']/span");
        private Label CartProductName => new Label("//span[@class='a-truncate-full a-offscreen']/following-sibling::span");
        private Label MovedToCartProductName => new Label("//span[contains(@class,'sc-product-title')]//span[@class='a-truncate-full']");
        private Label CartEmptyHeader => new Label("//h1[@class='a-spacing-mini a-spacing-top-base']");



        public AmazonCartPage WaitForPageLoad()
        {
            CartHeader.WaitForVisible();
            return this;
        }

        public String GetAddedProductDeal()
        {
            string prodDeal = CartProductDeal.GetText();
            return prodDeal;
        }

        public String GetAddedProductName()
        {
            string prodName = CartProductName.GetText();
            return prodName;
        }

        public AmazonCartPage SelectProductQuantityNumber(int productPosition, int amountProduct)
        {
            var prodPosition = CartPageQuantityCbb.Format(productPosition);
            prodPosition.Click();
            var amountProdTemp = CartPageQuantityNumber.Format(amountProduct);
            amountProdTemp.Click();
            Thread.Sleep(5000);

            return this;
        }

        public AmazonCartPage DeleteProduct(string productName)
        {
            var deleteProdName = DeleteLink.Format(productName);
            deleteProdName.Click();

            return this;
        }

        public AmazonCartPage SaveProductForLater(string productName)
        {
            var saveProdName = SaveLaterLink.Format(productName);
            saveProdName.Click();

            return this;
        }

        public AmazonCartPage MoveSavedProductToCart(string productName)
        {
            var moveProdName = MoveToCartBtn.Format(productName);
            moveProdName.ScrollToView();
            Thread.Sleep(2000);
            moveProdName.Click();

            return this;
        }


        public Boolean CheckProductIsSaved(string productName)
        {
            SaveForLaterHeader.WaitForVisible();
            if (SaveForLaterHeader.IsDisplayed() & productName == CartProductName.GetText())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean CheckProductMovedToCart(string productName)
        {
            SaveForLaterHeader.WaitForInvisible();
            CartEmptyHeader.WaitForInvisible();
            if (NoItemSaveForLaterHeader.IsDisplayed() & productName == MovedToCartProductName.GetText())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String GetProductQuantity(int productPosition)
        {
            var getProdQuantity = ProductQuantity.Format(productPosition);
            Thread.Sleep(5000);
            return getProdQuantity.GetText();
        }

        public String GetProductPrice(int productPosition)
        {
            var getProdPrice = ProductPrice.Format(productPosition);

            return getProdPrice.GetText();
        }

        public String GetTotalPrice()
        {
            return TotalPrice.GetText();
        }

        public String GetTotalQuantity()
        {
            return TotalQuantity.GetText();
        }

        public String GetTotalQuantityInCart()
        {
            return TotalQuantity.GetText();
        }

        public String GetTotalPriceInCart()
        {
            return TotalPrice.GetText();
        }

        public Boolean CheckCartIsEmpty()
        {
            CartEmptyHeader.WaitForVisible();
            if (CartEmptyHeader.IsDisplayed())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void ProceedToCheckout()
        {
            ProceedToCheckoutBtn.Click();
        }


    }

}


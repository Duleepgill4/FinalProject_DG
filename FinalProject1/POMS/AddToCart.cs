using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalProject1.POMS
{
    public class AddToCart
    {
        IWebDriver driver;
        public AddToCart(IWebDriver driver)
        {
            this.driver = driver;
        }
             
        public IWebElement ShopTab => driver.FindElement(By.CssSelector("#menu-item-43 > a"));
        //Assert.That(driver.FindElement(By.CssSelector("#menu-item-43 > a")).Displayed);

            //add hoddie with logo to cart 
        public IWebElement Hoodie => driver.FindElement(By.PartialLinkText("Hoodie with Logo"));
        public IWebElement AddItem => driver.FindElement(By.Name("add-to-cart"));
        public IWebElement ViewCart => driver.FindElement(By.ClassName("cart-contents"));

        public void AddHoodie()
        {
            //adding hoodie to basket through nav
            ShopTab.Click();
            Hoodie.Click();
            AddItem.Click();
            ViewCart.Click();
                       
        }
       
    }
}

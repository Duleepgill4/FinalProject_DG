using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalProject1.POMS
{
    public class Shop
    {
        IWebDriver driver;
        public Shop(IWebDriver driver)
        {
            this.driver = driver;
        }
             
        public IWebElement FindShopTab => driver.FindElement(By.CssSelector("#menu-item-43 > a"));
        //Assert.That(driver.FindElement(By.CssSelector("#menu-item-43 > a")).Displayed);

            //add hoddie with logo to cart 
        public IWebElement FindHoodie => driver.FindElement(By.PartialLinkText("Hoodie with Logo"));
        public IWebElement FindAddItem => driver.FindElement(By.CssSelector("button[name='add-to-cart']"));
        public IWebElement FindViewCart => driver.FindElement(By.CssSelector("ul#site-header-cart  a[title='View your shopping cart']"));

        public void AddHoodie()
        {
            //adding hoodie to basket through nav
            FindShopTab.Click();
            FindHoodie.Click();
            FindAddItem.Click();
            FindViewCart.Click();
                       
        }
       
    }
}

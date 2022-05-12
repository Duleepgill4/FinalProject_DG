using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FinalProject1.POMS
{
    public class Checkout
    {
        IWebDriver driver;
        public Checkout(IWebDriver driver)
        {
            this.driver = driver;  
        }

       // public IWebElement btncheckout => driver.FindElement(By.Id("menu-item-45"));
        public IWebElement BtnCheckout => driver.FindElement(By.LinkText("Proceed to checkout"));
        
        public IWebElement FirstnameFind => driver.FindElement(By.Id("billing_first_name"));
        public IWebElement LastnameFind => driver.FindElement(By.Id("billing_last_name"));
        public IWebElement AddressL1Find => driver.FindElement(By.Id("billing_address_1"));
        public IWebElement AddressL2Find => driver.FindElement(By.Id("billing_address_2"));
        public IWebElement CityFind => driver.FindElement(By.Id("billing_city"));
        public IWebElement PostcodeFind => driver.FindElement(By.Id("billing_postcode"));
        public IWebElement PhoneFind => driver.FindElement(By.Id("billing_phone"));
        public IWebElement PlaceOrder => driver.FindElement(By.Id("place_order"));
        public void CheckoutBtn()
        {
            BtnCheckout.Click();
        }

        public void BillingDetails(TestData data)
        {
            FirstnameFind.Clear();
            FirstnameFind.SendKeys(data.Firstname);
            LastnameFind.Clear();
            LastnameFind.SendKeys(data.Lastname);
            AddressL1Find.Clear();
            AddressL1Find.SendKeys(data.AddressL1);
            AddressL2Find.Clear();
            AddressL2Find.SendKeys(data.AddressL2);
            CityFind.Clear();
            CityFind.SendKeys(data.City);
            PostcodeFind.Clear();
            PostcodeFind.SendKeys(data.Postcode);
            PhoneFind.Clear();
            PhoneFind.SendKeys(data.PhoneNo);
        }
        public void Placed()
        {
            var ScrollToCheckout = new Actions(driver);
            ScrollToCheckout.MoveToElement(PlaceOrder);
            ScrollToCheckout.Perform();
            Thread.Sleep(2000);
            PlaceOrder.Click();
        }
    }
}

            
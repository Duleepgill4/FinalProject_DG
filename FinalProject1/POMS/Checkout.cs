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
        public IWebElement FindBtnCheckout => driver.FindElement(By.LinkText("Proceed to checkout"));
        
        public IWebElement FindFirstname => driver.FindElement(By.Id("billing_first_name"));
        public IWebElement FindLastname => driver.FindElement(By.Id("billing_last_name"));
        public IWebElement FindAddressL1 => driver.FindElement(By.Id("billing_address_1"));
        public IWebElement FindAddressL2 => driver.FindElement(By.Id("billing_address_2"));
        public IWebElement FindCity => driver.FindElement(By.Id("billing_city"));
        public IWebElement FindPostcode => driver.FindElement(By.Id("billing_postcode"));
        public IWebElement FindPhone => driver.FindElement(By.Id("billing_phone"));
        public IWebElement FindPlaceOrder => driver.FindElement(By.Id("place_order"));
        public void CheckoutBtn()
        {
            FindBtnCheckout.Click();
        }

        public void BillingDetails(TestData data)
        {
            //inputting inline table table data into fields
            FindFirstname.Clear();
            FindFirstname.SendKeys(data.Firstname);
            FindLastname.Clear();
            FindLastname.SendKeys(data.Lastname);
            FindAddressL1.Clear();
            FindAddressL1.SendKeys(data.AddressL1);
            FindAddressL2.Clear();
            FindAddressL2.SendKeys(data.AddressL2);
            FindCity.Clear();
            FindCity.SendKeys(data.City);
            FindPostcode.Clear();
            FindPostcode.SendKeys(data.Postcode);
            FindPhone.Clear();
            FindPhone.SendKeys(data.PhoneNo);

        }
        public void Placed()
        {
            //scrolling down the page to an element to make it clickable
            var ScrollToCheckout = new Actions(driver);
            ScrollToCheckout.MoveToElement(FindPlaceOrder);
            ScrollToCheckout.Perform();
            Thread.Sleep(2000);
            FindPlaceOrder.Click();
        }
    }
}

            
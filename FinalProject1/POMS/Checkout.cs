using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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

        public Checkout Billingfn(string firstname)
        {
            FirstnameFind.Clear();
            FirstnameFind.SendKeys(firstname);
            return this;
        }

        public Checkout Billingln(string lastname)
        {
            LastnameFind.Clear();
            LastnameFind.SendKeys(lastname);
            return this;
        }
        public Checkout Billingal1(string addressL1)
        {
            AddressL1Find.Clear();
            AddressL1Find.SendKeys(addressL1);
            return this;
        }
        public Checkout Billingal2(string addressL2)
        {
            AddressL2Find.Clear();
            AddressL2Find.SendKeys(addressL2);
            return this;
        }
        public Checkout Billingcity(string city)
        {
            CityFind.Clear();
            CityFind.SendKeys(city);
            return this;
        }
        public Checkout Billingpc(string postcode)
        {
            PostcodeFind.Clear();
            PostcodeFind.SendKeys(postcode);
            return this;
        }
        public Checkout Billingphone(string phone)
        {
            PhoneFind.Clear();
            PhoneFind.SendKeys(phone);
            return this;
        }
        public void placed()
        {
            
            PlaceOrder.Click();
        }
    }
}

            
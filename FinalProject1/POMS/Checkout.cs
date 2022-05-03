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
        public IWebElement btncheckout => driver.FindElement(By.LinkText("Proceed to checkout"));
        
        public IWebElement firstnamefind => driver.FindElement(By.Id("billing_first_name"));
        public IWebElement lastnamefind => driver.FindElement(By.Id("billing_last_name"));
        public IWebElement addressL1find => driver.FindElement(By.Id("billing_address_1"));
        public IWebElement addressL2find => driver.FindElement(By.Id("billing_address_2"));
        public IWebElement cityfind => driver.FindElement(By.Id("billing_city"));
        public IWebElement postcodefind => driver.FindElement(By.Id("billing_postcode"));
        public IWebElement phonefind => driver.FindElement(By.Id("billing_phone"));
        public IWebElement placeorder => driver.FindElement(By.Id("place_order"));
        public void checkout()
        {
            btncheckout.Click();
        }

        public Checkout Billingfn(string firstname)
        {
            firstnamefind.Clear();
            firstnamefind.SendKeys(firstname);
            return this;
        }

        public Checkout Billingln(string lastname)
        {
            lastnamefind.Clear();
            lastnamefind.SendKeys(lastname);
            return this;
        }
        public Checkout Billingal1(string addressL1)
        {
            addressL1find.Clear();
            addressL1find.SendKeys(addressL1);
            return this;
        }
        public Checkout Billingal2(string addressL2)
        {
            addressL2find.Clear();
            addressL2find.SendKeys(addressL2);
            return this;
        }
        public Checkout Billingcity(string city)
        {
            cityfind.Clear();
            cityfind.SendKeys(city);
            return this;
        }
        public Checkout Billingpc(string postcode)
        {
            postcodefind.Clear();
            postcodefind.SendKeys(postcode);
            return this;
        }
        public Checkout Billingphone(string phone)
        {
            phonefind.Clear();
            phonefind.SendKeys(phone);
            return this;
        }
        public void placed()
        {
            
            placeorder.Click();
        }
    }
}

            
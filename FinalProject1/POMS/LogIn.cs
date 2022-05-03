using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalProject1.POMS
{
    public class LogInPOMS
    {
        IWebDriver driver;
           public LogInPOMS(IWebDriver driver)
            {
                this.driver = driver;    
            }

        public IWebElement btndismiss => driver.FindElement(By.ClassName("woocommerce-store-notice__dismiss-link"));
        public IWebElement  userName => driver.FindElement(By.Id("username"));
        public IWebElement passWord => driver.FindElement(By.Id("password"));


        public void dismiss()
        {
            btndismiss.Click();

        }
        public LogInPOMS Loginuser (string username)
        {
            userName.SendKeys(username);
            
            return this;
        }
        public LogInPOMS Loginpass(string password)
        {
           
            passWord.SendKeys(password);
            return this;
        }
    }
}

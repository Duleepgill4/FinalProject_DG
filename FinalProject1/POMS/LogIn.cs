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

        public IWebElement DismissButton=> driver.FindElement(By.LinkText("Dismiss"));
        public IWebElement  UserName => driver.FindElement(By.CssSelector("input#username"));
        public IWebElement PassWord => driver.FindElement(By.CssSelector("input#password"));
        public IWebElement LogInButton => driver.FindElement(By.CssSelector("button[name='login']"));


        public void Dismiss()
        {
            DismissButton.Click();

        }
        public LogInPOMS Loginuser (string username)
        {
            UserName.SendKeys(username);
            
            return this;
        }
        public LogInPOMS Loginpass(string password)
        {
           
            PassWord.SendKeys(password);
            return this;
        }
        public void LogInBtn()
        {
            LogInButton.Click();
        }
    }
}

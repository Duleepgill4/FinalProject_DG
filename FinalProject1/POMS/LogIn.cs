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

        public IWebElement FindDismissButton => driver.FindElement(By.LinkText("Dismiss"));
        public IWebElement FindUserName => driver.FindElement(By.CssSelector("input#username"));
        public IWebElement FindPassWord => driver.FindElement(By.CssSelector("input#password"));
        public IWebElement FindLogInButton => driver.FindElement(By.CssSelector("button[name='login']"));


        public void Dismiss()
        {
            FindDismissButton.Click();

        }
        public LogInPOMS Loginuser (string username)
        {
            FindUserName.SendKeys(username);
            
            return this;
        }
        public LogInPOMS Loginpass(string password)
        {

            FindPassWord.SendKeys(password);
            return this;
        }
        public void LogInBtn()
        {
            FindLogInButton.Click();
        }
    }
}

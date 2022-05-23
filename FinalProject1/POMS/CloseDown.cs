using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace FinalProject1.POMS
{
    public class CloseDown
    {
        IWebDriver driver;
        public CloseDown(IWebDriver driver)
        {
            this.driver = driver;
        }

        //navigate to account and logout
        public IWebElement FindAccount => driver.FindElement(By.LinkText("My account"));
        public IWebElement FindLogOut => driver.FindElement(By.LinkText("Log out"));

        public void LogOut()
        {
            Thread.Sleep(2000);
            //navigate to account and logout
            FindAccount.Click();
            FindLogOut.Click();
            //close down window
            driver.Quit();

        }
    }
}

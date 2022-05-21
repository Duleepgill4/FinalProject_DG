using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace FinalProject1.POMS
{
    public class AfterScenario
    {
        IWebDriver driver;
        public AfterScenario(IWebDriver driver)
        {
            this.driver = driver;
        }

        //navigate to account and logout
        public IWebElement FindAccount => driver.FindElement(By.CssSelector("menu-item-46"));
        public IWebElement FindLogOut => driver.FindElement(By.PartialLinkText("Log out"));

        public void CloseDown()
        {
            //navigate to account and logout
            FindAccount.Click();
            FindLogOut.Click();

            //close down window
            driver.Quit();


        }
    }
}

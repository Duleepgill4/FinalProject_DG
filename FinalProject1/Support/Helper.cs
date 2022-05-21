using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalProject1.Support
{
    public class Helper
    {
        IWebDriver driver;
        public Helper(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void WaitForUrl(string ReceivedUrl)
        {
            //takes time to load order confirmation
            WebDriverWait Wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            Wait2.Until(drv => drv.Url.Contains(ReceivedUrl));
        }

    }
}
    
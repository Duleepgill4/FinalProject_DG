using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalProject1.POMS
{
    public class OrderDetails
    {
        IWebDriver driver;
        public OrderDetails(IWebDriver driver)
        {
            this.driver = driver;
        }

        //order  number captures after order placed
        //public IWebElement MyOrderNum => driver.FindElement(By.CssSelector(".order > strong"));
        public IWebElement account => driver.FindElement(By.Id("menu-item-46"));
        public IWebElement myOrders => driver.FindElement(By.LinkText("Orders"));


        public void vieworders()
        {
            /*MyOrderNum.Displayed();*/
            account.Click();
            myOrders.Click();
            
        }
      

    }
}

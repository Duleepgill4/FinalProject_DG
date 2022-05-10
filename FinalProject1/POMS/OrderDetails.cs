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
        public IWebElement AccountNav => driver.FindElement(By.LinkText("My account"));
        public IWebElement MyOrders => driver.FindElement(By.LinkText("Orders"));


        public void ViewOrders()
        {
            /*MyOrderNum.Displayed();*/
            AccountNav.Click();
            MyOrders.Click();
            
        }
      

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalProject1.POMS
{
    public class Orders
    {
        IWebDriver driver;
        public Orders(IWebDriver driver)
        {
            this.driver = driver;
        }

        //order  number captures after order placed
        //public IWebElement MyOrderNum => driver.FindElement(By.CssSelector(".order > strong"));
        public IWebElement AccountNav => driver.FindElement(By.LinkText("My account"));
        public IWebElement MyOrders => driver.FindElement(By.LinkText("Orders"));
        //capture the whole orders tbl
        public IWebElement OrdersTable => driver.FindElement(By.ClassName("account-orders-table"));
        public IWebElement FindMyOrder => driver.FindElement(By.CssSelector(".order > strong"));

        public void ViewOrders()
        {
            /*MyOrderNum.Displayed();*/
            AccountNav.Click();
            MyOrders.Click();
        }

        public string MyOrder()
        {
            string MyOrder = '#' + driver.FindElement(By.CssSelector(".order > strong")).Text;
            return MyOrder;
        }
    }
}

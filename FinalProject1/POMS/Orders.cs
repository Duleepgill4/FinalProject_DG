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
        public IWebElement FindAccountNav => driver.FindElement(By.LinkText("My account"));
        public IWebElement FindMyOrders => driver.FindElement(By.LinkText("Orders"));
        //capture the whole orders tbl
        public IWebElement FindOrdersTable => driver.FindElement(By.CssSelector(".woocommerce-MyAccount-content"));
        public IWebElement FindMyOrder => driver.FindElement(By.CssSelector(".order > strong"));

        public void ViewOrders()
        {
            /*MyOrderNum.Displayed();*/
            FindAccountNav.Click();
            FindMyOrders.Click();

        }

        public string MyOrder()
        {
            return FindMyOrder.Text;
        }
        public string AllOrders()
        {
            return FindOrdersTable.Text;
        }
    }
}

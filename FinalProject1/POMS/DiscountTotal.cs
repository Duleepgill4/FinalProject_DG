using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalProject1.POMS
{
    public class DiscountTotal
    {
        IWebDriver driver;
        public DiscountTotal(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement couponE => driver.FindElement(By.Name("coupon_code"));
        public IWebElement couponClick => driver.FindElement(By.Name("apply_coupon"));


        public DiscountTotal AddCoupon (string edgewords)
        {
            couponE.SendKeys(edgewords);
            return this;
        }
        public void ApplyCoupon()
        {
            
            couponClick.Click();
            
        }







    }
}

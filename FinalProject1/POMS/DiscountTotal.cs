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
        public IWebElement CouponField => driver.FindElement(By.CssSelector("input#coupon_code"));
        public IWebElement CouponClick => driver.FindElement(By.CssSelector("button[name='apply_coupon']"));


        public DiscountTotal AddCoupon (string edgewords)
        {
            CouponField.SendKeys(edgewords);
            return this;
        }
        public void ApplyCoupon()
        {
            
            CouponClick.Click();
            
        }







    }
}

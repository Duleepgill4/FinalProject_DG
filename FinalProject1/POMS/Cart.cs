using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalProject1.POMS
{
    public class Cart
    {
        IWebDriver driver;
        public Cart(IWebDriver driver)
        {
            this.driver = driver;
        }
        //input field for coupom
        public IWebElement CouponField => driver.FindElement(By.CssSelector("input#coupon_code"));
        //apply coupon button
        public IWebElement CouponClick => driver.FindElement(By.CssSelector("button[name='apply_coupon']"));
        //get discount amount
        public IWebElement GetDiscount => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
        //subtotal after discount applied
        public IWebElement GetSubtotal => driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount"));
        //Total price 'to pay'
        public IWebElement GetTotal => driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount"));
        //shipping
        public IWebElement GetShipping => driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount"));

        public Cart AddCoupon (string edgewords)
        {
            CouponField.SendKeys(edgewords);
            CouponClick.Click();
            return this;
        }


        //moved from decimal.parse to Converto as it can convert more types not just string //

        //uses GetDiscount to be converted to decimal while trimming the start £ sign and returns it
        public Decimal Discount()
        {
            return Convert.ToDecimal(GetDiscount.Text.TrimStart('£'));
        }
        //uses Subtotal to be converted to decimal while trimming the start £ sign and returns it
        public Decimal Subtotal()
        {
            return Convert.ToDecimal(GetSubtotal.Text.TrimStart('£'));
        }
        //uses total to be converted to decimal while trimming the start £ sign and returns it
        public Decimal Total()
        {
            return Convert.ToDecimal(GetTotal.Text.TrimStart('£'));
        }

        public Decimal Shipping()
        {
            return Convert.ToDecimal(GetShipping.Text.TrimStart('£'));
            
        }


    }
}

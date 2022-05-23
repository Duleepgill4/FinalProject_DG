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
        public IWebElement FindCouponField => driver.FindElement(By.CssSelector("input#coupon_code"));
        //apply coupon button
        public IWebElement FindCouponClick => driver.FindElement(By.CssSelector("button[name='apply_coupon']"));
        //get discount amount
        public IWebElement FindDiscount => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
        //subtotal after discount applied
        public IWebElement FindSubtotal => driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount"));
        //Total price 'to pay'
        public IWebElement FindTotal => driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount"));
        //shipping
        public IWebElement FindShipping => driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount"));
        //empty cart red button
        public IWebElement FindEmptyCart => driver.FindElement(By.LinkText("×"));
        public Cart AddCoupon (string edgewords)
        {
            //use parameter value for coupon
            FindCouponField.SendKeys(edgewords);
            FindCouponClick.Click();
            return this;
        }


        //uses FindDiscount to be converted to decimal while trimming the start £ sign and returns it
        public Decimal GetTotal()
        {
            return Convert.ToDecimal(FindTotal.Text.TrimStart('£'));
        }
        public Decimal CheckTotal()
        {
            //capturing string elements and converting to decimal and removing '£' sign at the start 
            Decimal Discount= Convert.ToDecimal(FindDiscount.Text.TrimStart('£'));
            Decimal Subtotal= Convert.ToDecimal(FindSubtotal.Text.TrimStart('£'));
            Decimal Shipping= Convert.ToDecimal(FindShipping.Text.TrimStart('£'));
            Decimal CorrectTotal = (Subtotal- Discount) + Shipping;
            return CorrectTotal;

        }
       
        public Decimal CheckCoupon()
        {
            Decimal Discount = (Convert.ToDecimal(FindDiscount.Text.TrimStart('£')) )* 100;
            Decimal Subtotal = Convert.ToDecimal(FindSubtotal.Text.TrimStart('£'));
            //calculate discount actually applied
            decimal AppliedDiscount = (Discount / Subtotal);//=10
            return AppliedDiscount;
        }

        public void Empty()
        {
            //empty the cart- ready for another test
            FindEmptyCart.Click();
        }
    }
}

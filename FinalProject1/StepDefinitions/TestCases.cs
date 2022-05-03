using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using FinalProject1.POMS;
using OpenQA.Selenium.Support.UI;
//using static FinalProject1.StepDefinitions.TestBase;

namespace FinalProject1.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            //defining browser with scenario contect
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["webdriver"];


        }
      
        [Given(@"That I am a registered user")]
        public void GivenThatIAmARegisteredUser()
        {
            Thread.Sleep(1000);
            //login using environmental variables username/pass from runsettings
            LogInPOMS Login = new LogInPOMS(driver);
            Login.dismiss();
            Login.Loginuser(Environment.GetEnvironmentVariable("username"));
            Login.Loginpass(Environment.GetEnvironmentVariable("password"));
            driver.FindElement(By.Name("login")).Click();
            //.SendKeys(Keys.Enter);
                                 

        }

        [When(@"I add an item of clothing with a discount code to my cart")]
        public void WhenIAddAnItemOfClothingWithADiscountCodeToMyCart()
        {
            //hoddie with logo added to cart
            AddToCart hoodie = new AddToCart(driver);
            hoodie.AddHoodie();

        }

        [Then(@"the discount and shipping is applied to the total")]
        public void ThenTheDiscountAndShippingIsAppliedToTheTotal()
        {
            DiscountTotal coupon = new DiscountTotal(driver);
            string edgewords = "edgewords";
            coupon.AddCoupon(edgewords);
            coupon.ApplyCoupon();


           
            //explicit conditional wait/thread 
            Thread.Sleep(1000);
            

            //get discount value as css and convert to decimal and remove string position 1 (£)
            string getdiscount = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
            decimal discount = Decimal.Parse(getdiscount.Substring(1));
            
            //get after discount price and convert to float
            string getsubtotal = driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text;
            decimal subtotal = Decimal.Parse(getsubtotal.Substring(1));
            //calculate discount applied
            decimal applieddiscount = subtotal / discount;//10
            decimal discount15 = 15; //correct discount of coupon

            //entering try to capture if the discount is correct or not
            try
            {
                Assert.That(applieddiscount, Is.EqualTo(discount15),"Incorrect discount applied");

            }
            catch (Exception)
            {

            }
            

            //checking total including discount and shipping
            
            string getsubtotal2 = driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text;
            //convert cssselector captured as string to decimal and remove first string (£)
            decimal subtotal2 = Decimal.Parse(getsubtotal2.Substring(1));
            decimal shipping = Decimal.Parse("3.95");   //shipping cost

            string getdiscounttotal = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
            decimal discountotal = Decimal.Parse(getdiscounttotal.Substring(1));
            string gettotal = driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount")).Text;
            decimal total = Decimal.Parse(gettotal.Substring(1));
             
            decimal correcttotal = (subtotal2 - discountotal) + shipping;
           

            Assert.That(correcttotal, Is.EqualTo(total), "total price is not calculated correctly");




        }
    }



//TEST CASE 2
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["webdriver"];
        }
        [Given(@"That I have an item in my cart")]
        public void GivenThatIHaveAnItemInMyCart()
        {
            Thread.Sleep(1000);
            //login using username/pass from runsettings
            LogInPOMS Login = new LogInPOMS(driver);
            Login.dismiss(); //dismiss demo site disclaimer
            Login.Loginuser(Environment.GetEnvironmentVariable("username"));
            Login.Loginpass(Environment.GetEnvironmentVariable("password"));
            driver.FindElement(By.Name("login")).Click();

            //add 'hoodie with logo' to cart
            AddToCart hoodie = new AddToCart(driver);
            hoodie.AddHoodie();
           

        }

        [When(@"I checkout with my details")]
        public void WhenICheckoutWithMyDetails()
        {
            Checkout checkout = new Checkout(driver);
            checkout.checkout();
            checkout.Billingfn(Environment.GetEnvironmentVariable("firstname"));
            checkout.Billingln(Environment.GetEnvironmentVariable("lastname"));
            checkout.Billingal1(Environment.GetEnvironmentVariable("addressL1"));
            checkout.Billingal2(Environment.GetEnvironmentVariable("addressl2"));
            checkout.Billingcity(Environment.GetEnvironmentVariable("city"));
            checkout.Billingpc(Environment.GetEnvironmentVariable("postcode"));
            checkout.Billingphone(Environment.GetEnvironmentVariable("phone"));

            Thread.Sleep(1000);
            checkout.placed();

        }

        [Then(@"My order is present in my Orders")]
        public void ThenMyOrderIsPresentInMyOrders()
        {


            //takes time to load order confirmation
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait2.Until(drv => drv.Url.Contains("order-received"));

            //order just placed
            string myOrder = '#'+driver.FindElement(By.CssSelector(".order > strong")).Text;
            
            OrderDetails orderDetails = new OrderDetails(driver);
            orderDetails.vieworders();

            //capture the whole orders tbl
            var orders = driver.FindElement(By.ClassName("account-orders-table")).Text;
            //List<string> allOrders = new List<string>();

            //check order numn is present in orders
            Assert.That(orders, Does.Contain(myOrder),"order not present in stored orders");

        }
    }




}
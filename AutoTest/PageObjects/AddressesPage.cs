using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoTest
{
    public class AddressesPage : BasePage
    {
       //private readonly By buttonProceed = By.XPath("//button[@name='processAddress']");

       public AddressesPage() : base()
        {

        }
        public AddressesPage(ChromeDriver driver) : base(driver)
        {

        }
    }
}

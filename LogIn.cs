using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Casestudy_Assessment
{
    public class LogIn
    {
        private IBrowser browser;
        private IPage page;

        [SetUp]   //environment
        public async Task SetUp()
        {
            //playwright
            using var playwright = await Playwright.CreateAsync();
            //browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
        }

        [Test]   //test execution
        public async Task SuccessfulLogin()
        {
            await page.GotoAsync("https://www.example.com");
            await page.FillAsync("#username", "Admin");
            await page.FillAsync("#Password", "Admin001");
            await page.ClickAsync("#loginButton");
            var logoutButton = await page.WaitForSelectorAsync("#logoutButton");
            Assert.That(logoutButton, Is.Not.Null);
        }

    }
}
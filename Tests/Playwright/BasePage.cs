using System.Threading.Tasks;
using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;

namespace SpecFlow.Playwright
{
    public class BasePage
    {
        public readonly Task<IPage> _page;

        // BrowserDriver resolved automatically
        public BasePage(BrowserDriver browserDriver)
        {
            // Assignes the page instance
            _page = CreatePageAsync(browserDriver.Current);
        }

        private async Task<IPage> CreatePageAsync(Task<IBrowser> browser)
        {
            // Creates a new page instance
            return await (await browser).NewPageAsync();
        }
    }
}
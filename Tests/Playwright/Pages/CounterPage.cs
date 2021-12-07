using System;
using System.Threading.Tasks;
using AngleSharp.Dom;
using SpecFlow.Actions.Playwright;

namespace SpecFlow.Playwright.Pages
{
    public class CounterPage : BasePage
    {
        private Interactions _interactions;

        public CounterPage(BrowserDriver browserDriver) : base(browserDriver)
        {
            _interactions = new Interactions(_page);
        }

        public async Task ClickButton(string selector)
        {
            await _interactions.ClickAsync(selector);
        }

        public async Task GoTo(string url)
        {
            await _interactions.GoToUrl(BaseUrl + url);
        }

        public async Task<string> GetValueOf(string selector)
        {
            return await (await _page).InnerTextAsync(selector);
        }
    }
}
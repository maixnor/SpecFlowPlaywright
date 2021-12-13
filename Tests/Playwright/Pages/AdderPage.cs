using System.Threading.Tasks;
using SpecFlow.Actions.Playwright;

namespace SpecFlow.Playwright.Pages;

public class AdderPage : BasePage
{
    private Interactions _interactions;

    public AdderPage(BrowserDriver browserDriver) : base(browserDriver)
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

    public async Task EnterValue(string selector, string value)
    {
        await _interactions.SendTextAsync(selector, value);
    }

    public async Task<string> GetValueOf(string selector)
    {
        return await (await _page).InnerTextAsync(selector);
    }
}
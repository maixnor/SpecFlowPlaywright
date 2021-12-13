using System;
using System.Threading.Tasks;
using FsCheck;
using FsCheck.Xunit;
using SpecFlow.Playwright.Pages;
using TechTalk.SpecFlow;

namespace SpecFlow.Property;

[Binding]
public class CalculatorProperty
{
    private AdderPage _adderPage;

    public CalculatorProperty(AdderPage adderPage)
    {
        _adderPage = adderPage;
    }

    [Property]
    public void Test(int first, int second)
    {
        Func<int, int, bool> testrun = (first, second) =>
        {
            return Add(first, second).Result == first + second;
        };
        
        Prop.ForAll(testrun).QuickCheck();
    }
    
    public async Task<int> Add(int first, int second)
    {
        await _adderPage.EnterValue("#app > div > main > article > form > p:nth-child(1) > label > input", first.ToString());
        await _adderPage.EnterValue("#app > div > main > article > form > p:nth-child(2) > label > input", second.ToString());
        await _adderPage.ClickButton(".btn");
        var result = await _adderPage.GetValueOf("#result");
        return int.Parse(result);
    }

}
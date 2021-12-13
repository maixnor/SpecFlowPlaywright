using System.Threading.Tasks;
using FluentAssertions;
using SpecFlow.Playwright.Pages;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps;

[Binding]
public class CalculatorPropertyStepDefinitions
{
    private AdderPage _adderPage;

    private int first;
    private int second;

    public CalculatorPropertyStepDefinitions(AdderPage adderPage)
    {
        _adderPage = adderPage;
    }
    
    [Given(@"any first number")]
    public async Task GivenAnyFirstNumber()
    {
        await _adderPage.EnterValue("#app > div > main > article > form > p:nth-child(1) > label > input", first.ToString());
    }

    [Given(@"any second number")]
    public async Task GivenAnySecondNumber()
    {
        await _adderPage.EnterValue("#app > div > main > article > form > p:nth-child(2) > label > input", second.ToString());
    }

    [When(@"the sum button is pressed")]
    public async Task WhenTheSumButtonIsPressed()
    {
        await _adderPage.ClickButton(".btn");
    }

    [Then(@"the pages result should be both numbers added")]
    public async Task ThenThePagesResultShouldBeBothNumbersAdded()
    {
        var result = await _adderPage.GetValueOf("#result");
        int.Parse(result).Should().Be(first + second);
    }

    [Given(@"the adder page")]
    public async Task GivenTheAdderPage()
    {
        await _adderPage.GoTo("/Adder");
    }
}
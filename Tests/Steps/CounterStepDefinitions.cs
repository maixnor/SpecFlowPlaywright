using System;
using System.Threading.Tasks;
using FluentAssertions;
using SpecFlow.Playwright.Pages;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class CounterStepDefinitions
    {

        private readonly CounterPage _counterPage;

        public CounterStepDefinitions(CounterPage counterPage)
        {
            _counterPage = counterPage;
        }

        [Given(@"the counter page")]
        public async Task GivenTheCounterPage()
        {
            await _counterPage.GoTo("https://localhost:5001/counter");
        }

        [When(@"the count is increased")]
        public async Task WhenTheCountIsIncreased()
        {
            await PressCounter();
        }

        [When(@"the count is increased (.*) times")]
        public async Task WhenTheCountIsIncreasedTimes(int increases)
        {
            for (int i = 0; i < increases; i++)
            {
                await PressCounter();
            }
        }

        private async Task PressCounter()
        {
            await _counterPage.ClickButton(".btn");
        }

        [Then(@"the resulting count should be (.*)")]
        public async Task ThenTheResultingCountShouldBe(int resultingCount)
        {
            var currentCount = await GetCurrentCount();
            currentCount.Should().Be(resultingCount);
        }

        private async Task<int> GetCurrentCount()
        {
            var value = await _counterPage.GetValueOf("#counter");
            if (int.TryParse(value.Split(':')[1].Trim(), out var count))
            {
                return count;
            }
            return -1;
        }
    }
}
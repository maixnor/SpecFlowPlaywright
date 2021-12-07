using System.Diagnostics.Metrics;
using Bunit;
using FluentAssertions;
using WebDemo.Pages;
using Xunit;

namespace SpecFlow.bUnit
{
    public class CounterComponent
    {
        [Fact]
        public void CounterShouldIncrementWhenClicked()
        {
            // Arrange: render the Counter.razor component
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();

            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            cut.Find(".btn").Click();

            var counter = cut.Find("#counter");
            counter.InnerHtml.Should().Be("Current count: 1");
            counter.MarkupMatches("<p id=\"counter\">Current count: 1</p>");
        }
    }
}
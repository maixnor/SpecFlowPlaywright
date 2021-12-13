
# Welcome

Here you can find examples for Behaviour Driven Development (BDD) combined with End to End tests.

### Technologies used

* SpecFlow (Behaviour driven development)
* Playwright (Selenium alternative)
* Blazor (PWA)
* bUnit (Blazor testing framework)
* FsCheck (Property based testing)
* (xUnit and FluentAssertions)

### Prerequisites

dotnet sdk version 6

### Known issues

I could not integrate the property based testing into the Behaviour 
Driven Development Paradigm for technical limitations of 
Method declarations. They could be integrated, but it is just 
hacky and not clean. So I opted to split it into 2 tests.

`dotnet test` does not pick up the tests by itself. IDE is necessary.

If you are using Visual Studio you should:

1) really consider to switch to Rider :)
2) install the xunit nuget for Visual Studio.



# Driver Environments

A driver environment is responsible for creating a web driver instance based on some context. That context is up to you. By encapsulating this set up in one class, you can reuse this across multiple Sessions within your test suite.

Here's an example of a driver environment that constructs an Internet Explorer web driver that maximizes the window and will implicitly wait for up to 5 seconds when trying to find web elements.

```csharp
public class LocalEnvironment : IDriverEnvironment
{
  public IWebDriver CreateWebDriver()
  {
    var driver = new InternetExplorer();
    driver.Manage().Window.Maximize();
    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
    return driver;
  }
}

var session = new Session<LocalEnvironment>();
```

## Built-In Environments
The framework includes a set of built-in driver environments that you can leverage immediately within your test fixtures.

* [Chrome](../blob/master/Bumblebee/Setup/DriverEnvironments/Chrome.cs)
* [Firefox](../blob/master/Bumblebee/Setup/DriverEnvironments/Firefox.cs)
* [InternetExplorer](../blob/master/Bumblebee/Setup/DriverEnvironments/InternetExplorer.cs)
* [PhantomJS](../blob/master/Bumblebee/Setup/DriverEnvironments/PhantomJS.cs)

## Custom Environments
You can create your own environments by either implementing the [IDriverElement](../blob/master/Bumblebee/Setup/IDriverEnvironment.cs) interface or inheriting from the base [SimpleDriverEnvironment](../blob/master/Bumblebee/Setup/DriverEnvironments/SimpleDriverEnvironment.cs) class.  

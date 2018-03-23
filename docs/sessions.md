# Sessions

## Constructing Sessions

Before we can use our page/block objects, we need to set up a browser [*Session*](../blob/master/Bumblebee/Setup/Session.cs). To construct one, you will need to provide a driver environment, which is any class that implements the [*IDriverEnvironment*](../blob/master/Bumblebee/Setup/IDriverEnvironment.cs) interface.  You can learn more about driver environments [here](./Driver-Environments).

For the example below, we are using a built-in environment called [*InternetExplorer*](../blob/master/Bumblebee/Setup/DriverEnvironments/InternetExplorer.cs).

```csharp
var environment = new InternetExplorer();
var session = new Session(environment);
```

You can also assemble [*Session*](../blob/master/Bumblebee/Setup/Session.cs) with one line, as long as the [*IDriverEnvironment*](../blob/master/Bumblebee/Setup/IDriverEnvironment.cs) you have chosen to use has a default constructor.

```csharp
var session = new Session<InternetExplorer>();
```

## Session Fixtures

In order to make this reusable in your preferred test framework, you would want to create a base test fixture with this variable as protected.  Any derived classes could then reference this variable.  The example below is for NUnit.

```csharp
[TestFixture]
public abstract class SessionFixture
{
  protected Session Session { get; private set; }

  [SetUp]
  public void SetUp()
  {
    Session = new Session<InternetExplorer>();
  }

  [TearDown]
  public void TearDown()
  {
    Session.End();
  }
}

[TestFixture]
public class LoginPageTests : SessionFixture
{
  [Test]
  public void given_invalid_login_when_logging_in_should_display_error()
  {
    Session
      .NavigateTo<LoginPage>("http://someuri.org/login")
      .VerifyPresence(By.Id("invalidLoginMessage"));
  }
}
```

## Thread-Safe Sessions
An alternative to creating a common base test fixture is to use a built-in, thread-safe method for establishing a [*Session*](../blob/master/Bumblebee/Setup/Session.cs) that can be used across multiple methods within a test fixture or even across multiple fixtures on one thread without having to first construct it.  

An example is below.

```csharp
[TestFixture]
public class LoginPageTests
{
  [Test]
  public void given_invalid_login_when_logging_in_should_display_error()
  {
    Threaded<Session>
      .With<InternetExplorer>()
      .NavigateTo<LoginPage>("http://someuri.org/login")
      .VerifyPresence(By.Id("invalidLoginMessage"));
  } 

  [TearDown]
  public void TearDown()
  {
    Threaded<Session>
      .End();
  }
}
```

You can keep referencing the same [*Session*](../blob/master/Bumblebee/Setup/Session.cs) in each and every method.  And if you are leveraging a test framework that spins off multiple threads running your tests, you can be assured that each [*Session*](../blob/master/Bumblebee/Setup/Session.cs) is in it's own thread and safe from harm.

In some cases, you will want to use a driver environment that does not have a default public constructor.  In those cases, you can pass in an instance to the With() method.

```csharp
[Test]
public void given_invalid_login_when_logging_in_should_display_error()
{
  Threaded<Session>
    .With(new InternetExplorer(TimeSpan.FromSeconds(5)))
    .NavigateTo<LoginPage>("http://someuri.org/login")
    .VerifyPresence(By.Id("invalidLoginMessage"));;
} 
```

## Screen Capture
TODO

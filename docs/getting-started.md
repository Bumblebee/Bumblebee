# Getting Started

To get started with Bumblebee, let's do a simple example of logging in to a website and verifying that we have successfully logged in.

## 1. Install Libraries
In order to run the example, you will need to create a project in Visual Studio that is a class library.  After the project is created, you will need to install the appropriate libraries.  These should include a test library, Bumblebee, and any web drivers.  You could also include any assertions libraries that you prefer.  

For the purpose of this tutorial, we will install [NUnit](https://www.nuget.org/packages/NUnit/2.6.4), [Bumblebee](https://www.nuget.org/packages/Bumblebee.Automation/), and the [Internet Explorer web driver](https://www.nuget.org/packages/Selenium.WebDriver.IEDriver/).  You can do this by running the following commands at the package manager console or by selecting the packages via the *Tools/NuGet Package Manager/Manage NuGet Packages for Solution* dialog.

```
PM> Install-Package NUnit
PM> Install-Package Bumblebee.Automation
PM> Install-Package Selenium.WebDriver.IEDriver
```

## 2. Create Page/Blocks
The next step is to create the page/blocks that you want to use to represent the pages that you will interact with during the test automation.  In this case, we would like to create a LoggedOutPage and LoggedInPage for the http://www.reddit.com site.

#### LoggedOutPage.cs

```csharp
public class LoggedOutPage : WebBlock
{
  public LoggedOutPage(Session session) : base(session)
  {
  }

  public ITextField<LoggedOutPage> Email
  {
    get { return new TextField<LoggedOutPage>(this, By.Name("user")); }
  }

  public ITextField<LoggedOutPage> Password
  {
    get { return new TextField<LoggedOutPage>(this, By.Name("passwd")); }
  }

  public IClickable LoginButton
  {
    get { return new Clickable(this, By.TagName("button")); }
  }
}
```

#### LoggedInPage.cs
```csharp
public class LoggedInPage : WebBlock
{
  public LoggedInPage(Session session) : base(session)
  {
    // Wait until we're logged in, then re-select the body to keep the DOM fresh
    Wait.Until(driver => driver.GetElement(By.CssSelector(".user a")));
    Tag = Session.Driver.GetElement(By.TagName("body"));
  }

  public IClickable<LoggedInPage> Profile
  {
    get { return new Clickable<LoggedInPage>(this, By.CssSelector(".user a")); }
  }

  public IClickable<LoggedOutPage> Logout
  {
    get { return new Clickable<LoggedOutPage>(this, By.LinkText("logout")); }          
  }
}
```

## 3. Scripting the Test
After the page/blocks have been created, you can now reference them within a test.

```csharp
[TestFixture]
public class LoginTests
{
    [Test]
    public void given_valid_credentials_when_logging_in_then_logged_in()
    {
        Threaded<Session>
          .With<InternetExplorer>()
          .NavigateTo<LoggedOutPage>("http://www.reddit.com")
          .Email.EnterText("bumblebeeexample")
          .Password.EnterText("123abc!!")
          .LoginButton.Click<LoggedInPage>()
          .VerifyPresenceOf("the logout link", By.CssSelector(".user a"));
    }

    ///The tear down operation is needed in case there is a failure during the test.  The Session will need to be
    ///cleaned up.
    [TearDown]
    public void TearDown()
    {
        Threaded<Session>
          .End();
    }
}
```

Now that you have completed your first Bumblebee automation, it's time to explore the concepts in more detail.  
Good luck!  

And let us know if you have questions or concerns [here](https://github.com/Bumblebee/Bumblebee/issues).

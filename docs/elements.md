# Elements

An element is a user interface item. Examples include links, buttons, checkboxes, select boxes, etc. Each type of element is represented by an interface. For example IClickable represents both buttons and links (with a single method, "Click").

Each element on a page gets represented by a property. The most important part of the property is the return type. The type returned should be the interface of the element, for example *ISelectBox*. This is how the user (the person writing the automation test case) can interact with the element.

## The Interface

The generic type parameter of the return type is where the scope returns to after the element is interacted with. For elements that generally do not change the page, the generic type is typically the type of the parent block (the block of which the element is a property). Suppose there is a select box on our home page for the user to choose their favorite color. We define the property like this:

```csharp
public ISelectBox<HomePage> FavoriteColorSelectBox { ... }
```

For elements that generally do change the state of the page, the type parameter is the type of the block that is led to. For example, say we have a link to an about page *AboutPage*.

```csharp
public IClickable<AboutPage> AboutLink { ... }
```

Sometimes, however, performing an action could lead to several different places on the site. For example, say we have a "Log In" button. Clicking this button could lead to the profile page *ProfilePage* or stay on the home page with an invalid login message. For elements like this there is no default block where we end up, so we'd like the user to specify where they think it should end up in the context of the automation. To do so, we just leave off the generic type parameter:

```csharp
public IClickable LogInButton { ... }
```

Notice there is no generic type parameter after *IClickable*; we don't know where it will go so we don't specify ahead of time.

If there's a link on a page that leads to the same block 99% of the time, but leads somewhere else in rare cases (for example an error popup or a log in page for privileged links), you should still return an *Clickable* leading to the most common return case. In your test case you can still override the default return type by specifying a generic parameter. In other words, giving your interface a generic type sets a default and allows the automator to leave it off.

## The Implementation

To implement the property, we must return a concrete type. For most cases, each interface's corresponding implementation should suffice (Use *Clickable* for *IClickable*). We diverge from this pattern when a site contains custom UI elements (like jQuery select boxes and such). If the element on the page fits the interface, but is implemented differently, make a custom implementation and use that.

Element implementations take two parameters. The first is the parent block of the element, which it uses for scope. Just pass *this*, as we are calling from the parent block. The second is the selector for the element (a Selenium *By* object). Alternatively, you can pass the *IWebElement* representing the element, which is often useful.

Here are the properties above implemented fully:

```csharp
public ISelectBox<HomePage> FavoriteColorSelectBox
{
    get { return new SelectBox<HomePage>(this, By.Id("favoriteColor")); }
}

public IClickable<AboutPage> AboutLink
{
    get { return new Clickable<AboutPage>(this, By.Id("aboutLink")); }
}

public IClickable LogInButton
{
    get { return new Clickable(this, By.Id("logInButton")); }
}
```

and in the context of our *HomePage* class with some login elements added:

```csharp
public class HomePage : Page
{
    public HomePage(Session session) : base(session)
    {
    }

    public ISelectBox<HomePage> FavoriteColorSelectBox
    {
        get { return new SelectBox<HomePage>(this, By.Id("favoriteColor")); }
    }

    public IClickable<AboutPage> AboutLink
    {
        get { return new Clickable<AboutPage>(this, By.Id("aboutLink")); }
    }

    public IClickable LogInButton
    {
        get { return new Clickable(this, By.Id("logInButton")); }
    }

    public ITextField<HomePage> UsernameField
    {
        get { return new TextField<HomePage>(this, By.Id("usernameField")); }
    }

    public ITextField<HomePage> PasswordField
    {
        get { return new TextField<HomePage>(this, By.Id("passwordField")); }
    }
}
```

## Text Fields

A TextField class is typically is used to represent an input element of text, date, or numeric type or a textarea element.

### AppendText(string text)

This method allows users to add text to the end of any existing text within a text field.

### EnterText(string text)

This method clears any existing text for a text field and then adds the text to the field.

### Press(Key key)

This method allows users to press single keys in a text field including key combinations.  For example,

```csharp
myPage.Press(Key.A);
myPage.Press(Key.Control + Key.C);
myPage.Press(Key.Control + Key.Alt + Key.Delete);
```

## Tables

Tables are meant to be a simple set of abstractions for tables within your HTML.  If your application is using the basic HTML 4.0 tables as shown below:

```html
<table id="myTable">
  <thead>
    <tr>
      <th>First Name</th>
      <th>Last Name</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Todd</td>
      <td>Meinershagen</td>
    </tr>
  </tbody>
  <tfoot>
    <tr>
      <td>Number of People:</td>
      <td>1</td>
    </tr>
  </tfoot>
</table>
```

You can then represent as an ITable with the Table implementation like so:

```csharp
public class TablePage : WebBlock
{
  public ITable MyTable
  {
    get { return new Table(this, By.Id("myTable"));
  }
}

//Using the Page in Test Scripts
NavigateTo<TablePage>("http://urltopage.com")
  .Table
  .VerifyThat(t => t.Headers[0].Should().Be("First Name"))
  .VerifyThat(t => t.Rows.First()["Last Name"].Should().Be("Meinershagen"))
  .VerifyThat(t => t.Footer[1].Should().Be("1");
```

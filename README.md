Bumblebee
=========

Bumblebee is a layer on top of the Selenium browser automation framework. Using Bumblebee and the accompanying design paradigm allows for easy creation of page objects, even for dynamic web pages.

Bumblebee makes browser automation dead simple. Develop page objects quickly by modeling which parts of the page can be interacted with. Then, using Intellisense, we can check what elements/blocks are on the page and easily perform actions on them.

The basic idea behind Bumblebee is to break each page down into blocks and elements. Use the classes provided by bumblebee to model your site into page objects. Consume page objects by writing your automation code. If page objects are well designed, writing the automation code should take no effort.

Blocks
------

A block is an area on a web page. This could be an entire page, or a subset, like a tab menu, or a sidebar. Each block is represented by a class that extends *Block*. Blocks can contain child elements or child blocks. Each child is represented by a property in the parent block's class. Say we have some home page *HomePage*.

```C#
public class HomePage : BaseBlock
{
    public HomePage(Session session) : base(session)
    {
    }
    
    // Properties go here
}
```

BaseBlock here is a base type that is not provided by Bumblebee, but extends Block. It is the base block for this project. See the section on [block scope](#block-scope) for an explanation.

Elements
--------

An element is a user interface item. Examples include links, buttons, checkboxes, select boxes, etc. Each type of element is represented by an interface. For example IClickable represents both buttons and links (with a single method, "Click").

Each element on a page gets represented by a property. The most important part of the property is the return type. The type returned should be the interface of the element, for example *ISelectBox*. This is how the user (the person writing the automation test case) can interact with the element. 

The generic type parameter of the return type is where the scope returns to after the element is interacted with. For elements that generally do not change the page, the generic type is typically the type of the parent block (the block of which the element is a property). Suppose there is a select box on our home page for the user to choose their favorite color. We define the property like this:

```C#
public ISelectBox<HomePage> FavoriteColorSelectBox { ... }
```

For elements that generally do change the state of the page, the type parameter is the type of the block that is led to. For example, say we have a link to an about page *AboutPage*.

```C#
public IClickable<AboutPage> AboutLink { ... }
```

Sometimes, however, performing an action could lead to several different places on the site. For example, say we have a "Log In" button. Clicking this button could lead to the profile page *ProfilePage* or stay on the home page with an invalid login message. Elements like this are deemed "conditional" and have seperate interfaces. We'd model the button like this:

```C#
public IConditionalClickable LogInButton { ... }
```

Notice there is no generic type parameter; we don't know where it will go so we cannot specify ahead of time.

To implement the property, we must return a concrete type. For most cases, each interface's corresponding implementation should suffice (Use *Clickable* for *IClickable*). We diverge from this pattern when a site contains custom UI elements (like jQuery select boxes and such). If the element on the page fits the interface, but is implemented differently, make a custom implementation and use that.

Element implementations take two parameters. The first is the parent block of the element, which it uses for scope. Just pass *this*, as we are calling from the parent block. The second is the selector for the element (a Selenium By object). Alternatively, you can pass the IWebElement representing the element, which is often useful.

Here are the properties above implemented fully:

```C#
public ISelectBox<HomePage> FavoriteColorSelectBox
{
    get { return new SelectBox<HomePage>(this, By.Id("favoriteColor")); }
}

public IClickable<AboutPage> AboutLink
{
    get { return new Clickable<AboutPage>(this, By.Id("aboutLink")); }
}

public IConditionalClickable LogInButton
{
    get { return new ConditionalClickable(this, By.Id("logInButton")); }
}
```

and in the context of our *HomePage* class with some login elements added:

```C#
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

    public IConditionalClickable LogInButton
    {
        get { return new ConditionalClickable(this, By.Id("logInButton")); }
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

Great! Now what does this buy us?

Using Page Objects
------------------

Before we can use our page objects, we need to set up our *Session* object. Think of *Session* as a browser instance. To construct one, we need to pass an IDriverEnvironment. A driver environment is responsible creating a web driver instance based on some context. That context is up to you. Here's an example.

I would like to be able to run automations on my own machine, as well as on some remote grid. I'll create an environment implementation for each of these. *LocalEnvironment* generates a basic web driver for running local browser instances. *GridEnvironment* handles the creation of a remote driver. Now I can run my automations in either environment. Because *Session* takes an environment instead of an instance of *IWebDriver*, it is easy to set up parallelization where multiple sessions are running simultaniously.

Now that our *Session* is set up and instantiated, we can run this automation:

```C#
Session.NavigateTo<HomePage>(url).FavoriteColorSelectBox.Options.Random().Click().AboutLink.Click();
```

or these:

```C#
Session.NavigateTo<HomePage>(url).UsernameField.EnterText("patrick").PasswordField.EnterText("password1234")
.LogInButton.Click<ProfilePage>();
```

```C#
Session.NavigateTo<HomePage>(url).UsernameField.EnterText("invalid").PasswordField.EnterText("invalid")
.LogInButton.Click<HomePage>().VerifyPresence(By.Id("invalidLoginMessage"));
```

The testcases are fairly readable, even if how they work is dubious. Notice that clicking the log in button requires a generic type parameter. In the context of the test case this snippet automates, we now know where it will (or *should*) end up, so we specify here.

The selection of the random option from the first example deserves some discussion.

Using Linq
----------

The *Options* property in the first example above return an *IEnumerable* of options. This allows the automator to decide which option to act on however they like. Using linq we get many methods for free. Here are some examples of valid selections:

```C#
Options.First().Click();
```
Clicks the first option.

```C#
Options.Last().Click();
```
Clicks the last option.

```C#
Options.ElementAt(3).Click();
```
Clicks the fourth option.

```C#
Options.WithText("Green").Single().Click();
```
Clicks the option with text "Green". Throws an exception if there aren't any or if there are more than one.

```C#
Options.WithText("Green").First().Click();
```
Clicks the *first* option with text "Green". Throws an exception if there aren't any, but not if there are multiple.

```C#
Options.Skip(1).Random().Click();
```
Clicks any but the first option at random.

```C#
Options.Reverse().Skip(1).Random().Click();
```
Clicks any but the last option at random.

```C#
Options.Where(opt => opt.Text.EndsWith("e")).First().Click();
```
Clicks the first options whose text ends with "e".

```C#
Options.Unselected().Random().Click();
```
Click a random option excluding the one already selected.

Note that *Random*, *WithText*, and *Unselected* are not part of linq, but come with Bumblebee.

We can use this pattern whenever we have a collection of similar elements. Suppose we have a user search page on our site. The search results come back as a list of user profile links. We can easily model all of these links with a single property:

```C#
public IEnumerable<IClickable<ProfilePage>> ProfileLinks
{
    get
    {
        return GetElements(By.ClassName("profileLink")).Select(link => new Clickable<ProfilePage>(this, link));
    }
}
```

Now in our automations we can type

```C#
ProfileLinks.First().Click();
```

along with all the other selectors.

Block Scope
-----------
Each block is associated with an element in the DOM. All selectors within the block search within the block by searching only within its corresponding DOM element. By default, the scope of a block is that of its parent class. To narrow the scope of the block, set the *Dom* property in the constructor of the block. For example, say the user search mechanism is on several different pages, but is always wrapped in a *div* with class "userSearch". We should create a block to represent it.

```C#
public class UserSearchBox : Block
{
    public UserSearchBox(Session session) : base(session)
    {
        Dom = GetElement(By.ClassName("userSearch"));
    }
    
    public ITextField<UserSearchBox> UsernameField
    {
        get { return new TextField<UserSearchBox>(this, By.Id("userSearchField")); }
    }
    
    public IClickable<UserSearchResultsBox> SearchButton
    {
        get { return new Clickable<UserSearchResultsBox>(this, By.Id("userSearchButton")); }
    }
}
```

In the constructor, the scope is set to only search within the *div* in question. Because each constructor calls its base constructor first, scope narrowing cascades down from the base block. This raises the question, what is the default *Dom* selected from Block? *There actually isn't one*. There should only be one class that directly extends Block, which is to be used as your base block from then on. Lets create one.

```C#
public class BaseBlock : Block
{
    public BaseBlock(Session session) : base(session)
    {
        Dom = Session.FindElement(By.TagName("body"));
    }
}
```

This class will serve as the base for all of our blocks. We set the initial scope to be inside the body of the page here, but you can make it whatever you want. Notice we cannot use *GetElement*; *GetElement* searches within the current scope, which is not yet defined. Now we change our *UserSearchBox* class to extend the right block.

```C#
public class UserSearchBox : BaseBlock
{
    public UserSearchBox(Session session) : base(session)
    {
        Dom = GetElement(By.ClassName("userSearch"));
    }
    
    public ITextField<UserSearchBox> UsernameField
    {
        get { return new TextField<UserSearchBox>(this, By.Id("userSearchField")); }
    }
    
    public IClickable<UserSearchResultsBox> SearchButton
    {
        get { return new Clickable<UserSearchResultsBox>(this, By.Id("userSearchButton")); }
    }
}
```

Suppose there is a user search box on the home page. We can add one like so:

```C#
public class HomePage : Page
{
    public HomePage(Session session) : base(session)
    {
    }
    
    public UserSearchBox UserSearchBox
    {
        get { return new UserSearchBox(session); }
    }
    
    ...
}
```

After we add the ProfileLinks property to a block called *UserSearchResultsBox*, we can do this:

```C#
Session.NavigateTo<HomePage>(url).UserSearchBox.UsernameField.EnterText("Corey Trevor").SearchButton.Click().ProfileLinks.First().Click();
```

Conveniences
------------

*    Call *Pause(int seconds)* on any block or element and execution will pause. Scope will be returned exactly where it was.

*    To continue an automation without continuing one long expression, use *Session.CurrentBlock* and pass the type of the page you're on.

*    Perform verifications from with your automation expression. Scope returns to where it was before the call. There are verifications for the presence and absence of an element, for the text of textual elements, and for the selected status of options. You can create more; they are just extension methods. See the default ones in the *Extensions* class for reference.
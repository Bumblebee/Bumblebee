# Blocks

## Overview

A block is an area on a web page. This could be an entire page, or a subset, like a tab menu, or a sidebar. Each block is represented by a class that extends *Block*. Blocks can contain child elements or child blocks. Each child is represented by a property in the parent block's class. Say we have some home page *HomePage*.

```c#
public class HomePage : Block
{
    public HomePage(Session session) : base(session)
    {
    }

    // Properties go here
}
```

BaseBlock here is a base type that is not provided by Bumblebee, but extends Block. It is the base block for this project. See the section on [block scope](./#block-scope) for an explanation.

## Block Scope

Each block is associated with an HTML tag (an element in the DOM). All selectors within the block search within the block by searching only within its corresponding tag. By default, the scope of a block is that of its parent class. To narrow the scope of the block, set the *Tag* property in the constructor of the block. For example, say the user search mechanism is on several different pages, but is always wrapped in a *div* with class "userSearch". We should create a block to represent it.

```c#
public class UserSearchBox : Block
{
    public UserSearchBox(Session session) : base(session)
    {
        Tag = GetElement(By.ClassName("userSearch"));
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

In the constructor, the scope is set to only search within the *div* in question. Because each constructor calls its base constructor first, scope narrowing cascades down from the base block. This raises the question, what is the default *Tag* selected from Block? *There actually isn't one*. There should only be one class that directly extends Block, which is to be used as your base block from then on. Lets create one.

```c#
public class BaseBlock : Block
{
    public BaseBlock(Session session) : base(session)
    {
        Tag = Session.Driver.GetElement(By.TagName("body"));
    }
}
```

This class will serve as the base for all of our blocks. We set the initial scope to be inside the body of the page here, but you can make it whatever you want. Notice we cannot use *GetElement*; *GetElement* searches within the current scope, which is not yet defined (we are currently defining it). Now we change our *UserSearchBox* class to extend the right block.

```c#
public class UserSearchBox : BaseBlock
{
    public UserSearchBox(Session session) : base(session)
    {
        Tag = GetElement(By.ClassName("userSearch"));
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

The *GetElement* call in the constructor searches within the current scope, which is the body of the page, as specified in the base block. The `By.Id("userSearchField")` selector in the *UsernameField* property will search within the current scope, an element with class "userSearch". Limited selectors to a scope often makes for simpler selectors.

Suppose there is a user search box on the home page. We can add one like so:

```c#
public class HomePage : BaseBlock
{
    public HomePage(Session session) : base(session)
    {
    }

    public UserSearchBox UserSearchBox
    {
        get { return new UserSearchBox(Session); }
    }

    ...
}
```

After we add the ProfileLinks property to a block called *UserSearchResultsBox*, we can do this:

```c#
Session.NavigateTo<HomePage>(url)
    .UserSearchBox
    .UsernameField.EnterText("Corey Trevor")
    .SearchButton.Click()
    .ProfileLinks.First().Click();
```

## Specific Blocks

Child blocks are cool, and so is using linq to play with lists of elements. There's no reason we can't play with lists of blocks! Here's an example where we might do that.

Suppose our webpage has a table. Each row of the table represents some user, and has three things (bear with me):
*    A link to the user's profile
*    A check box indicating whether or not they are active
*    A select box indicating their favorite color

We would like to be able to interact with any of these elements from our automation.

This block is different from any of the other blocks we've discussed thus far. There can be multiple instances on a page, so to distinguish we must pass it the web element we're talking about. For this type of block we use *SpecificBlock*. If I were to ask you for an instance of a block, and you had to ask "which one?", then that block should be modeled by a *SpecificBlock*.

```c#
public class UserTableRow : SpecificBlock
{
    public UserTableRow(Session session, IWebElement tag) : base(session, tag)
    {
    }

    public IClickable<ProfilePage> ProfileLink
    {
        get { return new Clickable<ProfilePage>(this, By.ClassName("profileLink")); }
    }

    public ICheckbox<UserTableRow> ActiveCheckbox
    {
        get { return new Checkbox<UserTableRow>(this, By.ClassName("activeCheckbox")); }
    }

    public ISelectBox<UserTableRow> FavoriteColorSelectBox
    {
        get { return new SelectBox<UserTableRow>(this, By.ClassName("favoriteColorSelect")); }
    }
}
```

Now we can set up the list of blocks.

```c#
public IEnumerable<UserTableRow> UserTableRows
{
    get
    {
        return GetElements(By.CssSelector(".userTable tr"))
            .Select(tr => new UserTableRow(Session, tr));
    }
}
```

Lets say for simplicity that this table is on the home page. Now we can write a test case like this:

```c#
Session.NavigateTo<HomePage>(url)
    .UserTableRows.First()
    .ActiveCheckbox.Check()
    .FavoriteColorSelectBox.Options.Random().Click()
    .ProfileLink.Click();
```

This gives the automation script the power to interact with anything on the page, using very little code.

Because specific blocks require an element to clarify which block you're talking about, specific blocks cannot be the target of elements (you should never write `IClickable<UserTableRow>` because it wouldn't know which row to give you or how). The exception is from inside the specific block itself (inside *UserTableRow* we have `ISelectBox<UserTableRow>`), in which case Bumblebee understands that the only element you could logically be referring to is the parent one (itself).

## Current Block

To continue an automation without continuing one long expression, use *Session.CurrentBlock* and pass the type of the page you're on. This is especially useful when setting up test cases. A suite of tests might start out the same; they go to the site and log in. Then the individual test cases can pick up from there with `Session.CurrentBlock<LoggedInPage>...`.

Similarly, if you want to switch focus to a different block you can do it inline with `ScopeTo<SomePage>`.

# Using Linq

The *Options* property in the first example above returns an *IEnumerable* of options. This allows the automator to decide which option to act on however they like. Using linq we get many methods for free. Here are some examples of valid selections:

```c#
Options.First().Click();
```
Clicks the first option.

```c#
Options.Last().Click();
```
Clicks the last option.

```c#
Options.ElementAt(3).Click();
```
Clicks the fourth option.

```c#
Options.WithText("Green").Single().Click();
```
Clicks the option with text "Green". Throws an exception if there aren't any or if there are more than one.

```c#
Options.WithText("Green").First().Click();
```
Clicks the *first* option with text "Green". Throws an exception if there aren't any, but not if there are multiple.

```c#
Options.Skip(1).Random().Click();
```
Clicks any but the first option at random.

```c#
Options.Reverse().Skip(1).Random().Click();
```
Clicks any but the last option at random.

```c#
Options.Where(opt => opt.Text.EndsWith("e")).First().Click();
```
Clicks the first options whose text ends with "e".

```c#
Options.Unselected().Random().Click();
```
Click a random option excluding the one already selected.

Note that *Random*, *WithText*, and *Unselected* are not part of linq, but come with Bumblebee.

We can use this pattern whenever we have a collection of similar elements. Suppose we have a user search page on our site. The search results come back as a list of user profile links. We can easily model all of these links with a single property:

```c#
public IEnumerable<IClickable<ProfilePage>> ProfileLinks
{
    get
    {
        return GetElements(By.ClassName("profileLink")).Select(link => new Clickable<ProfilePage>(this, link));
    }
}
```

Now in our automations we can type

```c#
ProfileLinks.First().Click();
```

along with all the other selectors.

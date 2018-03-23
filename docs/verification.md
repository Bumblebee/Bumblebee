# Verification

When writing automated test cases, you often want to verify that particular condition is true. When it isn't, you want a meaningful exception to be thrown, failing the test case. Using Bumblebee, these verifications are performed using extension methods.

## Verify

The most versatile form of verification is the `Verify` method. This method can be called at any time during your test case. It's parameter is a predicate; a function that returns true or false. The function you pass to `Verify` takes one parameter, the object that called verify. The function is typically created anonymously with a lambda expression.

In addition, `Verify` takes whatever object called it and passes it into your function. After performing the verification, it returns the object that called it. This is what allows you to chain verifications together.

Here is an example.

```c#
var s = "foo";
s
  .Verify(x => x.Length == 3)
  .Verify(x => x.EndsWith("o"));
```

The `x` variable is simply our name for the parameter that the predicate accepts. A lambda expression is really just an anonymous form of a function that takes in parameters and returns values.  

For example, you could express the previous code as follows:

```c#
public void Test()
{
  var s = "foo";
  s
    .Verify(LengthIsThree)
    .Verify(EndsWithO);
}

public bool LengthIsThree(string x)
{
  return x.Length == 3;
}

public bool EndsWithO(string x)
{
  return x.EndsWith("o");
}
```

Using this technique, you could make your code look more readable as well as avoid the use of lambda expressions.

## Adding Readability

To make our test cases more readable, we can add a string argument describing what we are verifying, like so:

```c#
var s = "foo";
s
.Verify("that the length is 3", x => x.Length == 3)
.Verify("that the string ends with 'o'", x => x.EndsWith("o"));
```

Adding these strings makes it easy to read through the verifications, and adds a level of self-documentation. In addition, when a verification fails, the failure message will be representative of what happened. Instead of "Unable to verify custom verification", you will get a much more helpful error message, "Unable to verify that the length is 3".

## VerifyThat

Another way to add readability to your verifications is to leverage your own preferred assertion library.  The `VerifyThat` method takes whatever object called it and passes it into your assertion action.  Below is an example using assertions from the [NUnit](http://nunit.org) and [FluentAssertions](https://github.com/dennisdoomen/fluentassertions/wiki) libraries.

```c#
var s = "foo";
s
.VerifyThat(x => Assert.IsTrue(x.StartsWith("f")) //nunit
.VerifyThat(x => x.Should().Contain("o"));        //fluent assertions
```

## Verifying Presence

There are some additional verification extension methods that handle more specific situations.  Say we wanted to make sure that an error message has appeared on the site, with an ID of "errorMessage".  We can do so by passing the selector.

```c#
...
.VerifyPresence(By.Id("errorMessage"));
```

Like with `Verify`, we can add a string as the first argument to describe in English what we are verifying. 

```c#
...
.VerifyPresenceOf("an error message", By.Id("errorMessage"));
```
Similarly we could make sure that there is no such error message:

```c#
...
.VerifyAbsence(By.Id("errorMessage"))
.VerifyAbsenceOf("an error message", By.Id("errorMessage"));
```

## Convenience Verifications

Bumblebee comes with some convenience verification methods that only work on some types. For example, here are some verifications that can only be performed on things with text, that is, elements that implement the `IHasText` interface.

```c#
.SomeTextField
.VerifyText("Verify this text matches exactly")
.VerifyTextContains("Verify the element's text contains this text")
.VerifyTextMismatch("Verify the element's text does not match this text")
...
```

These are merely convenience methods. For example, the examples above could more verbosely be written like this:

```c#
.SomeTextField
.Verify(hasText => hasText.Text == "Verify this text matches exactly")
.Verify(hasText => hasText.Text.Contains("Verify the element's text contains this text"))
.Verify(hasText => hasText.Text != "Verify the element's text does not match this text")
...
```

When more specific verifications are required, you can also fall back to using lambda expressions. If you find yourself using very similar lambda expressions frequently, it would be a good idea to make your own verification method. Look at the Bumblebee source at [*Verifications*](../blob/master/Bumblebee/Extensions/Verification.cs) for examples.

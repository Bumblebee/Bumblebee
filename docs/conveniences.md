# Conveniences

## Pause

Call *Pause(int miliseconds)* at any point in your automation and execution will pause. Scope will be returned exactly where it was.

## Hover

To hover over any element, call *Hover(int miliseconds)* to hover the mouse over that element for the specified number of seconds. Like when pausing, scope will be returned to exactly where it was.

## Verification

Perform verifications from within your automation expression. Scope returns to where it was before the call. There are specific verification methods for verifying the presence or absence of an element, verifying the text of an element, and verifying the selected/unselected status of an option. For a greater degree of flexibility, you can call *Verify* at any point in your test case, and give a predicate to verify in the form of a lambda expression. The parameter of the lambda expression is the calling object.

The example below verifies that a select box has five options and then clicks the last.

```c#
...
.SomeSelectBox.Options
.Verify(opts => opts.Count() == 5)
.Last().Click()
...
```
[More information about verification](verification.html)

## Drag and Drop

Selenium supports dragging elements onto other elements, as well as dragging elements by a certain offset. Lets say we have a web page which has a visual calendar in which appointments can be dragged from one time to another. Lets say the page object, `AppointmentCalendarPage`, has properties `Appointments` and `TimeSlots`, which each return `IEnumerable<IClickable<AppointmentCalendarPage>>` so that the appointments and time slots can be filtered through using LINQ. The following automation drags the first appointment into the last time slot, and then drags the last appointment up 50 pixels. The second drag anticipates an alert dialog, and dismisses it.

```c#
...
.AppointmentCalendarPage
.Drag(acp => acp.Appointments.First()).AndDrop(acp => acp.TimeSlots.Last())
.Drag(acp => acp.Appointments.Last()).AndDrop<AlertDialog>(0, -50)
.Dismiss<AppointmentCalendarPage>();
```

## Debug printing

Debug by printing information within automations. Call *DebugPrint* to print the current object, or pass a function to operate on the object first. The example below clicks the last option of a select box, but first prints the first option's text.

```c#
...
.SomeSelectBox.Options
.DebugPrint(opts => opts.First().Text)
.Last().Click()
...
```

If your lambda returns an `IEnumerable` of some kind, `DebugPrint` will print each value. For example, you can instead print all of the select box options like so:

```c#
...
.SomeSelectBox.Options
.DebugPrint(opts => opts.Select(opt => opt.Text))
.Last().Click()
...
```

## Frames

Frames are easy! They are just blocks. Other blocks can extend them, which causes the frame to be selected before the child block's constructor is even executed. Is the whole site content in a frame? Select the frame in your base block and forget about it.

After selecting a frame in the constructor in a frame block, don't forgot to set the the *Tag* element. Any old elements you had selected will be stale after switching frames. Throw in a `Tag = Session.Driver.GetElement(By.TagName("body"));` and you should be all set to continue nesting blocks.

## Alerts

Ordinarily if an alert appears you will wind up with an error indicating that you were blocked by a modal dialog. Sometimes, however, you expect an alert to appear during your automation and you'd like to deal with it. For these situations there is a block that represents alerts.

Say we have a link that deletes a user's profile. Clicking it brings up an alert prompting whether or not you are sure. Canceling stays on the profile page, and accepting goes to the home page. We should set up the link as an `IClickable<IAlertDialog>`. Here are some possible automations:

```c#
...
.DeleteProfileLink.Click()
.Accept<HomePage>()
...
```

```c#
...
.DeleteProfileLink.Click()
.Dismiss<ProfilePage>()
...
```

Alerts can sometimes appear due to very convoluted conditions. In your automation, if you expect an alert to appear, you can call `Click<AlertDialog>()`. *AlertDialog* is Bumblebee's *IAlertDialog* implementation representing popup alerts. If your site uses custom alerts, like lightboxes, make a block that implements *IAlertDialog* and use that instead.

## Storing temporary data

Often during a test it is necessary to verify that two things match. For example, say you change the user's favorite color by randomly selecting a different option in their favorite color select box. Then you view the home page and you want to confirm that it lists their new favorite color. To do this, we need to store the text of the randomly selected option until it's time to verify it. For this we use the *Store* extension method.

Here's the code first:

```c#
string newFavoriteColor;

Session.NavigateTo<HomePage>(url)
    .UsernameField.EnterText("randylahey@sunnyvale.org")
    .PasswordField.EnterText("password1234")
    .LogInButton.Click<ProfilePage>()
    .FavoriteColorSelectBox.Options.Random()
    .Store(out newFavoriteColor, opt => opt.Text)
    .Click()
    .HomePageLink.Click()
    .Verify("the text has updated", page => page.FavoriteColor == newFavoriteColor);
```

First we create a variable in which to store our temporary data, *newFavoriteColor*. When we select our random option, before we click it, we can call *Store* to store information about it. Store takes our variable as an out parameter, which allows the extension method to assign to it. The second parameter is a function acting on the calling object, which in this case is the random option. We return the option's text for storage into the variable.

On the home page, the *FavoriteColor* property refers to some text on the home page. To add a property like this to a block, make a string property with a getter that finds the text on the page and returns it.

If you need to compare two stored values, use *VerifyEquality* or *VerifyInequality* which take any two objects.

## Playing Sound

This last one started off as a joke, but the more I thought about the better the idea seemed. If you've written many automated tests before, you'll understand the following situation.

You run an automation with the goal of observing or debugging a certain procedure. You wait twenty or thirty seconds while the test case is doing its thing. You space out for not five seconds. You look back at the screen and the test is over; you missed the part you actually wanted to see. You rerun the test and repeat the whole process again, getting more and more frustrated with yourself.

Bumblebee's "solution" is rather ridiculous: play a "dinging" sound right before the part you care about. When debugging, place `PlaySound()` right before the interesting part of your test and Bumblebee will play a system sound. You can optionally pass it a number of seconds to pause, to give you time to switch to the window or what have you.

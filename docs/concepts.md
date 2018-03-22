# Concepts

Bumblebee is a .NET layer on top of the Selenium browser automation framework that allows for the standardized creation of page objects, even for dynamic web pages.

Like other page object models, Bumblebee divides testing into two parts. The page objects model the subject of the testing, and the automation uses the page objects to tell the browser what to do.

Bumblebee standardizes the design of page objects and makes the automation scripting trivial. Develop page objects quickly by modeling which parts of the page can be interacted with. Then in the automation, use Intellisense to browse through the available options and build a script.

The basic idea behind Bumblebee is to break each page down into blocks and elements. Use the classes provided by Bumblebee to model your site into page objects. Consume page objects by writing your automation code. If page objects are well designed, writing the automation code should take no effort at all.

The following are concepts that you should be familiar with in Bumblebee:

* [Blocks](blocks.html)
* [Elements](elements.html)
* [Sessions](sessions.html)
* [Using Linq](using-linq.html)
* [Conveniences](conveniences.html)

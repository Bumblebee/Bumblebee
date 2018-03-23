# Benefits

Bumblebee is a .NET layer on top of the Selenium browser automation framework that allows for the standardized creation of page objects, even for dynamic web pages. There are a few features that define Bumblebee's usability.

-   Standardized UI interfaces
-   Modular page objects
-   IntelliSense-driven automations
-   Test Framework independence
-   Parallelization mindfulness
-   Flexibility

## Extensible Page Objects

In the typical page object model, a class is build to represent a page. Each method indicates an action that can be performed on the page. While this is helpful for writing automations, it is not as expressive as it could be. 

Instead of typical page objects, Bumblebee uses blocks. A block is a specific area on a web page. This could be the entire page (like a page object) or a subset, like a tab menu, a sidebar, or a table. Each block is represented by a class that extends `Block`. Blocks can contain UI elements, like links, text fields, and check boxes. Blocks can also contain other blocks. A block's contents are represented as properties of that block.

This model allows us to represent our pages in a modular way, grouping common elements together and nesting things in a natural way.

## Write Automations Using IntelliSense

In Bumblebee, we start off an automation by specifying at which page we'd like to begin. Doing so returns a block representing our current scope (which object our test is focusing on). That block then has properties (seen by IntelliSense) for each element contained within. After selecting which element we'd like to interact with, we can view its methods. A check box, for example, will have methods `Check`, `Uncheck`, and `Toggle`. Each method performs the action returns the next block. From here the process repeats. 

## Interact With Standardized UI Elements

Bumblebee provides interfaces for the most common web UI elements, like links, buttons, alert dialogs, check boxes, select boxes, and text fields. On the web each of these standard elements can be implemented in a variety of ways. A web page might implement a select box by using the select tag, or by using a jQuery UI element, etc. In Bumblebee, an automation only ever reacts with the interface; an automation knows it's interacting with a select box, but it doesn't care what kind. When the element is created as a property of some block, it returns the interface but instantiates the actual implementation. Bumblebee comes with all the standard implementations, and allows the user to create their own implementations as well. 

## Test Framework Independence

Bumblebee can be used with any test framework, allowing you the freedom to set up your own project. You can put your page objects in one project, and put your automations in another, running them with whichever x-unit framework makes sense. Each browser session is instantiated with a driver environment, specifying how to create the driver for that particular session. Thus you can have multiple environments, such as a local environment (running on your local machine) and a grid environment (running on some remote grid). The parameters these take in (which browser, timeout specification, etc.) is entirely up to you.

## Automation Flexibility

Often in a complicated web site, page objects are plagued by conditional specifications. For example, clicking a link leads to some specific page 99% of the time, but some other page under very specific circumstances. A page object has rigid methods, and can't support the edge cases as easily. With Bumblebee, interacting with elements typically allows the automator to tack a generic type onto the method, changing the block that is returned. This makes test cases extremely flexible, and takes some of the burden off of designing blocks for complicated sites.

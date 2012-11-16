Bumblebee
=========

Bumblebee is a layer on top of the Selenium browser automation framework. Using Bumblebee and the accompanying design paradigm allows for easy creation of page objects, even for dynamic web pages.

The basic idea behind Bumblebee is to break each page down into blocks and elements. A block is an area on a web page. This could be an entire page, a tab menu, a sidebar, etc. An element is a user interface item. Examples include links, buttons, checkboxes, select boxes, etc. 

Bumblebee uses generics and reflection to make sure each action taken by an element returns the proper block. This makes writing test cases as easy as using Intellisense to see what actions are available at each step.

Blocks
------

Each block is represented by a class. Blocks can contain elements as well as other blocks. Each is represented by a property in the parent block's class.

Let's use the ever familiar Google homepage as an example. We'd represent the whole page as a block. The search bar and buttons would each be elements. We can then represent the top menu as a child block.

In the child block class, we represent each link as its own element.

Elements
--------

Each type of element is represented by an interface. For example IClickable represents both buttons and links (with a single method, "Click"). The return type of the action taken by the element is decided in the definition of the element's property. The return type is the class of the resulting block, and is specified as a generic type.

For example, say we have a class represented google's home page, HomePage, and one for the search results page, SearchResultsPage. Both these classes extend Block. In HomePage, we can define the search bar as <code>ITextField&lt;HomePage&gt; SearchBar { ... }</code> The generic type is where focus will be after text is entered. Because it does not switch pages when text is entered, the type parameter is the same as the parent class. Next we can define the search button as <code>IClickable&lt;SearchResultsPage&gt; { ... }</code> After the button is clicked, focus will shift to the search results page.

Using the framework above, we can automate a google search like so:

<code>Session.GoTo&lt;HomePage&gt;().SearchBar.EnterText("kittens").SearchButton.Click();</code>

To be continued...
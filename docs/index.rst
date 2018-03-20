.. Bumblebee documentation master file, created by
   sphinx-quickstart on Mon Mar 19 22:00:21 2018.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

Welcome to Bumblebee's documentation!
=====================================

.. image:: https://badges.gitter.im/Join%20Chat.svg
   :alt: Gitter
   :target: https://gitter.im/Bumblebee/Discuss?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=body_badge

Bumblebee is a .NET layer on top of the Selenium browser automation framework that allows for the standardized creation of page objects, even for dynamic web pages. There are a few features that define Bumblebee's usability.

-   Standardized UI interfaces
-   Modular page objects
-   IntelliSense-driven automations
-   Test Framework independence
-   Parallelization mindfulness
-   Flexibility

Like other page object models_, Bumblebee divides testing into two parts. The page objects model the subject of the testing, and the automation uses the page objects to tell the browser what to do.

Bumblebee standardizes the design of page objects and makes the automation scripting trivial. Develop page objects quickly by modeling which parts of the page can be interacted with. Then in the automation, use Intellisense to browse through the available options and build a script.

The basic idea behind Bumblebee is to break each page down into <a href="./blocks.html"><i>Blocks</i></a> and [*Elements*](./elements). Use the classes provided by Bumblebee to model your site into page objects that you can consume in your automation code. If page objects are well designed, writing the automation code should take no effort at all.

_page object models: https://github.com/SeleniumHQ/selenium/wiki/PageObjects

[Top](./)

## Releases

* **Bumblebee** - A fluent-style, .NET layer on top of Selenium for implementing the [page pattern](https://code.google.com/p/selenium/wiki/PageObjects).<br>
  * [![NuGet version (Bumblebee.Automation)](https://img.shields.io/nuget/v/Bumblebee.Automation.svg?style=flat)](https://www.nuget.org/packages/Bumblebee.Automation/)
  * [![NuGet version (Bumblebee.Automation)](https://img.shields.io/nuget/vpre/Bumblebee.Automation.svg?style=flat)](https://www.nuget.org/packages/Bumblebee.Automation/2.0.6-alpha) 

* **Bumblebee for Kendo UI** - A separate library for adding Kendo element support for Bumblebee.<br>
  * [![NuGet version (Bumblebee.Automation.KendoUI)](https://img.shields.io/nuget/v/Bumblebee.Automation.KendoUI.svg?style=flat)](https://www.nuget.org/packages/Bumblebee.Automation.KendoUI/)

[Top](./)

## Contact Us
If you are having issues or would like to provide feedback, you can join the [gitter conversation](https://gitter.im/Bumblebee/Discuss) or go [here](https://github.com/bumblebee/bumblebee/issues) to log issues. 

[Top](./)


.. toctree::
   :hidden:
   :maxdepth: 2
   :caption: User Documentation

   benefits
   getting-started


.. toctree::
   :maxdepth: 2
   :caption: Feature Documentation

   concepts
   blocks
   elements
   sessions
   settings
   driver-environments
   verification
   using-linq
   conveniences
   dependencies

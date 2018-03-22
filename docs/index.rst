Bumblebee
=========

Bumblebee is a .NET layer on top of the Selenium browser automation framework that allows for the standardized creation of page objects, even for dynamic web pages. There are a few features that define Bumblebee's usability.

* Standardized UI interfaces
* Modular page objects
* IntelliSense-driven automations
* Test Framework independence
* Parallelization mindfulness
* Flexibility

Like other `page object models`_, Bumblebee divides testing into two parts. The page objects model the subject of the testing, and the automation uses the page objects to tell the browser what to do.

Bumblebee standardizes the design of page objects and makes the automation scripting trivial. Develop page objects quickly by modeling which parts of the page can be interacted with. Then in the automation, use Intellisense to browse through the available options and build a script.

The basic idea behind Bumblebee is to break each page down into :doc:`blocks` and :doc:`elements`. Use the classes provided by Bumblebee to model your site into page objects that you can consume in your automation code. If page objects are well designed, writing the automation code should take no effort at all.

.. _page object models: https://github.com/SeleniumHQ/selenium/wiki/PageObjects

If you are new to Bumblebee, check out the :doc:`getting-started` page first.

.. toctree::
   :maxdepth: 2
   :hidden:
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

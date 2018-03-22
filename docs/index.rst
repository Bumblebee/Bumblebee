.. Bumblebee documentation master file, created by
   sphinx-quickstart on Mon Mar 19 22:00:21 2018.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

Welcome to Bumblebee!
==============================================

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

Like other `page object models`_, Bumblebee divides testing into two parts. The page objects model the subject of the testing, and the automation uses the page objects to tell the browser what to do.

Bumblebee standardizes the design of page objects and makes the automation scripting trivial. Develop page objects quickly by modeling which parts of the page can be interacted with. Then in the automation, use Intellisense to browse through the available options and build a script.

The basic idea behind Bumblebee is to break each page down into Blocks_ and Elements_. Use the classes provided by Bumblebee to model your site into page objects that you can consume in your automation code. If page objects are well designed, writing the automation code should take no effort at all.

.. _page object models: https://github.com/SeleniumHQ/selenium/wiki/PageObjects
.. _Blocks: ./blocks.html
.. _Elements: ./elements.html

Releases
--------

* **Bumblebee** - A fluent-style, .NET layer on top of Selenium for implementing the `page pattern`_.

.. _page pattern: https://code.google.com/p/selenium/wiki/PageObjects

.. image:: https://img.shields.io/nuget/v/Bumblebee.Automation.svg?style=flat
   :alt: Bumblebee Current - NuGet
   :target: https://www.nuget.org/packages/Bumblebee.Automation/
   
.. image:: https://ci.appveyor.com/api/projects/status/k24rhl5hvxs9j9ya?svg=true
   :alt:  Bumblebee Current - Build Status
   :target: https://ci.appveyor.com/project/toddmeinershagen/bumblebee
|
.. image:: https://img.shields.io/nuget/vpre/Bumblebee.Automation.svg?style=flat
   :alt: Bumblebee vNext - NuGet
   :target: https://www.nuget.org/packages/Bumblebee.Automation/2.0.8-beta

.. image::  https://ci.appveyor.com/api/projects/status/5aser6k7s2x1t0fg?svg=true
   :alt: Bumblebee vNext - Build Status
   :target: https://ci.appveyor.com/project/toddmeinershagen/bumblebee-hqwf8
   
* **Bumblebee for Kendo UI** - A separate library for adding Kendo element support for Bumblebee.

.. image:: https://img.shields.io/nuget/v/Bumblebee.Automation.KendoUI.svg?style=flat
   :alt: NuGet version (Bumblebee.Automation.KendoUI)
   :target: https://www.nuget.org/packages/Bumblebee.Automation.KendoUI/

Contact Us
----------

If you are having issues or would like to provide feedback, you can join the `gitter conversation`_ or go here_ to log issues. 

.. _gitter conversation: https://gitter.im/Bumblebee/Discuss
.. _here: https://github.com/bumblebee/bumblebee/issues


.. toctree::
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

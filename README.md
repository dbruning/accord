<img src="Setup/Portable/NuGet/portable-accord.png" alt="Portable Accord.NET logo" height="108" />

Portable Accord.NET Framework
=============================

Copyright (c) 2009-2015 César Roberto de Souza; Portable Class Library adaptations (c) 2013-2015 Anders Gustafsson, Cureos AB. 
Distributed under the Lesser GNU Public License, LGPL, version 2.1.

This project is a fork of César Souzas's original [Accord.NET Framework](https://github.com/accord-net/framework) project. 
For general information and tutorials, see [here](http://accord-net.github.io).

The repository currently provides:

* Portable Class Libraries for base and imaging functionality functionality (Core, Math, Math.Noncommercial, Statistics, IO, MachineLearning, MachineLearning.GPL, Neuro, Imaging, Vision, Audio) 

The portable class libraries reference the portable *Shim* and/or *Shim.Drawing* assemblies. In applications however, the platform specific *Shim* and *Shim.Drawing* assemblies should be referenced, to ensure that the platform specific version of each type is used.
 
`WriteableBitmap`:s provide input and output to the imaging functionality in the WPF, Windows Store and Windows Phone libraries. The target specific *Shim.Drawing* assemblies incorporates explicit cast operators between `WriteableBitmap` and `System.Drawing.Bitmap`.

All image processing is performed on the mock `System.Drawing.Bitmap` class, `WriteableBitmap` objects should only be used as initial input to and final output from the image processing.

When using the WPF *Shim.Drawing* assembly, the real *System.Drawing* assembly from .NET Framework cannot be referenced. If there is a need to reference 
the real *System.Drawing* assembly, you are recommended to use the original *Accord.NET Framework* libraries and use WPF hosting controls to display image processing results instead.

Installation
------------

The preferred method for using *Portable Accord.NET* in your application is to download the required packages, including dependencies, from [NuGet](https://www.nuget.org/packages?q=portable.accord). Open the NuGet Package Manager
in Visual Studio and search for **portable.accord** to obtain a list of the currently available packages on *NuGet*.

Building the libraries
----------------------

You are strongly advised to obtain the *Portable Accord.NET Framework* libraries from *NuGet*. If you do prefer to build the libraries yourself, follow these instructions.

To sufficiently build and use the class libraries in the *Portable Accord.NET Framework*, the companion repository [Portable AForge.NET Framework](https://github.com/cureos/aforge) must be readily available.
*Accord.NET Framework* is dependent upon *AForge.NET Framework*, and the *Portable AForge.NET Framework* also contains support libraries for successfully building Portable Class Libraries from the *Accord.NET Framework* code base and incorporate these PCL:s in mobile, tablet or desktop WPF applications.

The *Portable Accord* libraries make use of the following libraries from *NuGet*:

* Shim
* Shim.Drawing
* Portable AForge libraries

Open the *Portable.Accord.Net.sln* solution file located in the *Sources* folder and build the entire solution or selected projects. Visual Studio 2012 Professional or higher is required.


Ported Status
-------------

The unit test status when replacing the .NET Framework based assemblies with their PCL analogues should give an indication of the current completeness of the porting of the non-imaging assemblies.

Results, April 14, 2015 (synched with main repository commit [2f27a21](https://github.com/accord-net/framework/commit/2f27a215dcb1cdbe0302a6a5515fb61368292891)):

* Accord.Tests.Audio, 12 unit tests (*WaveFileAudioSourceTest* excluded), all passed
* Accord.Tests.IO, 44 unit tests, all passed
* Accord.Tests.Math, 513 unit tests, all passed
* Accord.Tests.Statistics, 1139 tests (*Controls* related tests excluded), all passed
* Accord.Tests.MachineLearning, 156 tests (*RansacLineTest* excluded), 3 failed
* Accord.Tests.Neuro, 25 tests, all passed

The failed tests in *Accord.Tests.MachineLearning* concern serialization, and these failures are due to missing *OnDeserialized* methods in the tested classes of the PCL *MachineLearning* library.

Notes on commercial use
-----------------------

The *Shim.Drawing* assemblies that are required to build the Portable Class Library versions of *AForge.NET Framework* and *Accord.NET Framework* are published under the General Public License, version 3.

There are *Shim* and *Shim.Drawing* assemblies available for *Xamarin.Android* and *Xamarin.iOS*, making it possible to 
incorporate *Portable AForge* and *Portable Accord* assemblies in *Android* and *iPhone* or *iPad* apps. See for example [this](http://cureos.blogspot.com/2014/10/smartphone-image-processing-development.html) blog post. 

*Shim Drawing* is available for evaluation from *NuGet* for all supported platforms.

To purchase a commercial license of *Shim.Drawing* for *Android*, *iOS* or *Universal*/*Windows 8.1*/*Windows Phone (non-Silverlight) 8.1* for unlimited distribution of *Portable AForge* and *Portable Accord* based applications on app stores, simply click on one of these buttons:

<table>
<tr>
<th>Android, €50</th>
<th>iOS, €50</th>
<th>Windows, €50</th>
<th>All platforms, €100</th>
</tr>
<tr>
<td><a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=QF33BCWJXJU26"><img src="https://www.paypalobjects.com/en_US/i/btn/btn_buynow_SM.gif"/></a></td>
<td><a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=KN9Q7U76ETCDS"><img src="https://www.paypalobjects.com/en_US/i/btn/btn_buynow_SM.gif"/></a></td>
<td><a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=UU5XKDER4JFQ4"><img src="https://www.paypalobjects.com/en_US/i/btn/btn_buynow_SM.gif"/></a></td><td><a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=LLK2ZYW4JV8GY"><img src="https://www.paypalobjects.com/en_US/i/btn/btn_buynow_SM.gif"/></a></td>
</tr>
</table>

All prices include VAT. Upon purchase, you will receive a link from where you can download the corresponding versions of the *Shim.Drawing* assemblies that do not insert watermarks into the images.

Please also note that *AForge.NET Framework* (on which *Accord.NET Framework* is dependent) is licensed under LGPL version 3, and the copyright holder states the following on the *AForge.NET Framework* website:

> Regarding collaboration, contribution, offers, partnering, custom work/consulting, none GPL/LGPL licensing, etc., please, contact using the next e-mail:
aforge.net [at] gmail {dot} com

The *Accord.NET Framework* is released under LGPL version 2.1, and further licensing details can be found [here](http://accord-framework.net/license.html).

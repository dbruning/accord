![The Accord.NET Framework](http://accord-framework.net/docs/icons/logo.png)

Portable Accord.NET Framework
=============================

Copyright (c) 2009-2014 César Roberto de Souza; Portable Class Library, WPF, Windows Store and Windows Phone adaptations (c) 2013-2104 Anders Gustafsson, Cureos AB. 
Distributed under the Lesser GNU Public License, LGPL, version 2.1.

This project is a fork of César Souzas's original [Accord.NET Framework](https://github.com/accord-net/framework) project. 
For general information and tutorials, see [here](http://accord-net.github.io).

The repository currently provides:

* Portable Class Libraries for base and imaging functionality functionality (Core, Math, Math.Noncommercial, Statistics, IO, MachineLearning, MachineLearning.GPL, Neuro, Imaging, Vision) 

To sufficiently build and use the class libraries in the *Portable Accord.NET Framework*, the companion repository [Portable AForge.NET Framework](https://github.com/cureos/aforge) must be readily available.
*Accord.NET Framework* is dependent upon *AForge.NET Framework*, and the *Portable AForge.NET Framework* also contains support libraries for successfully building Portable
Class Libraries from the *Accord.NET Framework* code base and incorporate these PCL:s in Windows Store, Windows Phone 8 or WPF applications.

The portable class libraries reference the portable *Shim* and/or *Shim.Drawing* assemblies. In applications however, the target specific (Windows Store, Windows Phone or WPF)
*Shim* and *Shim.Drawing* assemblies should be referenced, to ensure that the target specific version of each type is used.
 
`WriteableBitmap`:s provide input and output to the imaging functionality in the WPF, Windows Store and Windows Store libraries. The target specific *Shim.Drawing* assemblies 
incorporates explicit cast operators between `WriteableBitmap` and `System.Drawing.Bitmap`.

All image processing is performed on the mock `System.Drawing.Bitmap` class, `WriteableBitmap` objects should only be used as initial input to and final output from the
image processing.

When using the WPF *Shim.Drawing* assembly, the real *System.Drawing* assembly from .NET Framework cannot be referenced. If there is a need to reference 
the real *System.Drawing* assembly, you are recommended to use the original *Accord.NET Framework* libraries and use WPF hosting controls to display image processing results instead.


Building the libraries
----------------------

The *Portable Accord* libraries make use of the following libraries from NuGet:

* [Shim.NET](https://www.nuget.org/packages/shim)
* [Microsoft Compression](https://www.nuget.org/packages/Microsoft.Bcl.Compression/)
* [Microsoft BCL Build Components](https://www.nuget.org/packages/Microsoft.Bcl.Build/)

As a prerequisite, download the companion repository [Portable AForge.NET Framework](https://github.com/cureos/aforge) to a folder named *aforge*, which should be located alongside the *accord* main folder.

Open the *Portable.Accord.Net.sln* solution file located in the *Sources* folder and build the entire solution or selected projects. Visual Studio 2012 Professional or higher is required.


Ported Status
-------------

The unit test status when replacing the .NET Framework based assemblies with their PCL analogues should give an indication of the current completeness of the porting 
of the non-imaging assemblies.

Results, July 28, 2014:

* Accord.Tests.Audio, 12 unit tests, all passed
* Accord.Tests.IO, 8 unit tests, all passed
* Accord.Tests.Math, 449 unit tests, 1 failed
* Accord.Tests.Statistics, 942 tests, all passed
* Accord.Tests.MachineLearning, 131 tests, 5 failed
* Accord.Tests.MachineLearning.GPL, 1 test, all passed
* Accord.Tests.Neuro, 20 tests, all passed

2 of the failed tests in *Accord.Tests.MachineLearning* concern serialization, and these failures are due to missing *OnDeserialized* methods in 
the tested classes of the PCL *MachineLearning* library.
2 failed *Accord.Tests.MachineLearning* tests are due to insufficient unit test formulations, see [Issue Report 84](https://code.google.com/p/accord/issues/detail?id=84).

Also see [this issue report](https://github.com/cureos/accord/issues/10).


Notes on commercial use
-----------------------

The *Shim* and *Shim.Drawing* assemblies that are required to build the Portable Class Library versions of *AForge.NET Framework* and *Accord.NET Framework* are published under the General Public License, version 3.
For those interested in using the Portable *Accord.NET* and *AForge.NET* libraries without having to adhere to GPL, please contact the copyright holder of the *Shim* assemblies at

licenses@cureos.com

for commercial licensing alternatives.

Please also note that *AForge.NET Framework* (on which *Accord.NET Framework* is dependent) is licensed under LGPL version 3, and the copyright holder states the following on the *AForge.NET Framework* website:

> Regarding collaboration, contribution, offers, partnering, custom work/consulting, none GPL/LGPL licensing, etc., please, contact using the next e-mail:
aforge.net [at] gmail {dot} com

The *Accord.NET Framework* is released under LGPL version 2.1, and further licensing details can be found [here](http://accord-framework.net/license.html).

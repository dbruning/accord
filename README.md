![The Accord.NET Framework](http://accord-framework.net/docs/icons/logo.png)

Portable Accord.NET Framework
=============================

Copyright (c) 2009-2013 César Roberto de Souza; Portable Class Library, WPF, Windows Store and Windows Phone adaptations (c) 2013 Anders Gustafsson, Cureos AB. 
Distributed under the Lesser GNU Public License, LGPL, version 2.1.

This project is a fork of César Souzas's original [Accord.NET Framework](https://github.com/accord-net/framework) project. 
For general information and tutorials, see [here](http://accord-net.github.io).

The repository currently provides:

* Portable Class Libraries for base and imaging functionality functionality (Core, Math, Statistics, MachineLearning, MachineLearning.GPL, Neuro, Imaging, Vision) 

To sufficiently build and use the class libraries in the *Portable Accord.NET Framework*, the companion repository [Portable AForge.NET Framework](https://github.com/cureos/aforge) must be readily available.
*Accord.NET Framework* is dependent upon *AForge.NET Framework*, and the *Portable AForge.NET Framework* also contains support libraries for successfully building Portable
Class Libraries from the *Accord.NET Framework* code base and incorporate these PCL:s in Windows Store, Windows Phone 8 or WPF applications.

The portable class libraries reference the portable *AForge.System* and/or *AForge.System.Drawing* assemblies. In applications however, the target specific (Windows Store, Windows Phone or WPF)
*AForge.System* and *AForge.System.Drawing* assemblies should be referenced, to ensure that the target specific version of each type is used.
 
`WriteableBitmap`:s provide input and output to the imaging functionality in the WPF, Windows Store and Windows Store libraries. The target specific *AForge.System.Drawing* assemblies 
incorporates implicit cast operators between `WriteableBitmap` and `System.Drawing.Bitmap`.

All image processing is performed on the mock `System.Drawing.Bitmap` class, `WriteableBitmap` objects should only be used as initial input to and final output from the
image processing.

When using the WPF `AForge.System.Drawing` assembly, the real `System.Drawing` assembly from .NET Framework cannot be referenced for obvious reasons. If there is a need to reference 
the real `System.Drawing` assembly, you are recommended to use the original *Accord.NET Framework* libraries and use WPF hosting controls to display image processing results instead.


Building the libraries
----------------------

As a prerequisite, download the companion repository [Portable AForge.NET Framework](https://github.com/cureos/aforge) to a folder named *aforge*, which should be located alongside the *accord* main folder.

Open the *Portable.Accord.Net.sln* solution file located in the *Sources* folder and build the entire solution or selected projects. Visual Studio 2012 Professional or higher is required.


Ported Status
-------------

The unit test status when replacing the .NET Framework based assemblies with their PCL analogues should give an indication of the current completeness of the porting 
of the non-imaging assemblies.

Results, December 20, 2013:

* Accord.Test.Math, 350 unit tests, 5 failed
* Accord.Test.Statistics, 858 tests, 13 failed
* Accord.Test.MachineLearning, 120 tests, 25 failed
* Accord.Test.MachineLearning.GPL, 1 test, 0 failed
* Accord.Test.Neuro, 17 tests, 0 failed

Apart from these apparent deficiencies, ellipse and line drawing for the Imaging assembly is also not yet implemented.

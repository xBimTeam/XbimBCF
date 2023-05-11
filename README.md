Build Status (master branch): [ ![Build Status](http://xbimbuilds.cloudapp.net/app/rest/builds/buildType:(id:Xbim_XbimBcf_XbimBcf),branch:(name:master)/statusIcon "Build Status") ](http://xbimbuilds.cloudapp.net/project.html?projectId=Xbim_XbimBcf&tab=projectOverview "Build Status")

Build Status (develop branch): [![Build Status](https://dev.azure.com/xBIMTeam/xBIMToolkit/_apis/build/status/xBimTeam.XbimBCF?branchName=develop)](https://dev.azure.com/xBIMTeam/xBIMToolkit/_build/latest?definitionId=10&branchName=develop)

# Xbim.BCF - A .net BCF library

## What is it?

This library is an implementation of the BuildingSMART (BCF-XML format)[https://github.com/BuildingSMART/BCF-XML/tree/release_3_0/Documentation] for .net. 
It supports BCF2.0 and 2.1.

XbimBCF is part of the [Xbim Toolkit](https://github.com/xBimTeam/XbimEssentials), but this library can be 
used independently of the Essentials BIM libararies.

## Usage:

```csharp

var bcfZipData = File.OpenRead("yourfile.bcfzip");
var bcf = Xbim.BCF.BCF.Deserialize(bcfZipData);

foreach(var topic in bcf.Topics)
{
   // Access the visualisations, comments etc        
}


```
In order to create a BCF, you will need to instantiate various objects to form the BCF object.
Please look in Xbim.BCF.Tests.BCFTestsXMLHelper to see examples of each object (which will vary depending on your usage). 
Once created, call `BCF.Serialize()` to get a stream of your BCF file.


## Getting Started

We recommend Visual Studio 2019 (or later) or Visual Studio Code to build the solution.

## Licence

This XBIM library is made available under the CDDL Open Source licence.  

## Support & Help

For bugs, please raise an Issue in Github. 

## Getting Involved

Please raise an issue ahead of any PR.

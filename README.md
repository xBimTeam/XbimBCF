Build Status (master branch): [ ![Build Status](http://xbimbuilds.cloudapp.net/app/rest/builds/buildType:(id:Xbim_XbimBcf_XbimBcf),branch:(name:master)/statusIcon "Build Status") ](http://xbimbuilds.cloudapp.net/project.html?projectId=Xbim_XbimBcf&tab=projectOverview "Build Status")

Build Status (develop branch): [![Build Status](https://dev.azure.com/xBIMTeam/xBIMToolkit/_apis/build/status/xBimTeam.XbimBCF?branchName=develop)](https://dev.azure.com/xBIMTeam/xBIMToolkit/_build/latest?definitionId=10&branchName=develop)

#Usage:

```csharp
var bcf = Xbim.BCF.BCF.Deserialize(Stream bcfZipData);
```
In order to create a BCF, you will need to instantiate various objects to form the BCF object.
Please look in Xbim.BCF.Tests.BCFTestsXMLHelperto see examples of each object (which will vary depending on your usage). 
Once created, call `BCF.Serialize()` to get a stream of your BCF file.


# XBIM - the eXtensible Building Information Modelling (BIM) Toolkit

## What is it?


XbimBCF is part of the [Xbim Toolkit](https://github.com/xBimTeam/XbimEssentials).

## Getting Started

We recommend Visual Studio 2019 or Visual Studio Code to build the solution.

## Licence

This XBIM library is made available under the CDDL Open Source licence.  

## Support & Help

For bugs, please raise an Issue in Github. For any other asssitance try our Gitter channel https://gitter.im/xbim-community/community

## Getting Involved

If you'd like to get involved and contribute to this project, please check out our Gitter page at https://gitter.im/xbim-community/community

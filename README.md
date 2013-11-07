Sunlight.Net
============

A .NET Portable Class Library wrapper of the [Sunlight Foundations's](http://sunlightfoundation.com/) set of [web services](http://sunlightfoundation.com/api/). It is a VS.NET 2013 solution and targets .NET 4.5 for Windows Phone 8 and Windows 8 App Store apps.


In order to run the unit tests open the file APIKEY.cs and assign your [registered Sunlight Foundation api key](http://sunlightfoundation.com/api/accounts/register/) to the Key constant:

    static class APIKEY
    {
        public const string Key = "YOUR KEY HERE";
    }

This is currently a work in progress and contains wrappers and unit tests for these services:
- [Capitol Words](http://sunlightlabs.github.io/Capitol-Words/)
- [Political Party Time](http://sunlightlabs.github.io/partytime-docs/)
- [Congress](http://sunlightlabs.github.io/congress/)
- [Open States](http://sunlightlabs.github.io/openstates-api/)
 

All service methods use async/await and basic usage is:

    IOpenStatesService service = new OpenStatesService(APIKEY.Key, "Sunlight.NET unit tests");
    var results = await service.LocateLegislators(44.926868, -93.214049);

    Console.WriteLine("Found {0} legislators", results.Count());

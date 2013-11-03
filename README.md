Sunlight.Net
============

A .NET Portable Class Library wrapper to the [Sunlight Foundations's](http://sunlightfoundation.com/) set of [web services](http://sunlightfoundation.com/api/). It is a VS.NET 2013 solution and targets .NET 4.5 for Windows Phone 8 and Windows 8 App Store apps.


In order to run the unit tests open the file APIKEY.cs and assign your registered Sunlight Foundation api key to the Key constant:

    static class APIKEY
    {
        public const string Key = "YOUR KEY HERE";
    }

Is currently a work in progress and includes:
- [Capitol Words API](http://sunlightlabs.github.io/Capitol-Words/)

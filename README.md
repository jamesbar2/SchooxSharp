# SchooxSharp

###Documentation
We've tried to include as much of the documentation from the API's web site as possible.  Please use the support site for the most up to date information about the API. https://www.schoox.com/api/docs

###Installation
You can install this through Nuget (currently in pre-release) by finding SchooxSharp.Api in the Package Manager or by using the Package Manager Console with the following command:
```
  PM> Install-Package SchooxSharp.Api -Pre
```
###Dependencies
- Newtonsoft.Json >=7.0.1
- RestSharp >=105.2.3

###Compatibility
This code should work with .NET 4.5.1 and above, and with Xamarin frameworks for iOS, Mac, and Android.

###Sample Code
You can find a sample project in src/SchooxSharp.Sample.  It will guide you through making some basic requests.

###Testing
There is a unit test project; at the moment, all of the create/edit/delete tests are being ignored.  As such, they have not been tested against the API server.  We're waiting on a proper staging environment that we can execute these tests against.

###Model Variance
The Schoox API has some small quirks in the models.

For example, we reuse many models, despite the entire model not being populated.  Additionally, many models for New and Update are different than their counterparts.  You must check the documentation to know what to expect out of what will be populated in these models.  For ints and bools inside a model, they for the most part are all listed as nullable properties, this allows you to say myInt.HasValue and myInt.Value to determine whether or not the value is present.

Another example lives in the Course model, in particular the "Scope" property is an object.  In cases where there is just one element in scope, it will return a string.  In cases where there are more than one element, it will return an array of strings.  This makes it very difficult to parse reliably.

Another example lives in the Curriculum model, in some requests object Courses is an integer, and in others it's a List<Course> object.

###Bugs
Please submit any bugs to the bug section of this API and we'll look to address them as soon as we can.

###Parameters and Nullables/Optionals/Defaults
Functions with "optional" parameters are exactly that, you don't have to fill them in if you don't want to.  Some parameters are given the defaults that   They exist to let you know what you *must* provide, and what's optional.

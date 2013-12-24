# Portfolio.MVC

This is a portfolio project demonstrating how I typically would try to write a Microsoft MVC application, if
I ever get the opportunity to control all the things. (Yes, that's rare.)

## Prerequisites

- Visual Studio 2013
- SQL Express 2012, installed locally or aliased as `.\SQLExpress`
- Database catalog named `Portfolio_development`.

There's a database project in the solution and a schema compare all ready to go. Run the schema compare against
your database target, and you should be set.

## Running Tests

The unit tests are written in [NUnit](http://nunit.org/). You will need to have the NUnit GUI runner, or 
the ability to run the tests from within Visual Studio. I use [ReSharper](http://www.jetbrains.com/resharper/). 
A few of the tests will run against a local database, just to make sure that everything works as expected.

- Create a local database named `Portfolio_test`.
- From Visual Studio, execute a schema compare to update `Portfolio_test`.
- Run those tests! If you have [Psake](https://github.com/psake/psake) installed, you can run the tests from the command line with `psake NUnit`.

If you have any questions, please ask.

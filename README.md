log4netViewer
=============

A quick-n-dirty ASP.NET MVC application for viewing log4net logs stored in a SQL Server table.


Requirements
------------

* Visual Studio 2012 Professional or higher (may work with Express; have not tested)
* ASP.NET MVC 4
* A SQL Server database containing a log4net table ([Sample AdoNetAppender schema](http://logging.apache.org/log4net/release/config-examples.html#adonetappender-mssql))


Setup
-----

1.  Either clone the repository locally, or download the source code.
2.  Open log4netViewer.sln in Visual Studio.
3.  Modify log4netViewer.MvcWeb.Models.Log to match the schema of your log table.
4.  Edit the connection string in Web.config to point to your database instance.
5.  Hit F5 to launch the site in your debugger.

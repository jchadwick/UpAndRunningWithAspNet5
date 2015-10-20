# Up and Running With ASP.NET 5

Demo source code and links for Lynda.com Up and Running with ASP.NET 5 training course

## Course Links
* __[Download Visual Studio](https://www.visualstudio.com/)__
* __[Official ASP.NET 5 Release Roadmap](https://github.com/aspnet/Home/wiki/Roadmap)__

## Exercise File versions
* __1.0.0-beta4__ *(what is shown in the videos)*__:__ [Sample application code](https://github.com/jchadwick/UpAndRunningWithAspNet5/tree/beta4/AspNetBlog)
* __1.0.0-beta6__: [Sample application code](https://github.com/jchadwick/UpAndRunningWithAspNet5/tree/beta6/AspNetBlog)
* __1.0.0-beta7__: [Sample application code](https://github.com/jchadwick/UpAndRunningWithAspNet5/tree/beta7/AspNetBlog)
* __1.0.0-beta8__: [Sample application code](https://github.com/jchadwick/UpAndRunningWithAspNet5/tree/beta8/AspNetBlog)

## Release Notes

### beta4 to beta8  [(Full file comparison)](https://github.com/jchadwick/UpAndRunningWithAspNet5/compare/beta4...beta8)

__Updated Tooling__
* Download and install: [Microsoft.NET and Web Tools 2015 (Beta8)](http://www.microsoft.com/en-us/download/details.aspx?id=49442)

__Namespace/Library changes__  
* Hosting in IIS via the `Microsoft.AspNet.Server.IIS` package is no longer supported and has been discontinued
	* Replaced with [IIS 8.0 `httpPlatformHandler` module](http://www.iis.net/learn/extensions/httpplatformhandler) configured via `web.config`
* `Microsoft.Framework.ConfigurationModel` renamed to `Microsoft.Framework.Configuration`
* `Microsoft.Framework.Runtime` renamed to `Microsoft.Dnx.Runtime`

__API changes__  
* __Configuration__
	* *[Startup.cs: line 21]* Must use `ConfigurationBuilder` instead of `Configuration` to create configuration objects
	* *[Startup.cs: line 21]* New `ConfigurationBuilder` requires base path for configuration files;  inject `IApplicationEnvironment` into the `Startup` constructor *[Startup.cs: line 19]* and pass the value of `IApplicationEnvironment.ApplicationBasePath` into `IConfiguration.SetBasePath()`
	* *[Startup.cs: line 26]* Must call `.Build()` after adding configuration sources to generate configuration object 
* __Diagnostics__
	* *[Startup.cs: line 68]* `.UseErrorPage() ` middleware has been renamed to `.UseDeveloperExceptionPage()`
	* *[Startup.cs: line 72]* `.UseErrorHandler() ` middleware has been renamed to `.UseExceptionHandler()`
* __Entity Framework__
	* *[BlogDataContext.cs: line 36]* `ModelBuilder.ForSqlServer()` extension no longer provided/required - removed entire extraneous section
* __Identity__
	* *[AccountController.cs: line 58]* Synchronous version of `SignInManager.SignOut()` no longer offered - must use `.SignOutAync()`.  
	*Also converted the controller action to an async action, though this is not required*
	

### beta4 to beta7  [(Full file comparison)](https://github.com/jchadwick/UpAndRunningWithAspNet5/compare/beta4...beta7)

__Updated Tooling__
* Download and install: [Microsoft.NET and Web Tools 2015 (Beta7)](http://www.microsoft.com/en-us/download/details.aspx?id=48738)

__Namespace/Library changes__  
* `Microsoft.Framework.ConfigurationModel` renamed to `Microsoft.Framework.Configuration`
* `Microsoft.Framework.Runtime` renamed to `Microsoft.Dnx.Runtime`

__API changes__  
* __Configuration__
	* *[Startup.cs: line 21]* Must use `ConfigurationBuilder` instead of `Configuration` to create configuration objects
	* *[Startup.cs: line 21]* New `ConfigurationBuilder` requires base path for configuration files;  inject `IApplicationEnvironment` into the `Startup` constructor *[Startup.cs: line 19]* and call `IApplicationEnvironment.ApplicationBasePath` 
	* *[Startup.cs: line 26]* Must call `.Build()` after adding configuration sources to generate configuration object 
	* *[Startup.cs: lines 55, 65]* `IConfiguration.Get()` no longer offered - must use array indexer, which returns a string
* __Entity Framework__
	* *[BlogDataContext.cs: line 36]* `ModelBuilder.ForSqlServer()` extension no longer provided/required - removed entire extraneous section
* __Identity__
	* *[AccountController.cs: line 58]* Synchronous version of `SignInManager.SignOut()` no longer offered - must use `.SignOutAync()`.  
	*Also converted the controller action to an async action, though this is not required*
	

### beta4 to beta6  [(Full file comparison)](https://github.com/jchadwick/UpAndRunningWithAspNet5/compare/beta4...beta6)

__Namespace/Library changes__  
* `Microsoft.Framework.ConfigurationModel` renamed to `Microsoft.Framework.Configuration`

__API changes__  
* __Configuration__
	* *[Startup.cs: line 21]* Must use `ConfigurationBuilder` instead of `Configuration` to create configuration objects
	* *[Startup.cs: line 21]* New `ConfigurationBuilder` requires base path for configuration files;  inject `IApplicationEnvironment` into the `Startup` constructor *[Startup.cs: line 19]* and call `IApplicationEnvironment.ApplicationBasePath` 
	* *[Startup.cs: line 26]* Must call `.Build()` after adding configuration sources to generate configuration object 
	* *[Startup.cs: lines 55, 65]* `IConfiguration.Get<T>()` no longer offered - must use non-generic version, which returns a string
* __Entity Framework__
	* *[BlogDataContext.cs: line 36]* `ModelBuilder.ForSqlServer()` extension no longer provided/required - removed entire extraneous section
* __Identity__
	* *[AccountController.cs: line 58]* Synchronous version of `SignInManager.SignOut()` no longer offered - must use `.SignOutAync()`.  
	*Also converted the controller action to an async action, though this is not required*
# Up and Running With ASP.NET 5

Demo source code and links for Lynda.com Up and Running with ASP.NET 5 training course

## Course Links
* __[Download Visual Studio](https://www.visualstudio.com/)__
* __[Official ASP.NET 5 Release Roadmap](https://github.com/aspnet/Home/wiki/Roadmap)__

## Exercise File versions
* __1.0.0-beta4__ *(what is shown in the videos)*__:__ [Sample application code](https://github.com/jchadwick/UpAndRunningWithAspNet5/tree/beta4/AspNetBlog)
* __1.0.0-beta6__: [Sample application code](https://github.com/jchadwick/UpAndRunningWithAspNet5/tree/beta6/AspNetBlog)

## Release Notes

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
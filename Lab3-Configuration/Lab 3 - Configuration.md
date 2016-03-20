# Configuration

__Goodbye web.confg__

The new configuration model provides streamlined access to key/value based settings that can be retrieved from a variety of providers. Applications and frameworks can then access configured settings using the new Options pattern

## Basic Configuration

Add the following project references
````
    "Microsoft.Extensions.Configuration.FileProviderExtensions": "1.0.0-rc1-final",
    "Microsoft.Extensions.Configuration.Json": "1.0.0-rc1-final",
````

The out of the box configuration is a single appsettings.json file.  Add the following new appsettings.json
file to the root of your project.

````
{
  "AppSettings": {
    "SiteTitle": "ASPNET Lab 3"
  }
}
````

The add the following constructor and Configuration property to Startup.cs
````

public IConfigurationRoot Configuration { get; set; }
 
public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
                
            Configuration = builder.Build();
        }
````

Then update the hello world message to use the configuration file

````
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World! "+ Configuration["AppSettings:SiteTitle"]);
    });
````

## Environment Specific Configration

Add a second appsettings file called appsettings.Staging.json to the root of the project

````
{
  "AppSettings": {
    "SiteTitle": "Staging Settings Lab 3"
  }
}
````

Update the constructor to add an addition configuration line
````

 
public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);;
                
            Configuration = builder.Build();
        }
````

Set your environment to Staging and run
````
    export ASPNET_ENV=Staging
    dnx web
````

## Adding Environment Variables

* Create environment variable called ````AppSettingsSiteTitle````

Add following line to startup constructor
````
  builder.AddEnvironmentVariables();
````
 

## Options Pattern

The Options configuration pattern allows us to use POCO's as configuration objects.



## Bonues - User Secrets
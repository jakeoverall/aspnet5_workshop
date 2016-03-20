#Project.json

Take the Hello World lab and add some additional project references to it. 

## dependencies
This is the project references.  Unlike previous versions of .Net this section only shows the packages that
you have explicitly added, not all the packages required by those packages as well. This makes it
much easier to remove references that are no longer needed. 

This sections supports intellisense.  Update project.json to enable our project to load static files.


````
"Microsoft.AspNet.StaticFiles": "1.0.0-rc1-final",
````

Create a new folder called __wwwroot__ and add an empty index.html file to wwwroot

````
<html>
    
  <head>
      <title>Hello Html</title>
  </head>
<body>
   <h1>Hi from static html file</h1>
  </body>
 </html>
````

Update Startup.cs to use Static Files

````
 public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            
            app.UseStaticFiles();
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
````

* restart the web app: ```` dnx web ````
* browse to: http://localhost/index.html


## Adding Commands

  "commands": {
    "web": "Microsoft.AspNet.Server.Kestrel",
    "web2": "Microsoft.AspNet.Server.Kestrel --server.urls http://localhost:5001"
  },

## Frameworks

This section allows you to target different versions of the .Net Framework such as full or core. 
Since some of this in undergoing changes we're just going to point it out here but ignore for now

````
  "frameworks": {
    "dnx451": { },
    "dnxcore50": { }
  },
  ````
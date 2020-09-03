# Building blockchain API

## Setting up environment

Be sure to meet  the following requirements:

- Have Visual Studio Code installed
- Have latest version of C# extension for Visual Studio Code installed
- Have .NET Core SDK v3.1 or later installed

Move to the folder which will store the source for the __ASP .NET MVC__ application.

```bash
cd 2nd-module
dotnet new mvc -o BlockChain
code -r BlockChain
```

A dialog will be prompted asking the following: *Required assets to build and debug are missing from 'BlockChain'. Add them?*. Just select *Yes*.

The application runs at port 5001 by default.

Now let's move to __Models__ folder and create a few classes here:

- Transaction.cs
- Block.cs
- Node.cs

Now we have to link a class library to our solution. From our parent directory `BlockChain` let's run the following commands:

```bash
dotnet new sln
dotnet new classlib -o RSA
dotnet sln add BlockChain.csproj
dotnet sln add RSA/RSA.csproj
dotnet build
```

The `RSA` class library will have a few classes to:

- RSA.cs
- Wallet.cs

Also we have to add the __NBitcoin NuGet package__ to it, inside the RSA folder run the following command on terminal:

```bash
dotnet add package NBitcoin --version 5.0.53
```

Now we just have to add a reference in our `Blockchain` project to the `RSA` project. VS Code has a handy extension to perform it. From VS Code hit `Ctrl` + `P` and paste:

```txt
ext install adrianwilczynski.add-reference
```

Once installed right click on *BlockChain.csproj* file and click __Add Reference__. RSA will be displayed as an option, you must select it and hit Enter.

Back to the `Blockchain` project to add a new class under *Models* folder:

- CryptoCurrency.cs

And now it's time to add the __Newtonsoft.Json NuGet package__ to it, inside the Blockchain folder run the following command on terminal:

```bash
dotnet add package Newtonsoft.Json --version 12.0.3
```

It's time to prepare our Web API. So our solution `BlockChain` will have a new folder called *API* which will have one new file:

- BlockChainController.cs

Now we move to the implementation of help pages and API docs using Swagger. It is easy by adding the __Swashbuckle.AspNetCore NuGet package__ to our `BlockChain` solution. From the terminal run the following inside *BlockChain* folder:

```bash
dotnet add package Swashbuckle.AspNetCore --version 5.5.1
```

You can always check the packages installed on your solution by running:

```bash
dotnet list package
```

The project adopted recommendations of the [official MS docs for Swagger](https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio-code).

The next step is to enable CORS in the API.

Then go edit the methods *ConfigureServices(IServiceCollection services)* and *Configure(IApplicationBuilder app, IWebHostEnvironment env)* on the file:

- Startup.cs

Finally we have to adjust the frontend of the API. We've added the folders *blockchain* and *static* in the __wwwroot__ directory.

Adapt the file:

- HomeController.cs

Prepare the *Home* and *Shared* __Views__:

- CoinBase.cshtml
- Configure.cshtml
- Index.cshtml
- Layout.cshtml

The end result provides important screens to our API:

- At the endpoint `localhost:XXXXX/swagger` we can painlessly check out each endpoint and what they do, plus we can explore the schemas on our API.
- The *Mine* page presents a list of transactions to be added to next block and a list of transactions already registered on the blockchain.
- The *Configure* page is where we register nodes to our blockchain network by providing the miners URL, and see a list of nodes already added.
- From the *Coinbase* page we are able to visualize the existing blocks on the blockchain.

To conclude our API, we will demonstrate how other nodes can join our network.

So first it's necessary to clone the project ___2nd-module__ and renamete it. Let's say ___2nd-module-node02__.

In the cloned solution, change the default debug port in order to avoid conflict when running the projects simultaneously. Inside __BlockChain__ solution, move to *Properties* ➔ *lauchSettings.json* and change necessary URLs.

The next step e to change lines __30__ and __31__ on *Models* ➔ *CryptoCurrency.cs*, by replacing the variables values from the hard-coded strings, to the commented code next they.

Now with the two projects running, from the original __2nd-module__ API, move to *Configure* ➔ *Add blockchain nodes* and paste the URL from the miner project API __2nd-module-node02__. This is how we add miners to this network.

Next step is to prove that the consensus is working properly, we repeat the proccess above but from the freshly added miner URL. After pasting the URL of the miner from __2nd-module__ and refreshing the transactions on the main page, we see that the longest chain will win. Always. That's because of our `ResolveConflicts()` method. To run this method navigate to the `/swagger` endpoint and execute `/nodes/resolve` call.

## Illustrations

### Project Files Structure

📦2nd-module  
 ┣ 📂.vscode  
 ┃ ┣ 📜launch.json  
 ┃ ┗ 📜tasks.json  
 ┣ 📂BlockChain  
 ┃ ┣ 📂.vscode  
 ┃ ┃ ┣ 📜launch.json  
 ┃ ┃ ┗ 📜tasks.json  
 ┃ ┣ 📂API  
 ┃ ┃ ┗ 📜BlockChainController.cs  
 ┃ ┣ 📂Controllers  
 ┃ ┃ ┗ 📜HomeController.cs  
 ┃ ┣ 📂Models  
 ┃ ┃ ┣ 📜Block.cs  
 ┃ ┃ ┣ 📜CryptoCurrency.cs  
 ┃ ┃ ┣ 📜ErrorViewModel.cs  
 ┃ ┃ ┣ 📜Node.cs  
 ┃ ┃ ┗ 📜Transaction.cs  
 ┃ ┣ 📂Properties  
 ┃ ┃ ┗ 📜launchSettings.json  
 ┃ ┣ 📂Views  
 ┃ ┃ ┣ 📂Home  
 ┃ ┃ ┃ ┣ 📜CoinBase.cshtml  
 ┃ ┃ ┃ ┣ 📜Configure.cshtml  
 ┃ ┃ ┃ ┣ 📜Index.cshtml  
 ┃ ┃ ┃ ┗ 📜Privacy.cshtml  
 ┃ ┃ ┣ 📂Shared  
 ┃ ┃ ┃ ┣ 📜Error.cshtml  
 ┃ ┃ ┃ ┣ 📜_Layout.cshtml  
 ┃ ┃ ┃ ┗ 📜_ValidationScriptsPartial.cshtml  
 ┃ ┃ ┣ 📜_ViewImports.cshtml  
 ┃ ┃ ┗ 📜_ViewStart.cshtml  
 ┃ ┣ 📂bin  
 ┃ ┃ ┗ 📂Debug  
 ┃ ┃ ┃ ┗ 📂netcoreapp3.1  
 ┃ ┃ ┃ ┃ ┣ 📂Properties  
 ┃ ┃ ┃ ┃ ┃ ┗ 📜launchSettings.json  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.Views.dll  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.Views.pdb  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.deps.json  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.dll  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.pdb  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.runtimeconfig.dev.json  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.runtimeconfig.json  
 ┃ ┃ ┃ ┃ ┣ 📜Microsoft.OpenApi.dll  
 ┃ ┃ ┃ ┃ ┣ 📜NBitcoin.dll  
 ┃ ┃ ┃ ┃ ┣ 📜Newtonsoft.Json.dll  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.dll  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.pdb  
 ┃ ┃ ┃ ┃ ┣ 📜Swashbuckle.AspNetCore.Swagger.dll  
 ┃ ┃ ┃ ┃ ┣ 📜Swashbuckle.AspNetCore.  SwaggerGen.dll  
 ┃ ┃ ┃ ┃ ┣ 📜Swashbuckle.AspNetCore.SwaggerUI.dll  
 ┃ ┃ ┃ ┃ ┣ 📜appsettings.Development.json  
 ┃ ┃ ┃ ┃ ┗ 📜appsettings.json  
 ┃ ┣ 📂obj  
 ┃ ┃ ┣ 📂Debug  
 ┃ ┃ ┃ ┗ 📂netcoreapp3.1  
 ┃ ┃ ┃ ┃ ┣ 📂Razor  
 ┃ ┃ ┃ ┃ ┃ ┗ 📂Views  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📂Home  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜CoinBase.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜Configure.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜Index.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜Privacy.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📂Shared  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜Error.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜_Layout.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜_ValidationScriptsPartial.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜_ViewImports.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜_ViewStart.cshtml.g.cs  
 ┃ ┃ ┃ ┃ ┣ 📂staticwebassets  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜BlockChain.StaticWebAssets.Manifest.cache  
 ┃ ┃ ┃ ┃ ┃ ┗ 📜BlockChain.StaticWebAssets.xml  
 ┃ ┃ ┃ ┃ ┣ 📜.NETCoreApp,Version=v3.1.AssemblyAttributes.cs  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.AssemblyInfo.cs  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.AssemblyInfoInputs.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.MvcApplicationPartsAssemblyInfo.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.MvcApplicationPartsAssemblyInfo.cs  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.RazorAssemblyInfo.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.RazorAssemblyInfo.cs  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.RazorCoreGenerate.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.RazorTargetAssemblyInfo.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.RazorTargetAssemblyInfo.cs  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.TagHelpers.input.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.TagHelpers.output.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.Views.dll  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.Views.pdb  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.assets.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.csproj.CopyComplete  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.csproj.CoreCompileInputs.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.csproj.FileListAbsolute.txt  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.csprojAssemblyReference.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.dll  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.genruntimeconfig.cache  
 ┃ ┃ ┃ ┃ ┣ 📜BlockChain.pdb  
 ┃ ┃ ┃ ┃ ┗ 📜project.razor.json  
 ┃ ┃ ┣ 📜BlockChain.csproj.nuget.dgspec.json  
 ┃ ┃ ┣ 📜BlockChain.csproj.nuget.g.props  
 ┃ ┃ ┣ 📜BlockChain.csproj.nuget.g.targets  
 ┃ ┃ ┣ 📜project.assets.json  
 ┃ ┃ ┗ 📜project.nuget.cache  
 ┃ ┣ 📂wwwroot  
 ┃ ┃ ┣ 📂blockchain  
 ┃ ┃ ┃ ┗ 📂stylesheets  
 ┃ ┃ ┃ ┃ ┣ 📂lib  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-horizon.css  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-theme.min.css  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.min.css  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜ie10-viewport-bug-workaround.css  
 ┃ ┃ ┃ ┃ ┃ ┗ 📜ladda-themeless.min.css  
 ┃ ┃ ┃ ┃ ┗ 📜blockchain.css  
 ┃ ┃ ┣ 📂css  
 ┃ ┃ ┃ ┗ 📜site.css  
 ┃ ┃ ┣ 📂js  
 ┃ ┃ ┃ ┗ 📜site.js  
 ┃ ┃ ┣ 📂lib  
 ┃ ┃ ┃ ┣ 📂bootstrap  
 ┃ ┃ ┃ ┃ ┣ 📂dist  
 ┃ ┃ ┃ ┃ ┃ ┣ 📂css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-grid.css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-grid.css.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-grid.min.css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-grid.min.css.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-reboot.css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-reboot.css.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-reboot.min.css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap-reboot.min.css.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.css.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.min.css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜bootstrap.min.css.map  
 ┃ ┃ ┃ ┃ ┃ ┗ 📂js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.bundle.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.bundle.js.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.bundle.min.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.bundle.min.js.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.js.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.min.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜bootstrap.min.js.map  
 ┃ ┃ ┃ ┃ ┗ 📜LICENSE  
 ┃ ┃ ┃ ┣ 📂jquery  
 ┃ ┃ ┃ ┃ ┣ 📂dist  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜jquery.js  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜jquery.min.js  
 ┃ ┃ ┃ ┃ ┃ ┗ 📜jquery.min.map  
 ┃ ┃ ┃ ┃ ┗ 📜LICENSE.txt  
 ┃ ┃ ┃ ┣ 📂jquery-validation  
 ┃ ┃ ┃ ┃ ┣ 📂dist  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜additional-methods.js  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜additional-methods.min.js  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜jquery.validate.js  
 ┃ ┃ ┃ ┃ ┃ ┗ 📜jquery.validate.min.js  
 ┃ ┃ ┃ ┃ ┗ 📜LICENSE.md  
 ┃ ┃ ┃ ┗ 📂jquery-validation-unobtrusive  
 ┃ ┃ ┃ ┃ ┣ 📜LICENSE.txt  
 ┃ ┃ ┃ ┃ ┣ 📜jquery.validate.unobtrusive.js  
 ┃ ┃ ┃ ┃ ┗ 📜jquery.validate.unobtrusive.min.js  
 ┃ ┃ ┣ 📂static  
 ┃ ┃ ┃ ┣ 📂css  
 ┃ ┃ ┃ ┃ ┗ 📜custom.css  
 ┃ ┃ ┃ ┗ 📂vendor  
 ┃ ┃ ┃ ┃ ┣ 📂DataTables  
 ┃ ┃ ┃ ┃ ┃ ┣ 📂css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📂DataTables-1.10.16  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📂images  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜sort_asc.png  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜sort_asc_disabled.png  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜sort_both.png  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜sort_desc.png  
 ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜sort_desc_disabled.png  
 ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜datatables.min.css  
 ┃ ┃ ┃ ┃ ┃ ┗ 📂js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜datatables.min.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜ellipsis.js  
 ┃ ┃ ┃ ┃ ┣ 📂bootstrap  
 ┃ ┃ ┃ ┃ ┃ ┣ 📂css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.css.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.min.css  
 ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜bootstrap.min.css.map  
 ┃ ┃ ┃ ┃ ┃ ┗ 📂js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.bundle.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.bundle.js.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.bundle.min.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.bundle.min.js.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.js.map  
 ┃ ┃ ┃ ┃ ┃ ┃ ┣ 📜bootstrap.min.js  
 ┃ ┃ ┃ ┃ ┃ ┃ ┗ 📜bootstrap.min.js.map  
 ┃ ┃ ┃ ┃ ┗ 📂jquery  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜jquery.js  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜jquery.min.js  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜jquery.min.map  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜jquery.slim.js  
 ┃ ┃ ┃ ┃ ┃ ┣ 📜jquery.slim.min.js  
 ┃ ┃ ┃ ┃ ┃ ┗ 📜jquery.slim.min.map  
 ┃ ┃ ┗ 📜favicon.ico  
 ┃ ┣ 📜BlockChain.csproj  
 ┃ ┣ 📜Program.cs  
 ┃ ┣ 📜Startup.cs  
 ┃ ┣ 📜appsettings.Development.json  
 ┃ ┗ 📜appsettings.json  
 ┣ 📂RSA  
 ┃ ┣ 📂bin  
 ┃ ┃ ┗ 📂Debug  
 ┃ ┃ ┃ ┗ 📂netstandard2.0  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.deps.json  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.dll  
 ┃ ┃ ┃ ┃ ┗ 📜RSA.pdb  
 ┃ ┣ 📂obj  
 ┃ ┃ ┣ 📂Debug  
 ┃ ┃ ┃ ┗ 📂netstandard2.0  
 ┃ ┃ ┃ ┃ ┣ 📜.NETStandard,Version=v2.0.AssemblyAttributes.cs  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.AssemblyInfo.cs  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.AssemblyInfoInputs.cache  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.assets.cache  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.csproj.CoreCompileInputs.cache  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.csproj.FileListAbsolute.txt  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.csprojAssemblyReference.cache  
 ┃ ┃ ┃ ┃ ┣ 📜RSA.dll  
 ┃ ┃ ┃ ┃ ┗ 📜RSA.pdb  
 ┃ ┃ ┣ 📜RSA.csproj.nuget.dgspec.json  
 ┃ ┃ ┣ 📜RSA.csproj.nuget.g.props  
 ┃ ┃ ┣ 📜RSA.csproj.nuget.g.targets  
 ┃ ┃ ┣ 📜project.assets.json  
 ┃ ┃ ┗ 📜project.nuget.cache  
 ┃ ┣ 📜RSA.cs  
 ┃ ┣ 📜RSA.csproj  
 ┃ ┗ 📜Wallet.cs  
 ┣ 📜.gitignore  
 ┣ 📜2nd-module.sln  
 ┗ 📜README.md  
 
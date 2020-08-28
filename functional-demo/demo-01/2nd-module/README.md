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

Finally we have to adjust the frontend of the API. Adapt the file:

- HomeController.cs (NOT READY!)

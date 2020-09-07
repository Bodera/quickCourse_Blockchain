# Building blockchain client application

## Setting up environment

Be sure to meet  the following requirements:

- Have Visual Studio Code installed
- Have latest version of C# extension for Visual Studio Code installed
- Have .NET Core SDK v3.1 or later installed

__Advising__: This project interacts with the project built in previous module, so is a must to have the 3 projetcs (BlockChain, BlockChainClient, RSA) inside the same solution.

Commands to create a new __ASP .NET MVC__ application:

```bash
cd 3rd-module
dotnet new mvc -o BlockChainClient
code -r BlockChainClient/
```

A dialog will be prompted asking the following: *Required assets to build and debug are missing from 'BlockChainClient'. Add them?*. Just select *Yes*.

This solution will also needs the `RSA` class library, so let's start the set up. From parent directory `3rd-module` run the following commands:

```bash
mkdir RSA
dotnet new sln
dotnet new classlib -o RSA
dotnet sln add BlockChainClient/BlockChainClient.csproj
dotnet sln add RSA/RSA.csproj
dotnet build
```

The following `RSA` classes will be reused:

- Wallet.cs
- RSA.cs

Don't forget to add __NBitcoin NuGet package__ to the `RSA` class library:

```bash
cd RSA/
dotnet add package NBitcoin --version 5.0.53
```

If you already have the [.NET Core Add Reference](https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.add-reference) VS Code extension installed, right click on the *BlockChainClient.csproj* file and select the option __Add Reference__. RSA will be displayed as an option, check the RSA option and hit Enter.

The following classes will compose the __Models__ folder in the BlockChainClient project:

- Block.cs
- Transaction.cs
- TransactionClient.cs

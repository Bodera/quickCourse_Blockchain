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
code -r BlockChainClient
```

A dialog will be prompted asking the following: *Required assets to build and debug are missing from 'BlockChain'. Add them?*. Just select *Yes*.

This solution will also needs the `RSA` class library, so let's start the set up. From parent directory `BlockChainClient` run the following commands:

```bash
mkdir RSA
dotnet new sln
dotnet new classlib -o RSA
dotnet sln add BlockChainClient.csproj
dotnet sln add RSA/RSA.csproj
dotnet build
```

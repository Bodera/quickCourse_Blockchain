# Building blockchain online shopping website

Create a new ASP.NET Core Web Application by following the following steps:

```txt
mkdir EcommerceApp
dotnet new mvc
```

Adicione as seguintes classes na pasta __Models__:

- Block
- Transaction
- User
- Video
- Product

Counting the *ErrorViewModel.cs* the __Models__ folder should have 6 classes.

We shoul add some __wwwroot__ assets:

- images/
- js/qrcode.js
- js/qrcode.min.js

To enable "real time" web communication to our demo, we will add the `SignalR` NuGet library. By real time we mean to enable remote procedures call between server and client. Feel free to [read the docs](https://docs.microsoft.com/pt-br/aspnet/core/signalr/introduction?view=aspnetcore-3.1).

From our directory `EcommerceApp/` run:

```bash
> dotnet add package Microsoft.AspNetCore.SignalR --version 1.1.0
```

__Tip__:

Run `dotnet list package` in order to verify if installation was suceed.

Now lets add the `signalr/` folder into `lib/` inside `wwwroot/`. Run:

```bash
> dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

Then we should be able to get the signalr `.js` scripts using LibMan tool.

```bash
> libman install @microsoft/signalr@latest -p unpkg -d wwwroot/js/signalr --files dist/browser/signalr.js --files dist/browser/signalr.min.js
```

To properly configure SignalR, a few modifications need to be performed:

- Hubs/ChatHub.cs
- Startup.cs

At this moment we should test if our project until here works as we expect.

```txt
http://localhost:9001/
http://localhost:9001/Home/ApiCall?ip=::1&id=3
```

Check validation scenario document here.

The next step is to add another view to generate valid QR-Codes. Change the following files:

- HomeController.cs
- QrGenerate.cshtml
- _Layout.cshtml

Now it's time to implement the payment API.

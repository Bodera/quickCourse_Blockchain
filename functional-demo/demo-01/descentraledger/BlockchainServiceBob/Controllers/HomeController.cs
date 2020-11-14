using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlockchainServiceBob.Models;
using BlockchainServiceBob.API;

namespace BlockchainServiceBob.Controllers
{ 
    public class HomeController : Controller
    {
        private static CryptoCurrency blockchain = BlockchainServiceBobController.blockchain; //new CryptoCurrency();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //information to be displayed on the Index view
            List<Transaction> transactions = blockchain.GetTransactions();
            ViewBag.Transactions = transactions;

            List<Block> blocks = blockchain.GetBlocks();
            ViewBag.Blocks = blocks;

            return View();
        }
        public IActionResult Mine()
        {
            blockchain.Mine();

            return RedirectToAction("Index");
        }
        public IActionResult Configure()
        {
            return View(blockchain.GetNodes());
        }
        public IActionResult RegisterNodes(string nodes)
        {
            string[] node = nodes.Split(',');
            blockchain.RegisterNodes(node);

            return RedirectToAction("Configure");
        }
        public IActionResult CoinBase()
        {
            List<Block> blocks = blockchain.GetBlocks();
            ViewBag.Blocks = blocks;

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

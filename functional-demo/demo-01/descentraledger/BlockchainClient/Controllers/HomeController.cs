﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlockchainClient.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace BlockchainClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MakeTransaction()
        {
            return View();
        }

        public IActionResult ViewTransaction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewTransaction(string node_url)
        {
            var url = new Uri(node_url + "/chain");
            ViewBag.Blocks = GetChain(url);
            
            return View();
        }

        public IActionResult WalletTransaction()
        {   
            return View(new List<Transaction>());
        }

        [HttpPost]
        public IActionResult WalletTransaction(string publicKey)
        {
            var url = new Uri("http://localhost:8001" + "/chain");
            var blocks = GetChain(url);
            ViewBag.publickey= publicKey;
            //ViewBag.Transactions = TransactionByAddress(publicKey, blocks);

            return View(TransactionByAddress(publicKey, blocks));
        }

        //method that returns the whole blockchain
        private List<Block> GetChain(Uri url) // the url address of the miner
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = new
                {
                    chain = new List<Block>(),
                    length = 0
                };

                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var data = JsonConvert.DeserializeAnonymousType(json, model);

                return data.chain;
            }

            return null;
        }

        private List<Transaction> TransactionByAddress(string ownerAddress, List<Block> chain)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (var block in chain.OrderByDescending(x => x.Index))
            {
                var ownerTransactions = block.Transactions.Where(x => x.Sender == ownerAddress || x.Recipient == ownerAddress).ToList();
                transactions.AddRange(ownerTransactions);
            }

            return transactions;
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

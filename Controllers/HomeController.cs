﻿using bookshelf_web_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace bookshelf_web_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _httpClient = factory.CreateClient("myApi");
        }

        public async Task<IActionResult> Index()
        {
            BookResultModel bookResult = new BookResultModel();
            string errorString;
            try
            {
                bookResult = await _httpClient.GetFromJsonAsync<BookResultModel>("new");
                errorString = null;
            }
            catch (Exception ex)
            {
                errorString = $"There was an error getting newest books!. Error: {ex.Message}";
            }
            return View(bookResult);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Books()
        {
            return View(new BookResultModel());
        }
        [HttpPost]
        public async Task<IActionResult> Books(string search)
        {
            BookResultModel bookResult = new BookResultModel();
            string errorString;

            try
            {
                bookResult = await _httpClient.GetFromJsonAsync<BookResultModel>($"search/{search}");
                errorString = null;
            }
            catch (Exception ex)
            {
                errorString = $"There was an error!. Error: {ex.Message}";
            }



            return View(bookResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

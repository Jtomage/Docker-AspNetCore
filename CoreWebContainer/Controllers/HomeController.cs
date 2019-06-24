using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using CoreWebContainer.Models;

namespace CoreWebContainer.Controllers
{
	public class HomeController : Controller
	{
		private HttpClient client = new HttpClient();

		public IActionResult Index()
		{
			try
			{
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				//HttpResponseMessage response = RetriveData("http://localhost:55910/api/Values").Result;
				HttpResponseMessage response = RetriveData("https://localhost:44355/api/Values").Result;
				if (response.IsSuccessStatusCode)
				{
					string s = response.Content.ReadAsStringAsync().Result;
					ViewBag.JsonResponse = s;
				}
			}
			catch(Exception e)
			{
				ViewBag.JsonResponse = "Error: " + e.ToString();
			}

			return View();
		}

		private async Task<HttpResponseMessage> RetriveData(string url)
		{ 
			HttpResponseMessage response = await client.GetAsync(url);
			return response;
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

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

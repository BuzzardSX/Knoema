using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeoService.Interfaces;

namespace WeoClient.Pages
{
	public class IndexModel : PageModel
	{
		readonly WeoHttpClient _weo;
		public IEnumerable<string> Countries { get; set; }
		public IndexModel(WeoHttpClient weo) => _weo = weo;
		public async Task OnGet() => Countries = await _weo.GetAllCountries();
		public async Task<IActionResult> OnGetViewAsync(string country)
		{
			var model = await _weo.GetView(country);
			return Partial("_View", model);
		}
	}
}

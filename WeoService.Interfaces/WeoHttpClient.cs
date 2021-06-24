using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using WeoClient.ViewModels;

namespace WeoService.Interfaces
{
	public class WeoHttpClient
	{
		public HttpClient Client { get; }
		public WeoHttpClient(HttpClient client) => Client = client;
		public async Task<IEnumerable<string>> GetAllCountries() => await Client
			.GetFromJsonAsync<IEnumerable<string>>("weo/allCountries");
		public async Task<ViewViewModel> GetView(string country) => await Client
			.GetFromJsonAsync<ViewViewModel>($"weo/view?country={country}");
	}
}

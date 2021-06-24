using System.Collections.Generic;

namespace WeoClient.ViewModels
{
	public class ViewViewModel
	{
		public string Country { get; set; }
		public double? CountryCode { get; set; }
		public string ISO { get; set; }
		public IEnumerable<SubjectGroupViewModel> SubjectGroups { get; set; }
	}
}

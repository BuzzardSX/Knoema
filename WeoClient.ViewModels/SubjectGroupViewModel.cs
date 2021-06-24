using System.Collections.Generic;

namespace WeoClient.ViewModels
{
	public class SubjectGroupViewModel
	{
		public string SubjectDescriptor { get; set; }
		public int Count { get; set; }
		public IEnumerable<SubjectGroupWeoViewModel> Weos { get; set; }
	}
}

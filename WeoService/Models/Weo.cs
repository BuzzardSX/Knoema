using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeoService.Models
{
	[Keyless]
	public class Weo
	{
		[Column("WEO Country Code")]
		public double? CountryCode { get; set; }
		public string ISO { get; set; }
		[Column("WEO Subject Code")]
		public string SubjectCode { get; set; }
		public string Country { get; set; }
		[Column("Subject Descriptor")]
		public string SubjectDescriptor { get; set; }
		[Column("Subject Notes")]
		public string SubjectNotes { get; set; }
		public string Units { get; set; }
		public string Scale { get; set; }
		[Column("Country/series-Specific Notes")]
		public string SpecificNotes { get; set; }
		[Column("Estimates Start After")]
		public double? EstimatesStartAfter { get; set; }
		public double? TotalProfit { get; set; }
	}
}

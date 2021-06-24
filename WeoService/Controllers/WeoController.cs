using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeoClient.ViewModels;
using WeoService.Models;

namespace WeoService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeoController : ControllerBase
	{
		readonly ApplicationContext _app;
		public WeoController(ApplicationContext app) => _app = app;
		[HttpGet("allCountries")]
		public async Task<ActionResult<IEnumerable<string>>> GetAllCountries() => await _app.Weos
			.Select(w => w.Country)
			.Distinct()
			.ToListAsync();
		[HttpGet("view")]
		public async Task<ActionResult<ViewViewModel>> GetView(string country)
		{
			var weos = await _app.Weos
				.FromSqlRaw(@"SELECT
					[WEO Country Code],
					[ISO],
					[WEO Subject Code],
					[Country],
					[Subject Descriptor],
					[Subject Notes],
					[Units],
					[Scale],
					[Country/series-Specific Notes],
					[Estimates Start After],
					(
						IsNull([1980], 0) + IsNull([1981], 0) + IsNull([1982], 0) + IsNull([1983], 0) + IsNull([1984], 0)
						+ IsNull([1985], 0) + IsNull([1986], 0) + IsNull([1987], 0) + IsNull([1988], 0) + IsNull([1989], 0)
						+ IsNull([1990], 0) + IsNull([1991], 0) + IsNull([1992], 0) + IsNull([1993], 0) + IsNull([1994], 0)
						+ IsNull([1995], 0) + IsNull([1996], 0) + IsNull([1997], 0) + IsNull([1998], 0) + IsNull([1999], 0)
						+ IsNull([2000], 0) + IsNull([2001], 0) + IsNull([2002], 0) + IsNull([2003], 0) + IsNull([2004], 0)
						+ IsNull([2005], 0) + IsNull([2006], 0) + IsNull([2007], 0) + IsNull([2008], 0) + IsNull([2009], 0)
						+ IsNull([2010], 0) + IsNull([2011], 0) + IsNull([2012], 0) + IsNull([2013], 0) + IsNull([2014], 0)
						+ IsNull([2015], 0) + IsNull([2016], 0) + IsNull([2017], 0) + IsNull([2018], 0) + IsNull([2019], 0)
						+ IsNull([2020], 0) + IsNull([2021], 0) + IsNull([2022], 0) + IsNull([2023], 0) + IsNull([2024], 0)
					) AS [TotalProfit]
					FROM Weos")
				.Where(w => w.Country == country)
				.ToListAsync();
			var groups = weos
				.GroupBy(
					keySelector: w => w.SubjectDescriptor,
					elementSelector: w => new
					{
						w.SubjectCode,
						w.SubjectNotes,
						w.Units,
						w.Scale,
						w.SpecificNotes,
						w.EstimatesStartAfter,
						w.TotalProfit
					},
					resultSelector: (d, ws) => new SubjectGroupViewModel
					{
						SubjectDescriptor = d,
						Count = ws.Count(),
						Weos = ws.Select(w => new SubjectGroupWeoViewModel
						{
							SubjectCode = w.SubjectCode,
							SubjectNotes = w.SubjectNotes,
							Units = w.Units,
							Scale = w.Scale,
							SpecificNotes = w.SpecificNotes,
							EstimatesStartAfter = w.EstimatesStartAfter,
							TotalProfit = w.TotalProfit
						})
					});
			return new ViewViewModel
			{
				Country = country,
				CountryCode = weos.First().CountryCode,
				ISO = weos.First().ISO,
				SubjectGroups = groups
			};
		}
	}
}

using System.Collections.Generic;

namespace Project.Website.Components.Portfolio
{
	public class PortfolioListingModel : ComponentModel
	{
		public IEnumerable<PortfolioItemModel> PortfolioListingItemModels { get; set; }
		public string ViewProjectText { get; set; }
		public string ItemClass { get; set; }
		public bool ShowPagination { get; set; }
	}
}
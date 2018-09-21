using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Portfolio
{
	public class PortfolioSectionController : PortfolioListingController
	{
		public virtual ActionResult Index()
		{
			return ThreeColumn();
		}

		protected override PortfolioListingModel GetModel(Item actionItem, int imageWidth, int imageHeight)
		{
			return new PortfolioListingModel
			{
				PortfolioListingItemModels = _portfolioRepository.GetSelectedPortfolioItems(actionItem, imageWidth, imageHeight),
			};
		}
	}
}
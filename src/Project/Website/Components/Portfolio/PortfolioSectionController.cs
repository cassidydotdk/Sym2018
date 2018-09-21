using System.Web.Mvc;
using Sitecore.Data.Fields;
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
			MultilistField listField = actionItem.Fields["Portfolio Section Items"];
			return new PortfolioListingModel
			{
				PortfolioListingItemModels = _portfolioRepository.GetPortfolioItemsFromMultilist(listField, imageWidth, imageHeight),
			};
		}
	}
}
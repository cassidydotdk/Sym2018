using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Portfolio
{
	public class PortfolioListingController : ComponentController
	{
		private readonly PortfolioRepository _portfolioRepository;

		public PortfolioListingController()
		{
			_portfolioRepository = new PortfolioRepository();
		}

		public virtual ActionResult OneColumn()
		{
			return Index("Portfolio Listing Full Width", null, 700, 300);
		}

		public virtual ActionResult TwoColumn()
		{
			return Index("Portfolio Listing Multi Column", "col-lg-6 portfolio-item", 700, 400);
		}

		public virtual ActionResult ThreeColumn()
		{
			return Index("Portfolio Listing Multi Column", "col-lg-4 col-sm-6 portfolio-item", 700, 400);
		}

		public virtual ActionResult FourColumn()
		{
			return Index("Portfolio Listing Multi Column", "col-lg-3 col-md-4 col-sm-6 portfolio-item", 700, 400);
		}

		public virtual ActionResult Index(string viewVariant, string className, int imageWidth, int imageHeight)
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem, imageWidth, imageHeight);
				model.ItemClass = className;
				return View(GetViewName(viewVariant), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual PortfolioListingModel GetModel(Item actionItem, int imageWidth, int imageHeight)
		{
			return new PortfolioListingModel
			{
				PortfolioListingItemModels = _portfolioRepository.GetPortfolioItems(actionItem, imageWidth, imageHeight, 0, 5),
				ViewProjectText = actionItem["Portfolio Listing View Project Text"]
			};
		}
	}
}
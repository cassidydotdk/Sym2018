using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Project.Website.Components.Portfolio
{
	public class PortfolioSectionController : ComponentController
	{
		protected readonly PortfolioRepository _portfolioRepository;

		public PortfolioSectionController() :this(new PortfolioRepository()) { }

		public PortfolioSectionController(PortfolioRepository portfolioRepository)
		{
			_portfolioRepository = portfolioRepository;
		}

		public virtual ActionResult Index()
		{
			return Render("Portfolio Listing Multi Column", "col-lg-4 col-sm-6 portfolio-item", 700, 400);
		}

		public virtual ActionResult Render(string viewVariant, string className, int imageWidth, int imageHeight)
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

		protected PortfolioListingModel GetModel(Item actionItem, int imageWidth, int imageHeight)
		{
			MultilistField listField = actionItem.Fields["Portfolio Section Items"];
			return new PortfolioListingModel
			{
				PortfolioListingItemModels = _portfolioRepository.GetPortfolioItemsFromMultilist(listField, imageWidth, imageHeight),
			};
		}
	}
}
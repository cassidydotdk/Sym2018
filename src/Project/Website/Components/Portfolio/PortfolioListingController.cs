using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Portfolio
{
	public class PortfolioListingController : ComponentController
	{
		public virtual ActionResult OneColumn()
		{
			return Index("Full Width Portfolio Listing");
		}

		public virtual ActionResult TwoColumn()
		{
			return Index("2 Column Portfolio Listing");
		}

		public virtual ActionResult ThreeColumn()
		{
			return Index("3 Column Portfolio Listing");
		}

		public virtual ActionResult FourColumn()
		{
			return Index("4 Column Portfolio Listing");
		}

		public virtual ActionResult Index(string viewVariant)
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName(viewVariant), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual PortfolioListingModel GetModel(Item actionItem)
		{
			return new PortfolioListingModel();
		}
	}
}
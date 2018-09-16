using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.PortfolioItem
{
	public class PortfolioItemController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Portfolio Item"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual PortfolioItemModel GetModel(Item actionItem)
		{
			return new PortfolioItemModel();
		}
	}
}
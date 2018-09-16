using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.PortfolioSection
{
	public class PortfolioSectionController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Portfolio Section"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual PortfolioSectionModel GetModel(Item actionItem)
		{
			return new PortfolioSectionModel();
		}
	}
}
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.TopNavigation
{
	public class TopNavigationController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Top Navigation"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual TopNavigationModel GetModel(Item actionItem)
		{
			return new TopNavigationModel();
		}
	}
}
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.PriceOptions
{
	public class PriceOptionsController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Price Options"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual PriceOptionsModel GetModel(Item actionItem)
		{
			return new PriceOptionsModel();
		}
	}
}
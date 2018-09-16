using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Features
{
	public class FeaturesController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Features"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual FeaturesModel GetModel(Item actionItem)
		{
			return new FeaturesModel();
		}
	}
}
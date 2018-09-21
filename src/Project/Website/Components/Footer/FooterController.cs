using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Footer
{
	public class FooterController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Footer"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual FooterModel GetModel(Item actionItem)
		{
			return new FooterModel
			{
				Text = actionItem["Footer Text"],
			};
		}
	}
}
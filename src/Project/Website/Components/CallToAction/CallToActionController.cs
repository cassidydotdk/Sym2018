using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.CallToAction
{
	public class CallToActionController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Call to Action Section"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual CallToActionModel GetModel(Item actionItem)
		{
			return new CallToActionModel();
		}
	}
}
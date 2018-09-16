using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Header
{
	public class HeaderController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Header"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual HeaderModel GetModel(Item actionItem)
		{
			return new HeaderModel();
		}
	}
}
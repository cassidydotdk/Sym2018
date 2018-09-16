using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Breadcrumb
{
	public class BreadcrumbController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Breadcrumb"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual BreadcrumbModel GetModel(Item actionItem)
		{
			return new BreadcrumbModel();
		}
	}
}
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Sidebar
{
	public class SidebarController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Sidebar"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual SidebarModel GetModel(Item actionItem)
		{
			return new SidebarModel();
		}
	}
}
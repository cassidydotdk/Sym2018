using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.IntroContent
{
	public class IntroContentController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Intro Content"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual IntroContentModel GetModel(Item actionItem)
		{
			return new IntroContentModel();
		}
	}
}
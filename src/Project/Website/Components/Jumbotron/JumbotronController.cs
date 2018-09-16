using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Jumbotron
{
	public class JumbotronController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Jumbotron"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual JumbotronModel GetModel(Item actionItem)
		{
			return new JumbotronModel();
		}
	}
}
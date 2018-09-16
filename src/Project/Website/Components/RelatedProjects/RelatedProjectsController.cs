using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.RelatedProjects
{
	public class RelatedProjectsController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Related Projects"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual RelatedProjectsModel GetModel(Item actionItem)
		{
			return new RelatedProjectsModel();
		}
	}
}
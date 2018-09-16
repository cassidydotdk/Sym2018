using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.HeadlineWithSubheading
{
	public class HeadlineWithSubheadingController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Heading with Subheading"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual HeadlineWithSubheadingModel GetModel(Item actionItem)
		{
			int.TryParse(actionItem["Heading Level"], out var level);

			return new HeadlineWithSubheadingModel()
			{
				HeadingLevel = level,
				Heading = RenderField(actionItem, "Heading"),
				Subheading = RenderField(actionItem, "Subheading"),
			};
		}
	}
}
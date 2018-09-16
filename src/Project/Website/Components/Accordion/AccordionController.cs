using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Accordion
{
	public class AccordionController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Accordion"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual AccordionModel GetModel(Item actionItem)
		{
			return new AccordionModel();
		}
	}
}
using System.Web.Mvc;
using Sitecore.Data.Fields;
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
				return View(GetViewName("Call to Action Section"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual CallToActionModel GetModel(Item actionItem)
		{
			var model = new CallToActionModel
			{
				Text = RenderField(actionItem, "Call to Action Text"),
				ButtonText = actionItem["Call to Action Button Text"],
			};

			LinkField lf = actionItem.Fields["Call to Action Link"];
			if(lf != null && !string.IsNullOrEmpty(lf.GetFriendlyUrl()))
			{
				model.ButtonUrl = lf.GetFriendlyUrl();
			}
			else
			{
				model.ButtonUrl = "#";
			}

			return model;
		}
	}
}
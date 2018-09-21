using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Features
{
	public class FeaturesController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Features"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual FeaturesModel GetModel(Item actionItem)
		{
			var model = new FeaturesModel
			{
				Text = RenderField(actionItem, "Features Text"),
			};

			var imageUrl = GetImageUrlAndAlt(actionItem.Fields["Features Image"], 700, 450);

			model.ImageUrl = imageUrl.Item1;
			model.ImageAlt = imageUrl.Item2;

			return model;
		}
	}
}
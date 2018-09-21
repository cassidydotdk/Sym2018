using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

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
				return View(GetViewName("Intro Content"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual IntroContentModel GetModel(Item actionItem)
		{
			var model = new IntroContentModel
			{
				Text = RenderField(actionItem, "Intro Content Text"),
			};

			var imageUrl = GetImageUrlAndAlt(actionItem.Fields["Intro Content Image"], 750, 450);

			model.ImageUrl = imageUrl.Item1;
			model.ImageAlt = imageUrl.Item2;

			return model;
		}
	}
}
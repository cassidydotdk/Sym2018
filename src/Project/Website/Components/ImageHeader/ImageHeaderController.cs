using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.ImageHeader
{
	public class ImageHeaderController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Image Header"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual ImageHeaderModel GetModel(Item actionItem)
		{
			var imageUrl = GetImageUrlAndAlt(actionItem.Fields["Image Header Image"], 1200, 300);

			var model = new ImageHeaderModel
			{
				ImageUrl = imageUrl.Item1,
				ImageAlt = imageUrl.Item2,
			};

			return model;
		}
	}
}
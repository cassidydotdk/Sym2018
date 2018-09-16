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
				return View(GetViewName("Image Header"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual ImageHeaderModel GetModel(Item actionItem)
		{
			return new ImageHeaderModel();
		}
	}
}
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.ContactDetails
{
	public class ContactDetailsController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Contact Details with Map"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual ContactDetailsModel GetModel(Item actionItem)
		{
			return new ContactDetailsModel
			{
				Latitude = actionItem["Contact Details with Map Latitude"],
				Longitude = actionItem["Contact Details with Map Longitude"],
				Span = actionItem["Contact Details with Map Span"],
				Text = RenderField(actionItem, "Contact Details with Map Text"),
			};
		}
	}
}
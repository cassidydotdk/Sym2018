using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.ContactForm
{
	public class ContactFormController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Contact Form"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual ContactFormModel GetModel(Item actionItem)
		{
			return new ContactFormModel();
		}
	}
}
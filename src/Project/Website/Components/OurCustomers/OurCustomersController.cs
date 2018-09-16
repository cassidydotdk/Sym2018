using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.OurCustomers
{
	public class OurCustomersController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Our Customers"), model);
			}

			return DatasourceMissingResult();
		}

		protected virtual OurCustomersModel GetModel(Item actionItem)
		{
			return new OurCustomersModel();
		}
	}
}
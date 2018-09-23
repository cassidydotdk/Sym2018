using System.Collections.Generic;
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
				return View(GetViewName("Our Customers"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual OurCustomersModel GetModel(Item actionItem)
		{
			// http://placehold.it/500x300

			var customers = new List<CustomerModel>();
			for (int i = 0; i < 6; i++)
			{
				var m = new CustomerModel();

				// Since there is no Customer IA, I'll just pass null to get placeholder images back
				var imageUrl = GetImageUrlAndAlt(null, 500, 300);

				m.ImageUrl = imageUrl.Item1;
				m.ImageAlt = imageUrl.Item2;

				customers.Add(m);
			}

			var model = new OurCustomersModel
			{
				Customers = customers.ToArray(),
			};

			return model;
		}
	}
}
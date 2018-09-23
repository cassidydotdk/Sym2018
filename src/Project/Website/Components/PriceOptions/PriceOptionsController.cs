using System.Collections.Generic;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Project.Website.Components.PriceOptions
{
	public class PriceOptionsController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Price Options"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual PriceOptionsModel GetModel(Item actionItem)
		{
			var priceOptions = new List<PriceOptionModel>();

			foreach (Item childPriceOption in actionItem.GetChildren())
			{
				priceOptions.Add(GetPriceOption(childPriceOption));
			}

			var model = new PriceOptionsModel
			{
				// May need a .Take(3) if the view does not support more
				PriceOptions = priceOptions.ToArray(),
			};

			return model;
		}

		private PriceOptionModel GetPriceOption(Item childPriceOption)
		{
			var m = new PriceOptionModel
			{
				Heading = childPriceOption["Price Option Heading"],
				Price = childPriceOption["Price Option Price"],
				Byline = childPriceOption["Price Option Byline"],
				IsPrimary = childPriceOption["Price Option Is Primary"] == "1",
				Bullet1 = childPriceOption["Price Option Bullet 1"],
				Bullet2 = childPriceOption["Price Option Bullet 2"],
				Bullet3 = childPriceOption["Price Option Bullet 3"],
				SignUpText = childPriceOption["Price Option Sign Up Text"],
				SignUpUrl = "#",
			};

			LinkField lf = childPriceOption.Fields["Price Option Sign Up Link"];
			if (!string.IsNullOrEmpty(lf?.GetFriendlyUrl()))
			{
				m.SignUpUrl = lf.GetFriendlyUrl();
			}

			return m;
		}
	}
}
using System.Collections.Generic;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Project.Website.Components.Marketing_Icons
{
	public class MarketingIconsController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Marketing Icons"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual MarketingIconsModel GetModel(Item actionItem)
		{
			var marketingIcons = new List<MarketingIconModel>();

			foreach (Item marketingIconItem in actionItem.GetChildren())
			{
				marketingIcons.Add(GetMarketingIcon(marketingIconItem));
			}

			var model = new MarketingIconsModel
			{
				// may need a .Take(3) as none of the examples showed more than 3
				MarketingIcons = marketingIcons,
			};

			return model;
		}

		private MarketingIconModel GetMarketingIcon(Item marketingIconItem)
		{
			var m = new MarketingIconModel
			{
				Title = marketingIconItem["Marketing Icon Title"],
				Text = marketingIconItem["Marketing Icon Text"],
				LinkText = marketingIconItem["Marketing Icon Link Text"],
			};

			LinkField lf = marketingIconItem.Fields["Marketing Icon Link"];
			if (lf != null && !string.IsNullOrEmpty(lf.GetFriendlyUrl()))
			{
				m.TargetUrl = lf.GetFriendlyUrl();
			}
			else
			{
				m.TargetUrl = "#";
			}

			return m;
		}
	}
}
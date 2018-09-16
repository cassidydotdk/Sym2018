﻿using System.Web.Mvc;
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
			return new MarketingIconsModel();
		}
	}
}
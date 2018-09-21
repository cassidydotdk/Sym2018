﻿using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.PortfolioItem
{
	public class PortfolioItemController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Portfolio Item"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual PortfolioItemModel GetModel(Item actionItem)
		{
			var model = new PortfolioItemModel
			{
				Text = RenderField(actionItem, "Portfolio Item Text"),
			};

			var imageUrl = GetImageUrlAndAlt(actionItem.Fields["Portfolio Item Image"], 750, 500);

			model.ImageUrl = imageUrl.Item1;
			model.ImageAlt = imageUrl.Item2;

			return model;
		}
	}
}
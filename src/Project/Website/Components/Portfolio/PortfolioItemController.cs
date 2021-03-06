﻿using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Portfolio
{
	public class PortfolioItemController : ComponentController
	{
		private readonly PortfolioRepository _portfolioRepository;

		public PortfolioItemController()
		{
			_portfolioRepository = new PortfolioRepository();
		}

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
			return _portfolioRepository.GetPortfolioItemModel(actionItem, 750, 500);
		}
	}
}
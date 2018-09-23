using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace Project.Website.Components.Breadcrumb
{
	public class BreadcrumbController : ComponentController
	{
		public virtual ActionResult Index()
		{
			// This is one of the only exception to the rule, 
			// that ever component should take and respect a datasource
			// For a breadcrumb trail, this just doesn't make sense

			var actionItem = Sitecore.Context.Item;
			var siteRoot = actionItem.Database.GetItem($"{Sitecore.Context.Site.StartPath}{Sitecore.Context.Site.StartItem}");

			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem, siteRoot);
				return View(GetViewName("Breadcrumb"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual BreadcrumbModel GetModel(Item actionItem, Item siteRoot)
		{
			var currentItem = actionItem;
			var breadcrumbs = new List<BreadcrumbItemModel>();

			do
			{
				var breadcrumb = GetBreadcrumb(currentItem);
				if (currentItem.ID == Sitecore.Context.Item.ID)
				{
					breadcrumb.IsActive = true;
				}

				breadcrumbs.Add(breadcrumb);

				currentItem = currentItem.Parent;
			} while (currentItem.Axes.IsDescendantOf(siteRoot));

			var model = new BreadcrumbModel
			{
				Breadcrumbs = breadcrumbs.ToArray().Reverse(),
			};

			return model;
		}

		private BreadcrumbItemModel GetBreadcrumb(Item currentItem)
		{
			var model = new BreadcrumbItemModel
			{
				Title = currentItem["Page Information Breadcrumb Title"],
			};

			if (string.IsNullOrWhiteSpace(model.Title))
			{
				model.Title = currentItem.DisplayName;
			}

			if (string.IsNullOrWhiteSpace(model.Title))
			{
				model.Title = currentItem.Name;
			}

			model.Url = LinkManager.GetItemUrl(currentItem);

			return model;
		}
	}
}
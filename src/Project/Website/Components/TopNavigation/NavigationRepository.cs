using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Project.Website.Components.TopNavigation
{
	public class NavigationRepository
	{
		public virtual TopNavigationModel GetModel(Item actionItem)
		{
			var model = new TopNavigationModel
			{
				BrandLinkText = actionItem["Brand Link Text"],
				BrandLinkUrl = "/",
			};

			LinkField lf = actionItem.Fields["Brand Link"];
			if (!string.IsNullOrEmpty(lf?.GetFriendlyUrl()))
			{
				model.BrandLinkUrl = lf.GetFriendlyUrl();
			}

			var navLinks = new List<NavigationItemModel>();
			foreach (Item navLinkItem in actionItem.GetChildren())
			{
				navLinks.Add(GetNavLink(navLinkItem));
			}
			model.TopNavigationLinks = navLinks.ToArray();

			return model;
		}

		private NavigationItemModel GetNavLink(Item navItem)
		{
			var model = new NavigationItemModel
			{
				Title = navItem["Navigation Item Title"],
				Url = "#",
				Children = new NavigationItemModel[0],
			};

			if (!navItem.HasChildren)
			{
				LinkField lf = navItem.Fields["Navigation Item Link"];
				if (!string.IsNullOrEmpty(lf?.GetFriendlyUrl()))
				{
					model.Url = lf.GetFriendlyUrl();
				}
			}
			else
			{
				// The model supports endless recursion. The front end view, however, does not.

				var childNavItems = new List<NavigationItemModel>();
				foreach (Item childNavItem in navItem.GetChildren())
				{
					childNavItems.Add(GetNavLink(childNavItem));
				}
				model.Children = childNavItems.ToArray();
			}

			return model;
		}
	}
}
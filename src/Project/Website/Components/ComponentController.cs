using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Project.Website.Components
{
	public class ComponentController : Controller
	{
		protected virtual Item GetActionItem()
		{
			// Datasource
			if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
			{
				var item = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
				if (item != null && item.Versions.Count > 0)
					return item;

				return null;
			}

			// Fall back to context item
			return Sitecore.Context.Item;
		}

		protected virtual ActionResult DatasourceMissingResult()
		{
			return new EmptyResult();
		}

		protected virtual string GetViewName(string componentName)
		{
			return $"~/Views/Components/{componentName}.cshtml";
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

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

		protected virtual T SetComponentProperties<T>(T model) where T: ComponentModel
		{
			if (Sitecore.Context.PageMode.IsExperienceEditor)
				model.IsEditor = true;

			model.IsEditor = false;

			return model;
		}

		public virtual HtmlString RenderField(Item item, string fieldName, string parameters = "")
		{
			if ((Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsPreview) && string.IsNullOrWhiteSpace(item[fieldName]))
			{
				return null;
			}

			return new HtmlString(FieldRenderer.Render(item, fieldName, parameters));
		}
	}
}
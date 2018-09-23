using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
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
		protected virtual Item GetSiteRoot(Item contextItem)
		{
			return contextItem.Database.GetItem(Sitecore.Context.Site.StartPath);
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

		public virtual Tuple<string, string> GetImageUrlAndAlt(ImageField imageField, int? maxWidth = null, int? maxHeight = null)
		{
			if (imageField?.MediaItem != null)
			{
				var mo = new MediaUrlOptions
				{
					MaxWidth = 750,
					MaxHeight = 450,
				};

				var url = MediaManager.GetMediaUrl(imageField.MediaItem, mo);
				var protectedUrl = HashingUtils.ProtectAssetUrl(url);

				return new Tuple<string, string>(protectedUrl, imageField.Alt);
			}
			else
			{
				if (maxWidth != null && maxHeight != null)
				{
					return new Tuple<string, string>($"http://placehold.it/{maxWidth}x{maxHeight}", "Dummy placeholder image");
				}

				return new Tuple<string, string>("#", "no image");
			}
		}
	}
}
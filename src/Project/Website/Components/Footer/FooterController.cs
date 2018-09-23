using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Project.Website.Components.Footer
{
	public class FooterController : ComponentController
	{
		public virtual ActionResult Index()
		{
			Item actionItem;

			string explicitDatasource = RenderingContext.Current.Rendering.DataSource;

			if (string.IsNullOrEmpty(explicitDatasource))
			{
				var siteRoot = GetSiteRoot(Context.Item);
				ReferenceField rf = siteRoot.Fields["Site Root Global Footer"];
				if (rf?.TargetItem != null)
					actionItem = rf.TargetItem;
				else
					actionItem = GetActionItem();
			}
			else
			{
				actionItem = GetActionItem();
			}

			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Footer"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual FooterModel GetModel(Item actionItem)
		{
			return new FooterModel
			{
				Text = new HtmlString(actionItem["Footer Text"])
			};
		}
	}
}
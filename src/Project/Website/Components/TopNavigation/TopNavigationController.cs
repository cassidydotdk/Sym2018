using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Project.Website.Components.TopNavigation
{
	public class TopNavigationController : ComponentController
	{
		private readonly NavigationRepository _navigationRepository;

		public TopNavigationController() : this(new NavigationRepository())
		{
		}

		public TopNavigationController(NavigationRepository navigationRepository)
		{
			_navigationRepository = navigationRepository;
		}

		public virtual ActionResult Index()
		{
			Item actionItem;

			string explicitDatasource = RenderingContext.Current.Rendering.DataSource;

			if (string.IsNullOrEmpty(explicitDatasource))
			{
				var siteRoot = GetSiteRoot(Sitecore.Context.Item);
				ReferenceField rf = siteRoot.Fields["Site Root Global Navigation"];
				if (rf?.TargetItem != null)
				{
					actionItem = rf.TargetItem;
				}
				else
				{
					actionItem = GetActionItem();
				}
			}
			else
			{
				actionItem = GetActionItem();
			}

			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = _navigationRepository.GetModel(actionItem);
				return View(GetViewName("Top Navigation"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}
	}
}
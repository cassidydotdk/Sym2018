using System.Web.Mvc;
using Project.Website.Components.TopNavigation;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Project.Website.Components.Jumbotron
{
	public class JumbotronController : ComponentController
	{
		private readonly NavigationRepository _navigationRepository;

		public JumbotronController() : this(new NavigationRepository()) { }

		public JumbotronController(NavigationRepository navigationRepository)
		{
			_navigationRepository = navigationRepository;
		}

		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Jumbotron"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual JumbotronModel GetModel(Item actionItem)
		{
			var model = new JumbotronModel
			{
				Title = actionItem["Jumbotron Title"],
				Text = RenderField(actionItem, "Jumbotron Text"),
				NavigationItems = new NavigationItemModel[0],
			};

			ReferenceField rf = actionItem.Fields["Jumbotron Top Navigation Reference"];
			if (rf?.TargetItem != null)
			{
				var navModel = _navigationRepository.GetModel(rf.TargetItem);
				model.NavigationItems = navModel.TopNavigationLinks;
			}

			return model;
		}
	}
}
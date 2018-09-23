using System.Web.Mvc;

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
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = _navigationRepository.GetModel(actionItem);
				return View(GetViewName("Top Navigation"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}
	}
}
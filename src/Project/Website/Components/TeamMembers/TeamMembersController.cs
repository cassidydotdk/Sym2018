using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.TeamMembers
{
	public class TeamMembersController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Team Members"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual TeamMembersModel GetModel(Item actionItem)
		{
			return new TeamMembersModel();
		}
	}
}
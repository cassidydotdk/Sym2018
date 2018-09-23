using System.Collections.Generic;
using System.Web.Mvc;
using Sitecore.Data.Fields;
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
			var teamMembers = new List<TeamMemberModel>();

			ReferenceField rf = actionItem.Fields["Team Members Team Selector"];
			if (rf?.TargetItem != null)
			{
				var team = rf.TargetItem;

				MultilistField teamMembersField = team.Fields["Team Members"];

				if (teamMembersField?.TargetIDs.Length > 0)
				{
					foreach (Item teamMember in teamMembersField.GetItems())
					{
						teamMembers.Add(GetTeamMemberModel(teamMember));
					}
				}
			}

			MultilistField individualMembersField = actionItem.Fields["Team Members Individual Members"];
			if (individualMembersField?.TargetIDs.Length > 0)
			{
				foreach (Item teamMemberItem in individualMembersField.GetItems())
				{
					teamMembers.Add(GetTeamMemberModel(teamMemberItem));
				}
			}

			var model = new TeamMembersModel
			{
				// May need a .Take(3) if the HTML doesn't support more. Doubt it though.
				TeamMembers = teamMembers,
			};

			return model;
		}

		private TeamMemberModel GetTeamMemberModel(Item teamMemberItem)
		{
			var imageUrl = GetImageUrlAndAlt(teamMemberItem.Fields["Team Member Image"], 750, 450);

			return new TeamMemberModel
			{
				ImageUrl = imageUrl.Item1,
				ImageAlt = imageUrl.Item2,
				Name = teamMemberItem["Team Member Name"],
				Position = teamMemberItem["Team Member Position"],
				Description = RenderField(teamMemberItem, "Team Member Description"),
				Email = teamMemberItem["Team Member Email"],
			};
		}
	}
}
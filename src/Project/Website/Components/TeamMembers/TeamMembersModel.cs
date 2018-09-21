using System.Collections.Generic;

namespace Project.Website.Components.TeamMembers
{
	public class TeamMembersModel : ComponentModel
	{
		public IEnumerable<TeamMemberModel> TeamMembers { get; set; }
	}
}
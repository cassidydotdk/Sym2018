using System.Web;

namespace Project.Website.Components.TeamMembers
{
	public class TeamMemberModel
	{
		public string ImageUrl { get; set; }
		public string ImageAlt { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public HtmlString Description { get; set; }
		public string Email { get; set; }
	}
}
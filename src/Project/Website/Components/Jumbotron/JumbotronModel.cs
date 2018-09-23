using System.Web;
using Project.Website.Components.TopNavigation;

namespace Project.Website.Components.Jumbotron
{
	public class JumbotronModel : ComponentModel
	{
		public string Title { get; set; }
		public HtmlString Text { get; set; }
		public NavigationItemModel[] NavigationItems { get; set; }
	}
}
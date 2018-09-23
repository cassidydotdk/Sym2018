namespace Project.Website.Components.TopNavigation
{
	public class NavigationItemModel
	{
		public bool IsActive { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public NavigationItemModel[] Children { get; set; }
	}
}
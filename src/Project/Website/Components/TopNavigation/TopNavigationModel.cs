namespace Project.Website.Components.TopNavigation
{
	public class TopNavigationModel : ComponentModel
	{
		public string BrandLinkUrl { get; set; }
		public string BrandLinkText { get; set; }
		public NavigationItemModel[] TopNavigationLinks { get; set; }
	}
}
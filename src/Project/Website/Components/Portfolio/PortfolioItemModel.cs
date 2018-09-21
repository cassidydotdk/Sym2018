using System.Web;

namespace Project.Website.Components.Portfolio
{
	public class PortfolioItemModel : ComponentModel
	{
		public string ImageUrl { get; set; }
		public string ImageAlt { get; set; }
		public HtmlString Text { get; set; }
		public string PortfolioItemUrl { get; set; }
		public string Title { get; set; }
		public HtmlString ShortDescription { get; set; }
		public bool IsLast { get; set; }
	}
}
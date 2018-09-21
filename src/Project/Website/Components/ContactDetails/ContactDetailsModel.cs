using System.Web;

namespace Project.Website.Components.ContactDetails
{
	public class ContactDetailsModel : ComponentModel
	{
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Span { get; set; }
		public HtmlString Text { get; set; }
	}
}
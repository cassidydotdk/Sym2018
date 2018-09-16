using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Website.Components.HeadlineWithSubheading
{
	public class HeadlineWithSubheadingModel : ComponentModel
	{
		public int HeadingLevel { get; set; }
		public HtmlString Subheading { get; set; }
		public HtmlString Heading { get; set; }
	}
}
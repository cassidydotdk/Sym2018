using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Website.Components.IntroContent
{
	public class IntroContentModel : ComponentModel
	{
		public HtmlString Text { get; set; }
		public string ImageUrl { get; set; }
		public string ImageAlt { get; set; }
	}
}
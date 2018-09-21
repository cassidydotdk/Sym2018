using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Website.Components.PortfolioItem
{
	public class PortfolioItemModel : ComponentModel
	{
		public string ImageUrl { get; set; }
		public string ImageAlt { get; set; }
		public HtmlString Text { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Website.Components.Accordion
{
	public class AccordionItemModel
	{
		public bool Collapsed { get; set; }
		public string Title { get; set; }
		public HtmlString Text { get; set; }
	}
}
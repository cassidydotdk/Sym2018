using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Website.Components.CallToAction
{
	public class CallToActionModel : ComponentModel
	{
		public HtmlString Text { get; set; }
		public string ButtonUrl { get; set; }
		public string ButtonText { get; set; }
	}
}
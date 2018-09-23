using System.Collections.Generic;
using System.Web;

namespace Project.Website.Components.Accordion
{
	public class AccordionModel : ComponentModel
	{
		public string[] numericLiterals = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
		public IEnumerable<AccordionItemModel> AccordionItems { get; set; }
	}
}
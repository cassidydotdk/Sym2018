using System.Collections.Generic;
using System.Web;

namespace Project.Website.Components.Accordion
{
	public class AccordionModel : ComponentModel
	{
		public IEnumerable<AccordionItemModel> AccordionItems { get; set; }
	}
}
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Project.Website.Components.Accordion
{
	public class AccordionController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Accordion"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual AccordionModel GetModel(Item actionItem)
		{
			var accordionItems = new List<AccordionItemModel>();

			if (actionItem.Fields["Accordion Shared Items"] != null)
			{
				MultilistField mlf = actionItem.Fields["Accordion Shared Items"];

				foreach (Item accordionItem in mlf.GetItems())
				{
					accordionItems.Add(GetAccordionItemModel(accordionItem));
				}
			}

			foreach (Item accordionItem in actionItem.GetChildren())
			{
				accordionItems.Add(GetAccordionItemModel(accordionItem));
			}

			if (accordionItems.Any())
			{
				accordionItems.First().Collapsed = false;
			}

			var model = new AccordionModel
			{
				AccordionItems = accordionItems,
			};

			return model;
		}

		AccordionItemModel GetAccordionItemModel(Item accordionItem)
		{
			var m = new AccordionItemModel
			{
				Collapsed = true,
				Title = accordionItem["Accordion Item Headline"],
				Text = RenderField(accordionItem, "Accordion Item Text"),
			};

			return m;
		}
	}
}
using System.Collections.Generic;
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components.Header
{
	public class HeaderController : ComponentController
	{
		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Header"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual HeaderModel GetModel(Item actionItem)
		{
			var carouselSlides = new List<CarouselSlideModel>();

			foreach (Item carouselSlideItem in actionItem.GetChildren())
			{
				var m = new CarouselSlideModel
				{
					Heading = carouselSlideItem["Carousel Slide Heading"],
					Description = carouselSlideItem["Carousel Slide Description"],
				};

				var imageUrls = GetImageUrlAndAlt(actionItem.Fields["Carousel Slide Image"], 1900, 1080);
				m.ImageUrl = imageUrls.Item1;
				carouselSlides.Add(m);
			}

			var model = new HeaderModel
			{
				CarouselSlides = carouselSlides.ToArray(),
			};

			return model;
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Project.Website.Components.Portfolio
{
	// Not really a ComponentController, but we'll fix that later
	public class PortfolioRepository : ComponentController
	{
		public PortfolioItemModel GetPortfolioItemModel(Item portfolioItem, int imageWidth, int imageHeight)
		{
			var model = new PortfolioItemModel
			{
				Title = portfolioItem["Portfolio Item Title"],
				ShortDescription = RenderField(portfolioItem, "Portfolio Item Short Description"),
				Text = RenderField(portfolioItem, "Portfolio Item Text"),
				PortfolioItemUrl = "#",
			};

			var imageUrl = GetImageUrlAndAlt(portfolioItem.Fields["Portfolio Item Image"], imageWidth, imageHeight);

			model.ImageUrl = imageUrl.Item1;
			model.ImageAlt = imageUrl.Item2;

			return model;
		}

		public IEnumerable<PortfolioItemModel> GetPortfolioItems(Item actionItem, int imageWidth, int imageHeight, int page, int pageSize)
		{
			var repositoryItems = new List<PortfolioItemModel>();

			ReferenceField repository = actionItem.Fields["Portfolio Item Repository"];
			if (repository?.TargetItem != null)
			{
				var repositoryRoot = repository.TargetItem;

				foreach (Item repositoryItem in repositoryRoot.GetChildren())
				{
					repositoryItems.Add(GetPortfolioItemModel(repositoryItem, imageWidth, imageHeight));
				}
			}

			return repositoryItems.Skip(page * pageSize).Take(pageSize);
		}

		public IEnumerable<PortfolioItemModel> GetRelatedProjects(Item actionItem, int imageWidth, int imageHeight)
		{
			return GetPortfolioItemsFromMultilist(actionItem.Fields["Portfolio Item Related Projects"], imageWidth, imageHeight);
		}

		public IEnumerable<PortfolioItemModel> GetPortfolioItemsFromMultilist(MultilistField listField, int imageWidth, int imageHeight)
		{
			var repositoryItems = new List<PortfolioItemModel>();

			MultilistField selectedItems = listField;
			if (selectedItems?.TargetIDs.Length > 0)
			{
				foreach (Item repositoryItem in selectedItems.GetItems())
				{
					repositoryItems.Add(GetPortfolioItemModel(repositoryItem, imageWidth, imageHeight));
				}
			}

			return repositoryItems;
		}
	}
}
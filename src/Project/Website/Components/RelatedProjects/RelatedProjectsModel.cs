using System.Collections.Generic;
using Project.Website.Components.Portfolio;

namespace Project.Website.Components.RelatedProjects
{
	public class RelatedProjectsModel : ComponentModel
	{
		public IEnumerable<PortfolioItemModel> RelatedProjects { get; set; }
	}
}
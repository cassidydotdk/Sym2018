using System.Web.Mvc;
using Project.Website.Components.Portfolio;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Project.Website.Components.RelatedProjects
{
	public class RelatedProjectsController : ComponentController
	{
		private readonly PortfolioRepository _portfolioRepository;

		public RelatedProjectsController() : this(new PortfolioRepository()) { }

		public RelatedProjectsController(PortfolioRepository portfolioRepository)
		{
			_portfolioRepository = portfolioRepository;
		}

		public virtual ActionResult Index()
		{
			var actionItem = GetActionItem();
			if (actionItem != null && actionItem.Versions.Count > 0)
			{
				var model = GetModel(actionItem);
				return View(GetViewName("Related Projects"), SetComponentProperties(model));
			}

			return DatasourceMissingResult();
		}

		protected virtual RelatedProjectsModel GetModel(Item actionItem)
		{
			var model = new RelatedProjectsModel();

			MultilistField listField = actionItem.Fields["Related Projects"];
			if (listField == null)
			{
				model.RelatedProjects = _portfolioRepository.GetRelatedProjects(actionItem, 500, 300);
			}
			else
			{
				model.RelatedProjects = _portfolioRepository.GetPortfolioItemsFromMultilist(listField, 500, 300);
			}

			return model;
		}
	}
}
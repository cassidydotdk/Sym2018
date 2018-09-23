using System.Collections.Generic;

namespace Project.Website.Components.Breadcrumb
{
	public class BreadcrumbModel : ComponentModel
	{
		public IEnumerable<BreadcrumbItemModel> Breadcrumbs { get; set; }
	}
}
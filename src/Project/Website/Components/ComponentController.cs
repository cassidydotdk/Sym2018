using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Project.Website.Components
{
	public class ComponentController : Controller
	{
		protected virtual Item GetActionItem()
		{
			// TODO
			return null;
		}

		protected virtual ActionResult DatasourceMissingResult()
		{
			return new EmptyResult();
		}

		protected virtual string GetViewName(string componentName)
		{
			return $"~/Views/Components/{componentName}.cshtml";
		}
	}
}
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SimpleCRUD.UI.Controllers;

namespace SimpleCRUD.UI.Filters;

public class LayoutDataFilter : IAsyncActionFilter
{
	public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
	{
		HomeController controller = (HomeController)context.Controller;

		await next();

		controller.ViewData["Categories"] = new Dictionary<string, string>() { { "First Name", "FirstName" },
			{ "Last Name", "LastName" }, { "Email", "Email" }, { "Age", "Age" }};
	}
}

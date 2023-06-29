using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

public class CustomViewLocationExpander : IViewLocationExpander
{
    public void PopulateValues(ViewLocationExpanderContext context)
    {
        // No values need to be populated
    }

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        // Check if the current controller is in the "Client" namespace
        if (context.ActionContext.ActionDescriptor.RouteValues.ContainsKey("namespace") &&
            context.ActionContext.ActionDescriptor.RouteValues["namespace"].StartsWith("Client"))
        {
            // Add "Client" to the beginning of the view path
            viewLocations = new[] { "/Views/Client/{1}/{0}.cshtml", "/Views/Shared/{0}.cshtml" }
                .Concat(viewLocations);
        }

        return viewLocations;
    }
}

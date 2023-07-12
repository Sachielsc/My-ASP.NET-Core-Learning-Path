using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Utilities
{
    public class ControllerHelper : ControllerBase
    {
        public string GetHttpMethodAttribute(Type controllerType, string methodName)
        {
            ControllerActionDescriptor actionDescriptor = (ControllerActionDescriptor)ControllerContext.ActionDescriptor;
            var httpMethodAttribute = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(HttpMethodAttribute), true).FirstOrDefault() as HttpMethodAttribute;

            return httpMethodAttribute?.HttpMethods.FirstOrDefault() ?? "N/A";
        }
    }
}

﻿
using Microsoft.AspNetCore.Mvc.Filters; 
using Microsoft.AspNetCore.Mvc;


namespace NZWalks.API.CustomActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                context.Result = new BadRequestResult();
            }

        }

    }
}

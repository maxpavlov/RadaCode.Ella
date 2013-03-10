﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RadaCode.Ella.Application.MVC;

namespace RadaCode.Web.Application.MVC
{
    public class RadaCodeControllerFactory: DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                    return base.GetControllerInstance(requestContext, controllerType);
            }
            catch (HttpException ex)
            {
                if (ex.GetHttpCode() == 404)
                {
                    IController errorController = DependencyResolver.Current.GetService<ErrorController>();
                    ((ErrorController)errorController).InvokeHttp404(requestContext.HttpContext);

                    return errorController;
                }
                else
                    throw ex;
            }

            return DependencyResolver.Current.GetService(controllerType) as Controller;
        }
    }
}
using System;
using System.Web.Mvc;
using Portfolio.Controllers;
using Portfolio.Lib.Services;
using Portfolio.Properties;

namespace Portfolio.Lib
{
    public class DeleteResponder
    {
        private readonly ApplicationController controller;
        private readonly string controllerAction;
        private readonly string controllerName;
        private string message;

        public DeleteResponder(ApplicationController controller)
        {
            this.controller = controller;
            this.controllerName = controller.RouteData.Values["controller"].ToString().ToLowerInvariant();
            this.controllerAction = controller.RouteData.Values["action"].ToString().ToLowerInvariant();
        }

        public ActionResult RespondWith<TService>(Action<TService> action, bool addSuccessMessageToFlash = true) 
            where TService : class
        {
            InvokeService(action);
            AddSuccessFlashMessage(addSuccessMessageToFlash);
            var jsonResult = CreateSuccessfulJsonResult();
            return jsonResult;
        }

        private void AddSuccessFlashMessage(bool addSuccessMessageToFlash)
        {
            if (addSuccessMessageToFlash)
            {
                var resourceKey = string.Format("flash_{0}_{1}_success", controllerName, controllerAction);
                message = Resources.ResourceManager.GetString(resourceKey, Resources.Culture);
                controller.FlashMessages.AddSuccessMessage(message);    
            }            
        }

        private JsonResult CreateSuccessfulJsonResult()
        {
            var jsonResult = new JsonResult();
            jsonResult.Data = new
            {
                success = true,
                message = message
            };
            return jsonResult;
        }

        private void InvokeService<TService>(Action<TService> action) 
            where TService : class
        {
            var service = ServiceLocator.Instance.GetService<TService>();
            action(service);
        }
    }
}
using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using MvcFlashMessages;
using Portfolio.Controllers;
using Portfolio.Lib.Commands;
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
            Contract.Requires<ArgumentNullException>(controller != null);

            this.controller = controller;
            this.controllerName = controller.RouteData.Values["controller"].ToString().ToLowerInvariant();
            this.controllerAction = controller.RouteData.Values["action"].ToString().ToLowerInvariant();
        }

        public ActionResult RespondWith<T>(IMediator mediator, ICommand<T> command, bool addSuccessMessageToFlash = true, Action afterCommandSent = null)
        {
            Contract.Requires<ArgumentNullException>(mediator != null);
            Contract.Requires<ArgumentNullException>(command != null);

            mediator.Send(command);
            AddSuccessFlashMessage(addSuccessMessageToFlash);
            if (afterCommandSent != null)
                afterCommandSent.Invoke();
            var jsonResult = CreateSuccessfulJsonResult();
            return jsonResult;
        }

        private void AddSuccessFlashMessage(bool addSuccessMessageToFlash)
        {
            if (addSuccessMessageToFlash)
            {
                var resourceKey = string.Format("flash_{0}_{1}_success", controllerName, controllerAction);
                message = Resources.ResourceManager.GetString(resourceKey, Resources.Culture);
                controller.Flash("success", message);
            }            
        }

        private JsonResult CreateSuccessfulJsonResult()
        {
            var jsonResult = new JsonResult();
            jsonResult.Data = new
            {
                success = true,
                message = this.message
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
using System;
using System.Web.Mvc;

namespace Portfolio.Web.Lib
{
    public class ViewResultBuilder
    {
        private ControllerBase controller;
        private string masterName = null;
        private object model = null;
        private string viewName;

        public virtual ViewResult ViewResult
        {
            get
            {
                if (controller == null)
                    throw new NullReferenceException("Controller has not been set. Please set the controller before invoking the builder.");

                if (model != null)
                    controller.ViewData.Model = model;
                    
                return new ViewResult
                {
                    ViewName = viewName,
                    MasterName = masterName,
                    ViewData = controller.ViewData,
                    TempData = controller.TempData,
                    ViewEngineCollection = ViewEngines.Engines
                };
            }
        }

        public ViewResultBuilder Controller(ControllerBase controller)
        {
            this.controller = controller;
            return this;
        }

        public ViewResultBuilder MasterName(string masterName)
        {
            this.masterName = masterName;
            return this;
        }

        public ViewResultBuilder Model(object model)
        {
            this.model = model;
            return this;
        }

        public ViewResultBuilder ViewName(string viewName)
        {
            this.viewName = viewName;
            return this;
        }
    }
}
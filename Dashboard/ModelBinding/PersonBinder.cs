using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.ModelBinding
{
    public class PersonBinder: DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var mod = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + "Person");

          
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
        
    }
}
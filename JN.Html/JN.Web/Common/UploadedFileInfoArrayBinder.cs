using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JN.Web.Common
{
    public class UploadedFileInfoArrayBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            List<HttpPostedFileBase> list = new List<HttpPostedFileBase>();
            var files = controllerContext.HttpContext.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var key = files.AllKeys[i];
                if (key.LastIndexOf("[]")>0) ;
                {
                    key = key.Replace("[]", "");
                }

                list.Add(file);
            }
            return list;
        }
    }
}
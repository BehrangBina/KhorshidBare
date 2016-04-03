 using System;
using System.Collections.Generic;
 using System.Data;
 using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using System.Web;
 using System.Web.Mvc;
 using System.Web.UI.WebControls;
 using KhorshidBare.Models.extensions;

namespace KhorshidBare.ActionResult
{
    public class KhorshidJsonResult<T> :JsonResult
    {
        public List<string> ErrorMessages { get;private set; }

        public KhorshidJsonResult()
        {
            ErrorMessages= new List<string>();
        }

        public void AddError(string err)
        {
            ErrorMessages.Add(err);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            DoBaseClassStuff(context);
            SerializableData(context.HttpContext.Response);
        }

        private void DoBaseClassStuff(ControllerContext context)
        {
            if (context == null)
            {
                throw new NoNullAllowedException("Not Null allowed");//to be implemented
            }
            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/Json" : context.ToString();
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
        }

        private void SerializableData(HttpResponseBase response)
        {
            if (ErrorMessages.Any())
            {
                Data = new
                {
                    ErrorMessage=string.Join("\n",ErrorMessages),
                    ErrorMessages=ErrorMessages.ToArray()
                };
                response.StatusCode = 400;
            }
            if (Data == null)
            {
                return;
            }
            response.Write(Data.ToJson());
        }
    }
}

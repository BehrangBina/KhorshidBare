

using KhorshidBare.ActionResult;
using System.Web.Mvc;


namespace KhorshidBare.Controllers
{
    public abstract class KhorshidBaseController : Controller
    {
      public KhorshidJsonResult<T> SimpleJsonResult<T>(T model)
        {

            return new KhorshidJsonResult<T> { Data = model };
        }
    }
}
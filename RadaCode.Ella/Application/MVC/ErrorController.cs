using System.Net;
using System.Web.Mvc;
using RadaCode.Web.Application.MVC;

namespace RadaCode.Ella.Application.MVC
{
    public class ErrorController : RadaCodeBaseController
    {
        #region Http404

        public ActionResult Http404(string url)
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            var model = new NotFoundViewModel();
            // If the url is relative ('NotFound' route) then replace with Requested path
            model.RequestedUrl = Request.Url.OriginalString.Contains(url) & Request.Url.OriginalString != url ?
                Request.Url.OriginalString : url;
            // Dont get the user stuck in a 'retry loop' by
            // allowing the Referrer to be the same as the Request
            model.ReferrerUrl = Request.UrlReferrer != null &&
                Request.UrlReferrer.OriginalString != model.RequestedUrl ?
                Request.UrlReferrer.OriginalString : null;

            // TODO: insert ILogger here

            return View("NotFound", model);
        }
        public class NotFoundViewModel
        {
            public string RequestedUrl { get; set; }
            public string ReferrerUrl { get; set; }
        }

        #endregion
    }
}

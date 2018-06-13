using System.Web.Mvc;

namespace AspNetMvc.Attributes
{
    public class AuthorizeRequestAccessTypeAttribute : AuthorizeAttribute
    {
        public RequestAccessType AccessTypes { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool isAuthed = false;

            if (AccessTypes.HasFlag(RequestAccessType.Local) && filterContext.HttpContext.Request.IsLocal)
            {
                isAuthed = true;
            }

            if (AccessTypes.HasFlag(RequestAccessType.Console))
            {

            }

            if (AccessTypes.HasFlag(RequestAccessType.VPN))
            {

            }

            if(!isAuthed)
            { 
                filterContext.Result = new HttpStatusCodeResult(403, "Not a local request");
            }

            base.OnAuthorization(filterContext);
        }
    }
}
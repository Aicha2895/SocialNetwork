using System;
using System.Web;

namespace SocialNetworkWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (ContextManager.GetUserIdFromContext(this.Context) == 0)
			{
				Response.Redirect("~/LogIn.aspx");
			}
		}

        protected void Page_Load(object sender, EventArgs e)
        {
			
        }

		protected void ButtonExit_Click(object sender, EventArgs e)
		{
			var myCookie = new HttpCookie("UserId");
			myCookie.Expires = DateTime.Now.AddDays(-1d);
			Response.Cookies.Add(myCookie);

			Session.Abandon();
			Response.Redirect("~/LogIn.aspx");
		}
    }
}

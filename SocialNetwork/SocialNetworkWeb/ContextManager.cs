using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetworkWeb
{
	public class ContextManager
	{
		public static int GetUserIdFromContext(HttpContext context)
		{
			int userId = 0;

			Int32.TryParse(context.Request.Cookies["UserId"].Value, out userId);

			return userId;
		}
	}
}
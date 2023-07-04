using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmbedIO.Routing;
using EmbedIO;
using EmbedIO.WebApi;

namespace Melia.Web.Controllers
{
	public class TosMarketController : WebApiController
	{
		[Route(HttpVerbs.Get, "/")]
		public void GetIndex()
		{
			this.WriteText("index");
		}

		private void WriteText(string content)
		{
			var data = Encoding.UTF8.GetBytes(content);
			using (var stream = this.HttpContext.OpenResponseStream())
				stream.Write(data, 0, data.Length);
		}
	}
}

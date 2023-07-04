using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmbedIO.Routing;
using EmbedIO;
using EmbedIO.WebApi;
using System.Net;
using System.IO;
using Melia.Web.Util;

namespace Melia.Web.Controllers
{
	public class TosGuildController : WebApiController
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

		// /guildemblem/506544147923578
		[Route(HttpVerbs.Get, "/guildemblem/{guildId}")]
		public byte[] GetGuildEmblem(long guildId)
		{
			try
			{
				var filePath = $"user/web/GuildEmblem/{guildId}.png";
				if (File.Exists(filePath))
				{
					this.Response.ContentType = "image/jpeg";
					this.Response.SendChunked = true;
					return FileUtils.FileToByteArray(filePath);
				}
			}
			catch (Exception)
			{

			}
			// 100 : There is no registered image.
			this.HttpContext.SendStringContentAsync("100 : 등록된 이미지가 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.NotFound);
			return null;
		}
	}
}

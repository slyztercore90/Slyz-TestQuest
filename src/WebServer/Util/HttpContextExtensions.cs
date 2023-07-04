using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmbedIO.Utilities;
using EmbedIO;

namespace Melia.Web.Util
{
	/// <summary>
	/// Provides extension methods for types implementing <see cref="IHttpContext"/>.
	/// </summary>
	public static class HttpContextExtensions
	{
		/// <summary>
		/// <para>Asynchronously sends a string as response.</para>
		/// <para>This method differs from <seealso cref="EmbedIO.HttpContextExtensions.SendStringAsync"/>
		/// in that it sets the <c>Content-Length</c> header in the response, thus preventing
		/// any further output to the response stream.</para>
		/// </summary>
		/// <param name="this">The <see cref="IHttpResponse"/> interface on which this method is called.</param>
		/// <param name="content">The response content.</param>
		/// <param name="contentType">The MIME type of the content.
		/// If this parameter is <see langword="null"/> or the empty string, the content type will not be set.</param>
		/// <param name="encoding">The <see cref="Encoding"/> to use.</param>
		/// <returns>A <see cref="Task"/> representing the ongoing operation.</returns>
		/// <exception cref="NullReferenceException"><paramref name="this"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException">
		/// <para><paramref name="content"/> is <see langword="null"/>.</para>
		/// <para>- or -</para>
		/// <para><paramref name="encoding"/> is <see langword="null"/>.</para>
		/// </exception>
		public static Task SendStringContentAsync(
			this IHttpContext @this,
			string content,
			string contentType,
			Encoding encoding,
			HttpStatusCode code)
		{
			content = Validate.NotNull(nameof(content), content);
			encoding = Validate.NotNull(nameof(encoding), encoding);

			if (!string.IsNullOrEmpty(contentType))
			{
#pragma warning disable CS8601 // Possible null reference assignment - Tested with string.NotNullOrEmpty
				@this.Response.ContentType = contentType;
#pragma warning restore CS8601
				@this.Response.ContentEncoding = encoding;
			}

			var data = encoding.GetBytes(content);
			@this.Response.StatusCode = (int)code;
			@this.Response.ContentLength64 = data.Length;
			return @this.Response.OutputStream.WriteAsync(data, 0, data.Length, @this.CancellationToken);
		}

		public static Task SendHexStringContentAsync(this IHttpContext @this,
			string content,
			string contentType,
			Encoding encoding)
		{
			content = Validate.NotNull(nameof(content), content);
			encoding = Validate.NotNull(nameof(encoding), encoding);

			if (!string.IsNullOrEmpty(contentType))
			{
#pragma warning disable CS8601 // Possible null reference assignment - Tested with string.NotNullOrEmpty
				@this.Response.ContentType = contentType;
#pragma warning restore CS8601
				@this.Response.ContentEncoding = encoding;
			}

			byte[] bytes = Encoding.UTF8.GetBytes(content);
			string hexString = BitConverter.ToString(bytes);
			var data = encoding.GetBytes(hexString.Replace("-", ""));
			@this.Response.ContentLength64 = data.Length;
			return @this.Response.OutputStream.WriteAsync(data, 0, data.Length, @this.CancellationToken);
		}

		public static Task SendJSONHexStringContentAsync(this IHttpContext @this,
			string content,
			string contentType,
			Encoding encoding)
		{
			content = Validate.NotNull(nameof(content), content);
			encoding = Validate.NotNull(nameof(encoding), encoding);

			if (!string.IsNullOrEmpty(contentType))
			{
#pragma warning disable CS8601 // Possible null reference assignment - Tested with string.NotNullOrEmpty
				@this.Response.ContentType = contentType;
#pragma warning restore CS8601
				@this.Response.ContentEncoding = encoding;
			}

			byte[] bytes = Encoding.UTF8.GetBytes(content);
			string hexString = BitConverter.ToString(bytes);
			var data = encoding.GetBytes(hexString.Replace("-", ""));
			@this.Response.ContentLength64 = data.Length;
			return @this.Response.OutputStream.WriteAsync(data, 0, data.Length, @this.CancellationToken);
		}
	}

	public static class HttpRequestExtensions
	{
		public static bool IsAuthorized(this IHttpRequest request)
		{
			var token = request.Headers.Get("Authorization");
			//if (!string.IsNullOrEmpty(token))
			//return WebServer.Instance.Database.CheckSessionKeyExists(request.Headers.Get("Authorization").Replace("Bearer ", ""), out var character);
			return true;
		}

		/**
		public static bool IsAuthorized(this IHttpRequest request, out Character character)
		{
			character = default;
			var token = request.Headers.Get("Authorization");
			if (!string.IsNullOrEmpty(token))
				return WebServer.Instance.Database.CheckSessionKeyExists(request.Headers.Get("Authorization").Replace("Bearer ", ""), out character);
			return true;
		}
		**/
	}
}

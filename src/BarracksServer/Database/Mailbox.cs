using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;

namespace Melia.Barracks.Database
{
	/// <summary>
	/// Mailbox
	/// </summary>
	public class Mailbox
	{
		private readonly object _syncLock = new object();

		/// <summary>
		/// Returns the mail messages
		/// </summary>
		public List<MailMessage> Mail { get; set; } = new List<MailMessage>();

		/// <summary>
		/// Returns if the mail box has messages
		/// </summary>
		public bool HasMessages { get { lock (_syncLock) { return this.Mail.Count > 0; } } }

		/// <summary>
		/// Returns the number of unread messages
		/// </summary>
		public int UnreadMesages
		{
			get
			{
				lock (_syncLock)
				{
					return this.Mail.Count(a => a.State == PostBoxMessageState.None);
				}
			}
		}

		/// <summary>
		/// Returns the number of read messages
		/// </summary>
		public int ReadMessages
		{
			get
			{
				lock (_syncLock)
					return this.Mail.Count(a => a.State == PostBoxMessageState.Read);
			}
		}

		/// <summary>
		/// Returns the numbers of messages
		/// </summary>
		public int MessageCount { get { lock (_syncLock) { return this.Mail.Count; } } }

		/// <summary>
		/// Add a mail message
		/// </summary>
		/// <param name="mail"></param>
		public void AddMail(MailMessage mail)
		{
			lock (_syncLock)
				this.Mail.Add(mail);
		}

		/// <summary>
		/// Try to get mail
		/// </summary>
		/// <param name="messageId"></param>
		/// <param name="mail"></param>
		/// <returns></returns>
		public MailMessage Get(long messageId)
		{
			lock (_syncLock)
				return this.Mail.FirstOrDefault(m => m.Id == messageId);
		}
	}
}

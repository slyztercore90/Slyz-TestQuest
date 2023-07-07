using Melia.Shared.ObjectProperties;

namespace Melia.Web.Database
{
	public class Character
	{
		public long Id { get; set; }
		public long ObjectId => ObjectIdRanges.Characters + this.Id;
		public long AccountId { get; set; }
		public long AccountObjectId => ObjectIdRanges.Account + this.AccountId;

		public Character(long id, long accountId)
		{
			this.Id = id;
			this.AccountId = accountId;
		}
	}
}

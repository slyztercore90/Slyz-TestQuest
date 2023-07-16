using Melia.Shared.Data.Database;

namespace Melia.Shared.Data
{
	/// <summary>
	/// Wrapper for all file databases.
	/// </summary>
	public class MeliaData
	{
		public AbilityDb AbilityDb { get; set; } = new AbilityDb();
		public AbilityTreeDb AbilityTreeDb { get; set; } = new AbilityTreeDb();
		public AccountOptionDb AccountOptionDb { get; set; } = new AccountOptionDb();
		public AchievementDb AchievementDb { get; set; } = new AchievementDb();
		public AchievementPointDb AchievementPointDb { get; set; } = new AchievementPointDb();
		public BarrackDb BarrackDb { get; set; } = new BarrackDb();
		public BuffDb BuffDb { get; set; } = new BuffDb();
		public ChatMacroDb ChatMacroDb { get; set; } = new ChatMacroDb();
		public CustomCommandDb CustomCommandDb { get; set; } = new CustomCommandDb();
		public CooldownDb CooldownDb { get; set; } = new CooldownDb();
		public DialogDb DialogDb { get; set; } = new DialogDb();
		public DialogTxDb DialogTxDb { get; set; } = new DialogTxDb();
		public ExpDb ExpDb { get; set; } = new ExpDb();
		public FactionDb FactionDb { get; set; } = new FactionDb();
		public FeatureDb FeatureDb { get; set; } = new FeatureDb();
		public FurnitureDb FurnitureDb { get; set; } = new FurnitureDb();
		public GroundDb GroundDb { get; set; } = new GroundDb();
		public InvBaseIdDb InvBaseIdDb { get; set; } = new InvBaseIdDb();
		public ItemDb ItemDb { get; set; } = new ItemDb();
		public ItemMonsterDb ItemMonsterDb { get; set; } = new ItemMonsterDb();
		public JobDb JobDb { get; set; } = new JobDb();
		public MapDb MapDb { get; set; } = new MapDb();
		public MonsterDb MonsterDb { get; set; } = new MonsterDb();
		public NormalTxDb NormalTxDb { get; set; } = new NormalTxDb();
		public PacketStringDb PacketStringDb { get; set; } = new PacketStringDb();
		public PropertiesDb PropertiesDb { get; set; } = new PropertiesDb();
		public RecipeDb RecipeDb { get; set; } = new RecipeDb();
		public ResurrectionPointDb ResurrectionPointDb { get; set; } = new ResurrectionPointDb();
		public SelectItemDb SelectItemDb { get; set; } = new SelectItemDb();
		public ServerDb ServerDb { get; set; }
		public SessionObjectDb SessionObjectDb { get; set; } = new SessionObjectDb();
		public ShopDb ShopDb { get; set; } = new ShopDb();
		public SkillDb SkillDb { get; set; } = new SkillDb();
		public SkillTreeDb SkillTreeDb { get; set; } = new SkillTreeDb();
		public StanceConditionDb StanceConditionDb { get; set; } = new StanceConditionDb();
		public SystemMessageDb SystemMessageDb { get; set; } = new SystemMessageDb();
		public TradeShopDb TradeShopDb { get; set; }
		public HelpDb HelpDb { get; set; } = new HelpDb();

		public MeliaData()
		{
			// Not entirely happy with this design, but I want access to
			// the map list from the server db to determine which maps
			// the zone servers serve.
			this.ServerDb = new ServerDb(this.MapDb);
			this.TradeShopDb = new TradeShopDb(this.ItemDb);
		}
	}
}

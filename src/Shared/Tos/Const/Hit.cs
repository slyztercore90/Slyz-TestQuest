namespace Melia.Shared.Tos.Const
{
	public enum Hit
	{
		BASIC = 0,
		MOTION = 1,
		NOMOTION = 2,
		KNOCKBACK = 3,
		KNOCKDOWN = 4,

		GUARD = 5,
		FORCE = 6,
		HEAL = 7,
		HEALNOEFT = 8,
		SHIELD = 9,
		SAFETY = 10,
		TELEK = 11,
		POISON = 12,
		STABDOLL = 13,
		BLOCK = 14,
		DODGE = 15,
		ICE = 16,
		COUNTDOWN = 19,
		FIRE = 21,
		JANGPANHIT = 22,
		JANGPANBLESS = 23,
		JANGPANCURE = 24,
		JANGPANHEAL = 25,
		POISON_GREEN = 26,
		REFLECT = 27,
		NOEFFECT = 28,
		ENDURE = 29,
		POISON_VIOLET = 30,
		LIGHTNING = 31,
		PLANTGUARD = 32,
		HOLY = 33,
		DARK = 34,
		BLEEDING = 35,
		CONCENTRATE = 36,
		EARTH = 37,
		RETREAT = 38,
		SOUL = 39,
		BASIC_NOT_CANCEL_CAST = 40,
		NOHIT = 100,
		MAGIC = 1001,
		MELEE = 1002,
		WUGU_BLOOD = 1003,
		WUGU_POISON = 1004,
		TWINKLESTAR = 2001,
	}

	public enum HitResult
	{
		/// <summary>
		/// Displays no hit at all.
		/// </summary>
		NONE = 0,

		/// <summary>
		/// Displays "Dodge" text banner instead of any potential damage.
		/// </summary>
		DODGE = 1,

		/// <summary>
		/// Displays damage in blue.
		/// </summary>
		BLOCK = 2,

		/// <summary>
		/// Normal hit.
		/// </summary>
		BLOW = 3,

		/// <summary>
		/// Yellow damage text accompanied by a high-pitched sound.
		/// </summary>
		CRITICAL = 4,

		/// <summary>
		/// Displays damage and "Dodge" text banner.
		/// </summary>
		DODGE_REDUCE = 5,

		/// <summary>
		/// Displays "Miss" text banner.
		/// </summary>
		MISS = 6,

		/// <summary>
		/// Hit with damage and a metallic sound.
		/// </summary>
		INVALID = 7,

		/// <summary>
		/// Normal hit, but without hit sound.
		/// </summary>
		NO_HITSCP = 8,

		/// <summary>
		/// Same as Unk4? Seen with Magic Missile.
		/// </summary>
		NO_HITSCP_CRI = 9,
	}

	public enum HitEffect
	{
		/// <summary>
		/// No special effect.
		/// </summary>
		NO = 0,

		/// <summary>
		/// Target flashes white.
		/// </summary>
		BAD = 1,

		/// <summary>
		/// Displays an impact effect.
		/// </summary>
		NORMAL = 2,

		/// <summary>
		/// Displays a more pronounced impact effect.
		/// </summary>
		NICE = 3,

		/// <summary>
		/// Displays a more pronounced impact effect.
		/// </summary>
		EXCEL = 4,

		/// <summary>
		/// Displays a more pronounced impact effect.
		/// </summary>
		COUNTER = 5,

		/// <summary>
		/// Displays a more pronounced impact effect.
		/// </summary>
		SAFETY = 6,
	}
}

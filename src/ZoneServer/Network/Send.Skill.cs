using Melia.Shared.Network;
using Melia.Shared.Network.Helpers;
using Melia.Shared.World;
using Melia.Zone.Network.Helpers;
using Melia.Zone.Skills;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors;

namespace Melia.Zone.Network
{
	public static partial class Send
	{
		/// <summary>
		/// Informs players about a hit that occured, and about the target's
		/// new hp, after damage was applied.
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="target"></param>
		/// <param name="attack"></param>
		public static void ZC_HIT_INFO(ICombatEntity attacker, ICombatEntity target, int handle, AttackInfo attack)
		{
			var packet = new Packet(Op.ZC_HIT_INFO);

			packet.PutInt(target.Handle);
			packet.PutInt(attacker.Handle);
			packet.PutInt(100);
			packet.PutInt(attack.Damage);
			packet.PutInt(target.Hp);
			packet.PutInt(attack.Target.HpChangeCounter);
			packet.PutInt(0);
			packet.PutByte(0);
			packet.PutByte((byte)attack.AttackType); // Most likely skill attribute (104 = Arrow, Refer to skill_attribute.ies)
			packet.PutShort((short)attack.HitResult); // 0 = No Visual, 1 = Dodge, 2 = Blue Damage 3 = White/Regular Damage 4 = Yellow/Critical Damage 5 = Regular Damage + Dodge, 6 = Miss, 7+ = Regular Dmg
			packet.PutByte(1);
			packet.PutByte(64); // 100
			packet.PutLong(1);
			packet.PutEmptyBin(3);
			packet.PutInt(attack.EffectHandle);
			packet.PutByte(0);
			packet.PutByte(0);
			packet.PutFloat(0);
			packet.PutInt(0);
			packet.PutInt(attack.HitCount);
			packet.PutLong(attack.Damage / attack.HitCount);
			packet.PutByte(0);

			target.Map.Broadcast(packet);
		}


		/// <summary>
		/// Informs players about a hit that occured, and about the target's
		/// new hp, after damage was applied.
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="skill"></param>
		/// <param name="attacks"></param>
		public static void ZC_SKILL_HIT_INFO(ICombatEntity attacker, Skill skill, int handle, params AttackInfo[] attacks)
		{
			var packet = new Packet(Op.ZC_SKILL_HIT_INFO);

			packet.PutInt(attacker.Handle);
			packet.PutByte((byte)attacks.Length);
			packet.AddAttacks(attacks);

			attacker.Map.Broadcast(packet);
		}

		/// <summary>
		/// Shows skill use for character, by sending ZC_SKILL_FORCE_TARGET to its connection.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		/// <param name="attacks"></param>
		public static void ZC_SKILL_FORCE_TARGET(ICombatEntity caster, ICombatEntity target, Skill skill, params AttackInfo[] attacks)
		{
			var packet = new Packet(Op.ZC_SKILL_FORCE_TARGET);

			packet.PutInt((int)skill.Id);
			packet.PutInt(caster.Handle);
			packet.PutFloat(caster.Direction.Cos);
			packet.PutFloat(caster.Direction.Sin);
			packet.PutInt(1);
			packet.PutFloat(550.7403f); // Skill Particle Distance?
			packet.PutFloat(1);
			packet.PutInt(0);
			if (attacks?.Length > 0)
				packet.PutInt(attacks[0].Handle); // Attacker Handle?
			else
				packet.PutInt(caster.Handle); // This is incorrect, but don't know what to put otherwise
			packet.PutFloat(1.089443f); // Bow Attack: 1.089443f Wand: 1.054772, Pistol Attack: 1.167332, Magic Attack: 1.144914, Cannon Normal Attack/Crossbow Attack: 1.681909
			packet.PutInt(0);
			packet.PutInt(target?.Handle ?? 0);
			packet.PutInt(0);
			packet.PutFloat(512f);
			packet.PutInt(0);
			// TODO fix packet structure for multiple hits, currently we're
			// handling the 1 hit case
			packet.PutByte((byte)(attacks?.Length ?? 0));

			packet.AddAttacks(attacks);

			caster.Map.Broadcast(packet, caster);
		}

		/// <summary>
		/// Shows skill use for character, by sending ZC_SKILL_MELEE_TARGET to its connection.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		/// <param name="target"></param>
		public static void ZC_SKILL_MELEE_TARGET(ICombatEntity caster, Skill skill, ICombatEntity target)
		{
			var packet = new Packet(Op.ZC_SKILL_MELEE_TARGET);

			packet.PutInt((int)skill.Id);
			packet.PutInt(caster.Handle);
			packet.PutDirection(caster.Direction);
			packet.PutInt(1);
			packet.PutFloat(500);
			packet.PutFloat(1);
			packet.PutByte(1);
			packet.PutByte(1); // 0 or 1
			packet.PutShort(0);
			packet.PutInt(0);
			packet.PutFloat(1);
			packet.PutInt(0);
			packet.PutInt(target.Handle);
			packet.PutByte(1); // 0 or 1

			caster.Map.Broadcast(packet);
		}

		/// <summary>
		/// Shows skill use for character, by sending ZC_SKILL_MELEE_GROUND to its connection.
		/// </summary>
		/// <remarks>
		/// i339415, looks hit info is being used instead of this for showing damage on a target
		/// </remarks>
		/// <param name="entity"></param>
		/// <param name="skill"></param>
		/// <param name="targetPosition"></param>
		/// <param name="attacks">
		public static void ZC_SKILL_MELEE_GROUND(ICombatEntity entity, Skill skill, int handle, Position targetPosition, params AttackInfo[] attacks)
		{
			var packet = new Packet(Op.ZC_SKILL_MELEE_GROUND);

			packet.PutInt((int)skill.Id);
			packet.PutInt(entity.Handle);
			packet.PutFloat(entity.Direction.Cos);
			packet.PutFloat(entity.Direction.Sin);
			packet.PutInt(1);
			packet.PutFloat((float)skill.Data.ShootTime.TotalMilliseconds); // Skill Id: 40001 (Heal) value: 600
			packet.PutFloat(1);
			packet.PutInt(0);
			if (attacks?.Length > 0)
				packet.PutInt(attacks[0].Handle); // Attacker Handle?
			else
				packet.PutInt((int)skill.ObjectId); // Attacker Handle?
			packet.PutFloat(entity.GetWeaponSpeed()); // Wand: 1.083666f Hammer: 1.054772f
			if (attacks?.Length > 0)
				packet.PutInt(attacks[0].Target.Handle);
			else
				packet.PutInt(0);
			packet.PutFloat(targetPosition.X);
			packet.PutFloat(targetPosition.Y);
			packet.PutFloat(targetPosition.Z);
			packet.PutShort(attacks?.Length ?? 0);
			packet.AddAttacks(attacks);

			entity.Map.Broadcast(packet);
		}
	}
}

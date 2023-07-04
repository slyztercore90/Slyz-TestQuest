using Melia.Zone.World.Entities;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;

namespace Melia.Zone.Skills.Handlers.Highlander
{
	/// <summary>
	/// Handler for the Highlander skill Sky Liner.
	/// </summary>
	[SkillHandler(SkillId.Highlander_SkyLiner)]
	public class SkyLiner : DynamicGroundSkillHandler
	{
		public override void HandleCastStart(Skill skill, Character caster)
		{
			//caster.SkillHandler = this;
		}

		public override void HandleCastEnd(Skill skill, Character caster)
		{
			//caster.SkillHandler = null;
		}

		public override void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos)
		{
			
		}
	}
}

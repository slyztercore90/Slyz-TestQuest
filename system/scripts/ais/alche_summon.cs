using System.Collections;
using Melia.Shared.World;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.AI;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Logging;
using Yggrasil.Ai.BehaviorTree.Leafs;

[Ai("AlcheSummon")]
public class AlcheSummonAiScript : AiScript
{
	ICombatEntity target;

	protected int MaxRoamDistance = 300;
	protected int MaxChaseDistance = 300;
	protected int MinFollowDistance = 35;

	protected override void Setup()
	{
		During("Idle", CheckEnemies);
		During("Attack", CheckTarget);
		During("ReturnHome", CheckLocation);
	}

	protected override void Root()
	{
		StartRoutine("Idle", Idle());
	}

	protected IEnumerable Idle()
	{
		if (this.Owner == null)
		{
			SetRunning(false);

			yield return Wait(4000, 8000);

			SwitchRandom();
			if (Case(80))
			{
				yield return MoveRandom();
			}
			else
			{
				yield return Animation("IDLE");
			}
		}
		else
		{
			yield return Follow();
		}
	}

	protected IEnumerable Attack()
	{
		SetRunning(true);

		while (!target.IsDead)
		{
			if (!TryGetRandomSkill(out var skill))
			{
				yield return Wait(2000);
				continue;
			}

			while (!InRangeOf(target, skill.GetAttackRange()))
				yield return MoveTo(target.Position, wait: false);

			yield return StopMove();

			yield return UseSkill(skill, target);
			yield return Wait(skill.Properties.Delay);
		}

		yield break;
	}

	protected IEnumerable StopAndIdle()
	{
		yield return StopMove();
		StartRoutine("Idle", Idle());
	}

	protected IEnumerable StopAndAttack()
	{
		yield return StopMove();
		StartRoutine("Attack", Attack());
	}

	private void CheckEnemies()
	{
		var mostHated = GetMostHated();
		if (mostHated != null)
		{
			target = mostHated;
			StartRoutine("StopAndAttack", StopAndAttack());
		}
	}

	private IEnumerable Follow()
	{
		while (!InRangeOf(this.Owner, MinFollowDistance))
			yield return MoveTo(this.Owner.Position.GetRandomInRange2D(15, MinFollowDistance), wait: false);

		yield return StopMove();
		yield return Wait(1000);
	}

	private void CheckTarget()
	{
		// Transition to idle if the target has vanished or is out of range
		if (EntityGone(target) || !InRangeOf(target, MaxChaseDistance) || !IsHating(target))
		{
			target = null;
			StartRoutine("StopAndIdle", StopAndIdle());
		}
	}

	private void CheckLocation()
	{
		if (this.Entity is IMonster monster && monster.SpawnLocation.Position.Get2DDistance(monster.Position) > MaxRoamDistance)
			StartRoutine("ReturnHome", ReturnHome());
		else
			StartRoutine("Idle", Idle());
	}

	protected IEnumerable ReturnHome()
	{
		if (this.Entity is IMonster monster && monster.SpawnLocation != null)
		{
			Log.Debug("Returning Home: {0}", this.Entity.Handle);
			yield return MoveTo(monster.SpawnLocation.Position.GetRandomInRange2D(15, 30));
		}
		StartRoutine("Idle", Idle());
	}
}

//--- Melia Script ----------------------------------------------------------
// Exp Calculation Functions
//--- Description -----------------------------------------------------------
// Functions that primarily calculate exp given by monsters.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Dungeons;

public class ExpCalculationsFunctionsScript : GeneralScript
{

	/// <summary>
	/// Official exp ratio formula
	/// </summary>
	/// <param name="monster"></param>
	/// <param name="character"></param>
	/// <returns></returns>
	[ScriptableFunction("GET_EXP_RATIO")]
	public float GET_EXP_RATIO(Mob monster, Character character)
	{
		var characterLv = character.Level;
		var monsterLv = monster.Level;
		var value = 1.0f;

		if (monster.Buffs.Has(BuffId.SuperExp))
			value = 500.0f;

		var standardLevel = 30;
		var levelGap = Math.Abs(characterLv - monsterLv);

		if (levelGap > standardLevel)
		{
			var penaltyRatio = characterLv < monsterLv ? 0.05f : 0.02f;
			var lvRatio = 1.0f - ((levelGap - standardLevel) * penaltyRatio);
			value *= lvRatio;
		}

		return Math.Min(0, value);
	}

	/// <summary>
	/// Official instance dungeon exp ratio formula
	/// </summary>
	/// <param name="instanceDungeon"></param>
	/// <param name="character"></param>
	/// <returns></returns>
	/// <remarks>Disabled Attributed because Instance Dungeons aren't implemented.</remarks>
	//[ScriptableFunction("GET_EXP_RATIO_INDUN")]
	public float GET_EXP_RATIO_INDUN(InstanceDungeon instanceDungeon, Character character)
	{
		var characterLv = character.Level;
		var instanceDungeonLv = instanceDungeon.Level;
		var value = 1.0f;

		var standardLevel = 80;
		var levelGap = Math.Abs(characterLv - instanceDungeonLv);

		if (levelGap > standardLevel)
		{
			var penaltyRatio = characterLv < instanceDungeonLv ? 0.05f : 0.05f;
			var lvRatio = 1.0f - ((levelGap - standardLevel) * penaltyRatio);
			value *= lvRatio;
		}

		return Math.Min(0, value);
	}

	/// <summary>
	/// Returns the monster's exp penalty given to a character.
	/// </summary>
	/// <param name="monster"></param>
	/// <returns></returns>
	[ScriptableFunction("SCR_Get_MON_ExpPenalty")]
	public float SCR_Get_MON_ExpPenalty(Mob monster, Character character)
	{
		var levelDiff = character.Level - monster.Level;
		var expPenalty = 1f;

		if (levelDiff >= 10)
			expPenalty = .02f;
		else if (levelDiff == 9)
			expPenalty = .15f;
		else if (levelDiff == 8)
			expPenalty = .36f;
		else if (levelDiff == 7)
			expPenalty = .68f;
		else if (levelDiff == 6)
			expPenalty = .88f;
		else if (levelDiff >= -5 && levelDiff <= 5)
			expPenalty = 1f;
		else if (levelDiff == -6)
			expPenalty = .81f;
		else if (levelDiff == -7)
			expPenalty = .62f;
		else if (levelDiff == -8)
			expPenalty = .43f;
		else if (levelDiff == -9)
			expPenalty = .24f;
		else if (levelDiff <= -10)
			expPenalty = .05f;

		return expPenalty;
	}

	[ScriptableFunction("SCR_Get_MON_ClassExpPenalty")]
	public float SCR_Get_MON_ClassExpPenalty(Mob monster, Character character)
	{
		var levelDiff = character.ClassLevel - monster.Level;
		var expPenalty = 1f;

		if (levelDiff >= 10)
			expPenalty = .02f;
		else if (levelDiff == 9)
			expPenalty = .15f;
		else if (levelDiff == 8)
			expPenalty = .36f;
		else if (levelDiff == 7)
			expPenalty = .68f;
		else if (levelDiff == 6)
			expPenalty = .88f;
		else if (levelDiff >= -5 && levelDiff <= 5)
			expPenalty = 1f;
		else if (levelDiff == -6)
			expPenalty = .81f;
		else if (levelDiff == -7)
			expPenalty = .62f;
		else if (levelDiff == -8)
			expPenalty = .43f;
		else if (levelDiff == -9)
			expPenalty = .24f;
		else if (levelDiff <= -10)
			expPenalty = .05f;

		return expPenalty;
	}
}

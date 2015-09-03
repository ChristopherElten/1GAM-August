using UnityEngine;
using System.Collections;

public class BattleAction : BattleCommand {

	public string description;
	public CombatAction combatAction;
	public Unit actionInvokerUnit;
	public Unit actionTargetUnit;
	public Sprite actionIcon;

	public BattleAction(string description){
		this.description = description;
	}

	public BattleAction(string description, CombatAction actionMethod, Unit actionInvokerUnit, Unit actionTargetUnit, Sprite actionIcon){
		this.description = description;
		this.actionInvokerUnit = actionInvokerUnit;
		this.actionTargetUnit = actionTargetUnit;
		this.combatAction = actionMethod;
		this.actionIcon = actionIcon;
	}

	public void Execute(){
		combatAction(actionInvokerUnit, actionTargetUnit);
	}
}

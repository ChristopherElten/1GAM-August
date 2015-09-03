using UnityEngine;
using System.Collections;

//Combat Action Delagate
public delegate void CombatAction(Unit actionInvokerUnit, Unit actionTargetUnit);

//Database of combat actions between target and unit...
public class CombatActions : GameSubject {

	protected int numberOfAttacks;

	protected virtual void BasicAttack(Unit actionInvokerUnit, Unit actionTargetUnit){
		Debug.Log("Target: " + actionTargetUnit.getUnitName() + actionTargetUnit.getIsOpponent());
		Debug.Log("Initial Health: " + actionTargetUnit.getHealth());
		actionTargetUnit.setHealth(actionTargetUnit.getHealth() - actionInvokerUnit.getDamage());
		Debug.Log("Final Health: " + actionTargetUnit.getHealth());
	}
}

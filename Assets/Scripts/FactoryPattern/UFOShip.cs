using UnityEngine;
using System.Collections;

public class UFOShip : Unit {

	public UFOShip(){
		setName("UFO Ship");
		setDamage(20.0);
		setHealth(35.0);
		setUnitSprite(Resources.Load<Sprite>("Units/test-unit"));
	}

	protected override void BasicAttack(Unit actionInvokerUnit, Unit actionTargetUnit){
		Debug.Log("Target: " + actionTargetUnit.getUnitName() + actionTargetUnit.getIsOpponent()
		          + "\n Initial Health: " + actionTargetUnit.getHealth());
		actionTargetUnit.setHealth(actionTargetUnit.getHealth() - actionInvokerUnit.getDamage() - 20);
		Debug.Log("Final Health: " + actionTargetUnit.getHealth());
	}
}

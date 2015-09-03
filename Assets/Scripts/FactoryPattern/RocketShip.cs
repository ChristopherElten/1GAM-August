using UnityEngine;
using System.Collections;

public class RocketShip : Unit {
	
	public RocketShip(){
		setName("Rocket Ship");
		setDamage(10.0);
		setHealth(75.0);
		setUnitSprite(Resources.Load<Sprite>("Units/roy"));
	}

	protected override void BasicAttack(Unit actionInvokerUnit, Unit actionTargetUnit){
		
		numberOfAttacks++;
		//Check for achievement
		if (numberOfAttacks == 2){
			GameEvent achievementEvent = new GameEvent(new Achievement("2 attacks performed!"));
			notifyObserver(achievementEvent);
		}

		Debug.Log("Target: " + actionTargetUnit.getUnitName() + actionTargetUnit.getIsOpponent()
		          + "\n Initial Health: " + actionTargetUnit.getHealth());
		actionTargetUnit.setHealth(actionTargetUnit.getHealth() - actionInvokerUnit.getDamage() - 80);
		Debug.Log("Final Health: " + actionTargetUnit.getHealth());
	}
}

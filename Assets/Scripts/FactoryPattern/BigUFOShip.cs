using UnityEngine;
using System.Collections;

public class BigUFOShip : UFOShip {
	
	public BigUFOShip(){
		setName("Big UFO Ship");
		setDamage(40.0);
		setHealth(100.0);
		setUnitSprite(Resources.Load<Sprite>("Units/magby"));
	}
}
